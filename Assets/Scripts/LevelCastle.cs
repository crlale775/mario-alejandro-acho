using UnityEngine;

/* Nivel 1-4: castillo de Bowser de diseno propio. Recorre el salon de entrada,
   el foso de lava con ascensores, el corredor de canones, la sala de barras de
   fuego, el lago donde se conduce la bola de fuego de Toad, la sala de
   plataformas y por ultimo el puente con Bowser y el hacha. */
public static class LevelCastle
{
    public const float Length = 206f;
    public const float CameraHeight = 6f;

    public static void Build(LevelBuilder b)
    {
        b.length = Length;

        // muro de fondo de todo el castillo
        b.SpriteObject("CastleBackground", Length * 0.5f, 5.5f, -10, false, true, Length, 11f);

        // techo abovedado
        b.RowSprite("CastleBrick", 0, 205, 10);
        b.RowSprite("CastleBrick", 0, 205, 11);

        // ------------------------- salon de entrada ----------------------
        b.GroundSprite("CastleGround", 0, 22, 0);

        for (int y = 1; y <= 9; y++) {
            b.TileSprite("CastleBrick", 0, y);
        }

        b.CoinRow(6, 9, 3);
        b.Mystery(16, 4, "MagicMushroom");
        b.Goomba(12, 0);
        b.Koopa(19, 0);

        // ---------------------- foso de lava y ascensores ---------------
        b.LavaPool(23, 30, -1);
        b.MovingPlatform(24.5f, 2f, 24.5f, 5f, 1.3f, 2.5f);
        b.MovingPlatform(28.5f, 5f, 28.5f, 2f, 1.3f, 2.5f);
        b.FireBar(27, 8, 5, 95f);
        b.CoinRow(24, 29, 7);
        b.LavaBubble(26, 1f, 5f, 3.2f, 0.4f);
        b.LavaBubble(29, 1f, 5f, 3.2f, 1.7f);

        // ----------------------- corredor de canones --------------------
        b.GroundSprite("CastleGround", 31, 40, 0);

        b.TileSprite("CastleBrick", 34, 4);
        b.TileSprite("CastleBrick", 35, 4);
        b.TileSprite("CastleBrick", 36, 4);
        b.CoinRow(34, 36, 5);

        b.WallCannon(34, 6, -1f);
        b.WallCannon(39, 5, -1f);
        b.Goomba(33, 0);
        b.Koopa(38, 0);

        // canal de lava con burbujas
        b.LavaPool(41, 44, -1);
        b.LavaBubble(42, 1f, 5.5f, 3.4f, 0.8f);
        b.LavaBubble(44, 1f, 5.5f, 3.4f, 2.1f);

        b.GroundSprite("CastleGround", 45, 52, 0);
        b.PiranhaPipe(47, 0, 2);
        b.PiranhaPipe(51, 0, 2);
        b.Goomba(50, 0);
        b.CoinRow(45, 46, 4);

        // --------------------- sala de barras de fuego ------------------
        b.GroundSprite("CastleGround", 53, 65, 0);
        b.FireBar(57, 7, 6, 110f);
        b.FireBar(63, 6, 7, -95f);

        b.BrickRow(59, 65, 5);
        b.Mystery(61, 5, "MagicMushroom");
        b.CoinRow(59, 65, 6);
        b.Koopa(55, 0);
        b.Goomba(62, 0);

        b.LavaPool(66, 68, -1);
        b.LavaBubble(67, 1f, 5f, 3f, 0.6f);
        b.SpriteObject("Chain", 66.5f, 8.5f, -6);
        b.SpriteObject("Chain", 68.5f, 8.5f, -6);

        b.GroundSprite("CastleGround", 69, 74, 0);
        b.FireBar(70, 7, 6, 140f);
        b.Koopa(73, 0);

        // -------------------- lago de la bola de fuego ------------------
        b.GroundSprite("CastleGround", 75, 82, 0);

        // trampolin de salida: escalera de piedra hacia el lago
        b.TileSprite("CastleGround", 81, 1);
        b.TileSprite("CastleGround", 82, 1);
        b.TileSprite("CastleGround", 82, 2);
        b.CoinRow(76, 79, 3);
        b.Mystery(78, 4, "BlockCoin");

        b.LavaPool(83, 104, -1);
        b.ToadRide(85.5f, 2f, 84.5f, 102f);

        b.LavaBubble(90, 1f, 6f, 4f, 0.5f);
        b.LavaBubble(97, 1f, 6f, 4f, 2.4f);
        b.SpriteObject("Chain", 88.5f, 8.5f, -6);
        b.SpriteObject("Chain", 96.5f, 8.5f, -6);
        b.SpriteObject("Chain", 102.5f, 8.5f, -6);
        b.CoinRow(88, 96, 7);

        // -------------------- desembarco y pasillo ---------------------
        b.GroundSprite("CastleGround", 105, 122, 0);
        b.CoinRow(106, 109, 2);
        b.Mystery(112, 4, "MagicMushroom");

        b.PiranhaPipe(115, 0, 2);
        b.PiranhaPipe(120, 0, 2);
        b.Koopa(118, 0);

        b.TileSprite("CastleBrick", 107, 4);
        b.TileSprite("CastleBrick", 108, 4);
        b.TileSprite("CastleBrick", 109, 4);
        b.CoinRow(107, 109, 5);

        // ------------------ sala de plataformas colgantes ----------------
        b.LavaPool(123, 142, -1);
        b.MovingPlatform(124.5f, 3f, 129f, 3f, 1.8f, 2.5f);
        b.MovingPlatform(132f, 5f, 132f, 2.5f, 1.5f, 2.5f);
        b.MovingPlatform(139f, 3f, 134f, 3f, 1.8f, 2.5f);
        b.LavaBubble(127, 1f, 6f, 3.6f, 0.9f);
        b.LavaBubble(136, 1f, 6f, 3.6f, 2.2f);
        b.CoinRow(128, 138, 6);

        // ------------------------- corredor final -----------------------
        b.GroundSprite("CastleGround", 143, 160, 0);
        b.FireBar(147, 7, 6, -120f);
        b.FireBar(155, 7, 6, 125f);
        b.WallCannon(145, 6, -1f);
        b.WallCannon(152, 5, -1f);
        b.Koopa(150, 0);
        b.Goomba(158, 0);
        b.CoinRow(144, 146, 3);

        // escalera hacia el puente
        b.TileSprite("CastleBrick", 157, 1);
        b.TileSprite("CastleBrick", 158, 1);
        b.TileSprite("CastleBrick", 158, 2);
        b.TileSprite("CastleBrick", 159, 1);
        b.TileSprite("CastleBrick", 159, 2);
        b.TileSprite("CastleBrick", 159, 3);
        b.TileSprite("CastleBrick", 160, 1);
        b.TileSprite("CastleBrick", 160, 2);
        b.TileSprite("CastleBrick", 160, 3);

        // ------------------------- puente y jefe -------------------------
        b.LavaPool(161, 186, -1);

        BridgeCollapse bridge = b.Bridge();

        for (int x = 161; x <= 186; x++) {
            b.BridgePlank(x, 0, bridge);
        }

        BowserBoss bowser = b.Bowser(174, 0, 164f, 183f);
        bridge.bowser = bowser;

        b.CoinRow(166, 172, 4);

        // ------------------------- camara del hacha ----------------------
        b.GroundSprite("CastleGround", 187, 205, 0);
        b.Axe(190, 0, bridge);

        b.SpriteObject("CastleWindow", 196.5f, 6.5f, -7);
        b.AnimatedDecoration(194, 3.5f, new[] { "Torch1", "Torch2" }, 0.12f, -3);
        b.AnimatedDecoration(200, 3.5f, new[] { "Torch1", "Torch2" }, 0.12f, -3);

        // ---------------------------- decorado ---------------------------
        int[] windows = { 4, 10, 17, 33, 47, 58, 72, 79, 107, 118, 131, 144, 153, 168, 182 };

        foreach (int x in windows) {
            b.SpriteObject("CastleWindow", x + 0.5f, 6.6f, -7);
        }

        int[] torches = { 6, 14, 20, 32, 37, 46, 54, 60, 71, 77, 106, 110, 119, 128, 137, 146, 151, 157, 163, 171, 180, 188, 198 };

        foreach (int x in torches) {
            b.AnimatedDecoration(x, 3.5f, new[] { "Torch1", "Torch2" }, 0.12f, -3);
        }

        int[] chains = { 8, 15, 27, 43, 61, 76, 92, 108, 126, 149, 166, 184, 199 };

        foreach (int x in chains) {
            b.SpriteObject("Chain", x + 0.5f, 8.4f, -6);
        }

        // columnas del fondo
        for (int x = 2; x < 204; x += 19) {
            b.SpriteObject("CastleBrick", x + 0.5f, 5f, -9, false, true, 1f, 9f);
        }

        b.DeathBarrier(-6f);
        b.SpawnPlayer(3, 0);
    }

}
