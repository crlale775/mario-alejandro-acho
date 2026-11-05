using UnityEngine;

/* Nivel 2-3: arrecife del segundo mundo, con nado entre cristales y peces. */
public static class LevelReef
{
    public const float Length = 178f;
    public const float CameraHeight = 6.5f;

    private static int FloorTop(int x)
    {
        if (x >= 20 && x <= 34) return 1;
        if (x >= 58 && x <= 76) return 2;
        if (x >= 104 && x <= 122) return 1;
        if (x >= 140 && x <= 154) return 2;
        return 0;
    }

    public static void Build(LevelBuilder b)
    {
        b.length = Length;

        b.GroundSprite("SeaGround", 0, 177, 0);
        b.GroundSprite("SeaGround", 20, 34, 1);
        b.GroundSprite("SeaGround", 58, 76, 2);
        b.GroundSprite("SeaGround", 104, 122, 1);
        b.GroundSprite("SeaGround", 140, 154, 2);

        for (int x = -2; x < 178; x++) {
            b.SpriteObject("WaterTop", x + 0.5f, 11.5f, -6);
        }

        // --------------------------- decorado -----------------------------
        int[] corales = { 4, 12, 24, 31, 40, 50, 62, 70, 82, 92, 108, 116, 128, 138, 146, 158, 166, 174 };

        foreach (int x in corales)
        {
            b.SpriteObject(x % 2 == 0 ? "Coral1" : "Coral2", x + 0.5f, FloorTop(x) + 1.5f, -1);
        }

        int[] cristales = { 8, 26, 46, 66, 88, 112, 132, 150, 170 };

        foreach (int x in cristales)
        {
            b.SpriteObject("Crystal", x + 0.5f, FloorTop(x) + 1.4f, -2);
            b.SpriteObject("Crystal", x + 1.5f, FloorTop(x) + 2.4f, -2);
        }

        for (int x = 6; x < 176; x += 6) {
            b.SpriteObject(x % 2 == 0 ? "Seaweed1" : "Seaweed2", x + 0.5f, FloorTop(x) + 1.6f, -2);
        }

        // -------------------------- plataformas ---------------------------
        b.RowSprite("SeaBrick", 8, 14, 4);
        b.CoinRow(8, 14, 5);

        b.RowSprite("SeaBrick", 38, 44, 6);
        b.CoinRow(39, 43, 7);

        b.RowSprite("SeaBrick", 48, 54, 4);
        b.CoinRow(48, 54, 5);

        b.RowSprite("SeaBrick", 80, 86, 6);
        b.CoinRow(81, 85, 7);

        b.RowSprite("SeaBrick", 94, 100, 4);
        b.CoinRow(94, 100, 5);

        b.RowSprite("SeaBrick", 126, 132, 7);
        b.CoinRow(127, 131, 8);

        b.RowSprite("SeaBrick", 156, 162, 5);
        b.CoinRow(156, 162, 6);

        b.SpriteObject("SeaPlatform", 30.5f, 5.2f, -1, true, false, 3f, 0.5f);
        b.CoinRow(29, 31, 6);

        b.SpriteObject("SeaPlatform", 88.5f, 4.2f, -1, true, false, 3f, 0.5f);
        b.CoinRow(87, 89, 5);

        b.SpriteObject("SeaPlatform", 136.5f, 6.2f, -1, true, false, 3f, 0.5f);
        b.CoinRow(135, 137, 7);

        // ----------------------------- peces ------------------------------
        b.CheepCheep(16, 8f, 5f, 2.6f);
        b.CheepCheep(28, 6.5f, 6f, 2.2f);
        b.CheepCheep(42, 9f, 5f, 3f);
        b.CheepCheep(55, 7.5f, 6f, 2.4f);
        b.CheepCheep(68, 8.5f, 5f, 2.8f);
        b.CheepCheep(84, 6.5f, 6f, 2.3f);
        b.CheepCheep(98, 9f, 5f, 3.1f);
        b.CheepCheep(114, 7.5f, 6f, 2.5f);
        b.CheepCheep(130, 8.5f, 5f, 2.7f);
        b.CheepCheep(148, 6.5f, 6f, 2.9f);
        b.CheepCheep(162, 8f, 5f, 2.4f);

        b.Blooper(22, 5.5f, 4f, 1.7f);
        b.Blooper(52, 8.5f, 5f, 1.5f);
        b.Blooper(78, 6f, 4f, 1.8f);
        b.Blooper(106, 8f, 5f, 1.6f);
        b.Blooper(144, 6.5f, 4f, 1.9f);
        b.Blooper(168, 8.5f, 5f, 1.5f);

        // premio del arrecife
        b.Spawn("1upMushroom", 151.5f, 10f);

        b.Bubbles(0f, Length, 1f, 11f, 24);

        b.ExitPipe(166, 0, 3);

        b.SpawnPlayer(4, 0);
    }

}
