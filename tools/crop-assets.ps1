# Recorta los sprites verticales de 16x32 (lava y superficie del agua) en tiles de 16x16.
Add-Type -AssemblyName System.Drawing

$dir = Join-Path $PSScriptRoot '..\Assets\Resources\Sprites'

function Crop-Tile($source, $dest, $y) {
    $image = [System.Drawing.Image]::FromFile($source)
    $bitmap = New-Object System.Drawing.Bitmap 16, 16
    $graphics = [System.Drawing.Graphics]::FromImage($bitmap)
    $graphics.InterpolationMode = [System.Drawing.Drawing2D.InterpolationMode]::NearestNeighbor
    $graphics.PixelOffsetMode = [System.Drawing.Drawing2D.PixelOffsetMode]::Half

    $destRect = New-Object System.Drawing.Rectangle 0, 0, 16, 16
    $srcRect = New-Object System.Drawing.Rectangle 0, $y, 16, 16
    $graphics.DrawImage($image, $destRect, $srcRect, [System.Drawing.GraphicsUnit]::Pixel)

    $graphics.Dispose()
    $bitmap.Save($dest, [System.Drawing.Imaging.ImageFormat]::Png)
    $bitmap.Dispose()
    $image.Dispose()
}

$lava = Join-Path $dir 'LavaTile.png'
Crop-Tile $lava (Join-Path $dir 'LavaTop.png') 0
Crop-Tile $lava (Join-Path $dir 'LavaDeep.png') 16

$water = Join-Path $dir 'WaterSurface.png'
Crop-Tile $water (Join-Path $dir 'WaterTop.png') 0

Write-Host 'Recortes listos.'
