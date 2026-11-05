using UnityEngine;

/* Nivel 2-4: fortaleza del segundo mundo, mas corta y con mas trampas que la primera. */
public static class LevelFortress
{
    public const float Length = 152f;
    public const float CameraHeight = 6f;

    public static void Build(LevelBuilder b)
    {
        b.length = Length;

        b.SpriteObject("CastleBackground", Length * 0.5f, 5.5f, -10, false, true, Length, 11f);

        int[] banderas = { 6, 15, 24, 33, 42, 51, 60, 69, 78, 88, 98, 108, 118, 130, 142 };

        foreach (int x in banderas)
        {
            b.SpriteObject("CastleBanner", x + 0.5f, 7.4f, -7);
            b.SpriteObject("Skull", x + 0.5f, 5.2f, -7);
        }


        b.RowSprite("CastleBrick", 0, 151, 10);
        b.RowSprite("CastleBrick", 0, 151, 11);

        // --------------------------- entrada ------------------------------
        b.GroundSprite("CastleGround", 0, 18, 0);

        for (int y = 1; y <= 9; y++) {
            b.TileSprite("CastleBrick", 0, y);
        }

        b.CoinRow(4, 7, 3);
        b.SpriteMystery("CastleQBlock", 10, 4, "MagicMushroom");
        b.SpriteMystery("CastleQBlock", 12, 4, "1upMushroom");
        b.Goomba(15, 0);

        // ------------------------ lava con ascensores --------------------
        b.LavaPool(19, 26, -1);
        b.MovingPlatform(20.5f, 2f, 20.5f, 5f, 1.4f, 2.5f);
        b.MovingPlatform(25f, 5f, 25f, 2f, 1.4f, 2.5f);
        b.FireBar(23, 8, 5, 110f);
        b.LavaBubble(21, 1f, 5f, 3.2f, 0.3f);
        b.LavaBubble(25, 1f, 5f, 3.4f, 1.6f);

        // ------------------------ corredor de canones --------------------
        b.GroundSprite("CastleGround", 27, 38, 0);
        b.TileSprite("CastleBrick", 30, 4);
        b.TileSprite("CastleBrick", 31, 4);
        b.CoinRow(30, 32, 5);
        b.WallCannon(33, 6, -1f);
        b.Goomba(28, 0);
        b.Koopa(36, 0);

        b.LavaPool(39, 43, -1);
        b.LavaBubble(40, 1f, 5.5f, 3f, 0.7f);
        b.LavaBubble(42, 1f, 5.5f, 3f, 2f);

        b.GroundSprite("CastleGround", 44, 58, 0);
        b.FireBar(48, 7, 6, 120f);
        b.PiranhaPipe(53, 0, 2);
        b.SpriteMystery("CastleQBlock", 56, 5, "BlockCoin");
        b.CoinRow(54, 58, 4);
        b.Koopa(50, 0);

        // ------------------------- sala de fuego -------------------------
        b.GroundSprite("CastleGround", 59, 70, 0);
        b.FireBar(63, 6, 7, -110f);
        b.WallCannon(68, 5, -1f);
        b.Goomba(61, 0);
        b.Koopa(66, 0);
        b.CoinRow(59, 62, 3);

        b.LavaPool(71, 74, -1);
        b.LavaBubble(72, 1f, 5f, 2.8f, 0.4f);
        b.SpriteObject("Chain", 72.5f, 8.5f, -6);

        // ---------------------- pasillo final y puente -------------------
        b.GroundSprite("CastleGround", 75, 96, 0);
        b.FireBar(80, 7, 6, 130f);
        b.PiranhaPipe(85, 0, 2);
        b.PiranhaPipe(90, 0, 2);
        b.WallCannon(94, 6, -1f);
        b.Koopa(82, 0);
        b.Goomba(88, 0);
        b.CoinRow(76, 79, 3);

        for (int i = 0; i < 4; i++)
        {
            for (int y = 1; y <= i + 1; y++) {
                b.TileSprite("CastleBrick", 97 + i, y);
            }
        }

        b.LavaPool(101, 126, -1);

        BridgeCollapse bridge = b.Bridge();

        for (int x = 101; x <= 126; x++) {
            b.BridgePlank(x, 0, bridge);
        }

        BowserBoss bowser = b.Bowser(114, 0, 104f, 123f);
        bridge.bowser = bowser;

        b.CoinRow(106, 112, 4);
        b.LavaBubble(107, 1f, 6f, 3.4f, 1.2f);
        b.LavaBubble(120, 1f, 6f, 3.4f, 2.3f);

        // ------------------------- camara del hacha ----------------------
        b.GroundSprite("CastleGround", 127, 151, 0);
        b.Axe(130, 0, bridge);
        b.SpriteMystery("CastleQBlock", 136, 4, "1upMushroom");

        b.SpriteObject("CastleWindow", 140.5f, 6.5f, -7);
        b.AnimatedDecoration(138, 3.5f, new[] { "Torch1", "Torch2" }, 0.12f, -3);
        b.AnimatedDecoration(146, 3.5f, new[] { "Torch1", "Torch2" }, 0.12f, -3);

        int[] torches = { 3, 8, 13, 29, 35, 46, 52, 60, 67, 78, 84, 92, 128, 143, 149 };

        foreach (int x in torches) {
            b.AnimatedDecoration(x, 3.5f, new[] { "Torch1", "Torch2" }, 0.12f, -3);
        }

        int[] windows = { 5, 11, 31, 49, 64, 81, 95, 134, 144 };

        foreach (int x in windows) {
            b.SpriteObject("CastleWindow", x + 0.5f, 6.6f, -7);
        }

        b.DeathBarrier(-6f);
        b.SpawnPlayer(3, 0);
    }

}
