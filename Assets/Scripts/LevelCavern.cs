using UnityEngine;

/* Nivel 2-2: galerias profundas del segundo mundo, con cristales y bloques azules. */
public static class LevelCavern
{
    public const float Length = 208f;
    public const float CameraHeight = 6.5f;

    public static void Build(LevelBuilder b)
    {
        b.length = Length;

        // techo de piedra
        b.RowSprite("CaveBrick", 0, 207, 10);
        b.RowSprite("CaveBrick", 0, 207, 11);

        // suelo por tramos, con cuatro fosas
        int[][] tramos =
        {
            new[] { 0, 50 },
            new[] { 56, 94 },
            new[] { 100, 148 },
            new[] { 154, 207 },
        };

        foreach (int[] tramo in tramos)
        {
            b.GroundSprite("CaveStone", tramo[0], tramo[1], 0);
        }

        for (int y = 1; y <= 9; y++) {
            b.TileSprite("CaveStone", 0, y);
        }

        // --------------------------- decorado -----------------------------
        int[] cristales = { 6, 14, 27, 41, 60, 72, 85, 104, 118, 132, 145, 160, 174, 190 };

        foreach (int x in cristales)
        {
            b.SpriteObject("Crystal", x + 0.5f, 1.5f, -3);

            if (x % 2 == 0) {
                b.SpriteObject("Crystal", x + 1.5f, 2.5f, -3);
            }
        }

        for (int y = 6; y <= 9; y++) {
            b.SpriteObject("Crystal", 32.5f, y, -3);
            b.SpriteObject("Crystal", 152.5f, y, -3);
        }

        // ---------------------------- bloques -----------------------------
        b.SpriteBrickRow("CaveBrick", 9, 13, 4);
        b.SpriteMystery("MysteryBlock", 11, 4, "MagicMushroom");
        b.CoinRow(9, 13, 5);
        b.Goomba(17, 0);

        b.PiranhaPipe(22, 0, 3, true);
        b.CoinRow(26, 29, 5);

        b.SpriteBrickRow("CaveBrick", 30, 35, 6);
        b.CoinRow(31, 34, 7);
        b.Koopa(39, 0);
        b.Goomba(45, 0);

        // escalera del segundo tramo
        for (int i = 0; i < 4; i++)
        {
            for (int y = 1; y <= i + 1; y++) {
                b.TileSprite("CaveStone", 56 + i, y);
            }
        }

        b.SpriteBrickRow("CaveBrick", 64, 70, 5);
        b.SpriteMystery("MysteryBlock", 67, 5, "1upMushroom");
        b.CoinRow(65, 69, 6);
        b.Goomba(74, 0);
        b.Koopa(81, 0);
        b.PiranhaPipe(86, 0, 4, true);
        b.CoinRow(90, 93, 3);

        // tercer tramo con bajada de piedra
        for (int i = 0; i < 4; i++)
        {
            for (int y = 1; y <= 4 - i; y++) {
                b.TileSprite("CaveStone", 100 + i, y);
            }
        }

        b.SpriteBrickRow("CaveBrick", 108, 114, 5);
        b.CoinRow(108, 114, 6);
        b.Goomba(120, 0);
        b.Goomba(126, 0);
        b.Koopa(132, 0);
        b.SpriteMystery("MysteryBlock", 138, 4, "Starman");
        b.CoinRow(136, 140, 4);
        b.Goomba(144, 0);

        // tramo final
        b.SpriteBrickRow("CaveBrick", 158, 163, 6);
        b.CoinRow(159, 162, 7);
        b.Koopa(168, 0);
        b.PiranhaPipe(176, 0, 3, true);
        b.Goomba(181, 0);
        b.CoinRow(184, 190, 3);

        // tuberia de salida hacia el arrecife
        b.ExitPipe(198, 0, 4);

        b.DeathBarrier(-4f);
        b.SpawnPlayer(3, 0);
    }

}
