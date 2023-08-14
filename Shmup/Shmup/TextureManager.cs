using SFML.Graphics;

namespace Shmup
{
    public class TextureManager
    {
        private static string ASSETS_PATH = "Graphics/";
        static Texture playerTexture;
        static Texture enemyTexture;
        static Texture backgroundTexture;

        public static Texture PlayerTexture { get { return playerTexture; } }
        public static Texture EnemyTexture { get { return enemyTexture; } }
        public static Texture BackgroundTexture { get { return backgroundTexture; } }

        public static void LoadTexture()
        {
            playerTexture = new Texture(ASSETS_PATH + "player.png");
            enemyTexture = new Texture(ASSETS_PATH + "enemy.png");
            backgroundTexture = new Texture(ASSETS_PATH + "background.png");
        }

    }
}
