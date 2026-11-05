using UnityEngine;

/* Nivel 2-1: travesia por el desierto con piramides, cactus y tuberias. */
public static class LevelDesert
{
    public const float Length = 198f;
    public const float CameraHeight = 6.5f;

    public static void Build(LevelBuilder b)
    {
        b.length = Length;

        // ------------------------------- suelo ----------------------------
        int[][] tramos =
        {
            new[] { 0, 44 },
            new[] { 49, 92 },
            new[] { 97, 141 },
            new[] { 146, 197 },
        };

        foreach (int[] tramo in tramos)
        {
            b.GroundSprite("DesertGround", tramo[0], tramo[1], -1, 3);
            b.RowSprite("DesertSand", tramo[0], tramo[1], 0);
        }

        // ------------------------------- cielo ----------------------------
        for (int x = -8; x < 200; x += 15)
        {
            b.SpriteObject("Cloud1", x + 0.5f, 10.5f, -6);
            b.SpriteObject(x % 3 == 0 ? "Cloud2" : "Cloud3", x + 7.5f, 12.2f, -6);
        }

        // ----------------------------- decorado ---------------------------
        b.SpriteObject("Pyramid", 26.5f, 2.5f, -3);
        b.SpriteObject("Pyramid", 68.5f, 2.5f, -3);
        b.SpriteObject("Pyramid", 106.5f, 2.5f, -3);
        b.SpriteObject("Pyramid", 178.5f, 2.5f, -3);

        int[] cactus = { 7, 15, 31, 39, 53, 66, 79, 86, 101, 113, 124, 134, 150, 161, 172, 190 };

        foreach (int x in cactus)
        {
            bool alto = x % 3 == 0;
            b.SpriteObject(alto ? "Cactus2" : "Cactus1", x + 0.5f, alto ? 2f : 1.5f, -1);
        }

        int[] piedras = { 11, 21, 35, 58, 74, 89, 109, 128, 144, 166, 184 };

        foreach (int x in piedras)
        {
            b.SpriteObject("DesertRock", x + 0.5f, 1.5f, -1);
        }

        // ----------------------------- bloques ----------------------------
        b.SpriteBrick("DesertBrick", 10, 4);
        b.SpriteBrick("DesertBrick", 11, 4);
        b.SpriteMystery("MysteryBlock", 12, 4, "MagicMushroom");
        b.SpriteBrick("DesertBrick", 13, 4);
        b.CoinRow(10, 13, 5);

        b.SpriteBrickRow("DesertBrick", 18, 23, 4);
        b.CoinRow(18, 23, 5);
        b.Goomba(21, 0);

        b.PiranhaPipe(30, 0, 2);
        b.Koopa(37, 0);
        b.CoinRow(33, 36, 4);

        b.SpriteBrickRow("DesertBrick", 55, 60, 5);
        b.SpriteMystery("MysteryBlock", 57, 5, "1upMushroom");
        b.CoinRow(55, 60, 6);
        b.Goomba(63, 0);

        b.PiranhaPipe(70, 0, 3);
        b.SpriteObject("DesertRock", 80.5f, 3.5f, -1, true);
        b.CoinRow(79, 82, 5);

        b.Koopa(88, 0);
        b.CoinRow(84, 87, 3);

        b.SpriteBrickRow("DesertBrick", 99, 104, 4);
        b.CoinRow(99, 104, 5);

        b.Goomba(110, 0);
        b.Goomba(116, 0);
        b.PiranhaPipe(122, 0, 2);
        b.SpriteMystery("MysteryBlock", 129, 4, "Starman");
        b.CoinRow(128, 131, 4);
        b.Koopa(136, 0);

        b.SpriteBrickRow("DesertBrick", 148, 152, 5);
        b.SpriteMystery("MysteryBlock", 150, 5, "BlockCoin");
        b.CoinRow(148, 152, 6);
        b.Goomba(158, 0);
        b.Koopa(164, 0);
        b.PiranhaPipe(170, 0, 3);
        b.CoinRow(174, 180, 4);

        // ------------------------------ salida ----------------------------
        b.FlagPole(188, 0);

        b.DeathBarrier(-4f);
        b.SpawnPlayer(3, 0);
    }

}
