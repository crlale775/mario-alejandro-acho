param(
  [string]$Out = "shot.png",
  [string]$Keys = "",
  [int]$WaitMs = 1200,
  [int]$Width = 1536,
  [int]$Height = 960,
  [string]$Hold = "",
  [int]$HoldMs = 1500,
  [switch]$AutoJump
)

Add-Type @"
using System;
using System.Runtime.InteropServices;
public class Win32 {
  [DllImport("user32.dll")] public static extern bool SetForegroundWindow(IntPtr hWnd);
  [DllImport("user32.dll")] public static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);
  [DllImport("user32.dll")] public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
  [DllImport("user32.dll")] public static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, UIntPtr dwExtraInfo);
}
"@

Add-Type -AssemblyName System.Windows.Forms, System.Drawing

$proc = Get-Process -Name "Mario Acho" -ErrorAction SilentlyContinue | Where-Object { $_.MainWindowHandle -ne 0 } | Select-Object -First 1

if (-not $proc) {
  Write-Output "NO WINDOW"
  exit 1
}

$handle = $proc.MainWindowHandle
[Win32]::ShowWindow($handle, 9) | Out-Null
[Win32]::MoveWindow($handle, 0, 0, $Width, $Height, $true) | Out-Null
[Win32]::SetForegroundWindow($handle) | Out-Null
Start-Sleep -Milliseconds 700

if ($Keys -ne "") {
  $wsh = New-Object -ComObject WScript.Shell

  foreach ($key in $Keys.Split(",")) {
    $wsh.SendKeys($key)
    Start-Sleep -Milliseconds 400
  }
}

if ($Hold -ne "") {
  $codes = @{ RIGHT = 0x27; LEFT = 0x25; UP = 0x26; DOWN = 0x28; SPACE = 0x20 }
  $vk = [byte]$codes[$Hold]
  [Win32]::keybd_event($vk, 0, 0, [UIntPtr]::Zero)

  $elapsed = 0
  while ($elapsed -lt $HoldMs) {
    Start-Sleep -Milliseconds 120
    $elapsed += 120

    if ($AutoJump -and ($elapsed % 720) -lt 120) {
      [Win32]::keybd_event([byte]0x20, 0, 0, [UIntPtr]::Zero)
      Start-Sleep -Milliseconds 90
      [Win32]::keybd_event([byte]0x20, 0, 2, [UIntPtr]::Zero)
    }
  }

  [Win32]::keybd_event($vk, 0, 2, [UIntPtr]::Zero)
}

Start-Sleep -Milliseconds $WaitMs

$bounds = [System.Windows.Forms.Screen]::PrimaryScreen.Bounds
$bitmap = New-Object System.Drawing.Bitmap($bounds.Width, $bounds.Height)
$graphics = [System.Drawing.Graphics]::FromImage($bitmap)
$graphics.CopyFromScreen(0, 0, 0, 0, $bitmap.Size)
$bitmap.Save($Out, [System.Drawing.Imaging.ImageFormat]::Png)
$graphics.Dispose()
$bitmap.Dispose()

Write-Output "OK $Out ($($bounds.Width)x$($bounds.Height))"
