using SFML.Graphics;
using SFML.Window;

namespace Shmup
{
    public class Game
    {
        private const int WIDTH = 640;
        private const int HEIGHT = 480;
        private const string TITLE = "SHMUP";
        private RenderWindow window;
        private VideoMode mode = new VideoMode(WIDTH, HEIGHT);
        Sprite background;
        Player player;
        
        public Game()
        {
            this.window = new RenderWindow(this.mode, TITLE);
            this.window.SetVerticalSyncEnabled(true);
            this.window.Closed += (sender, args) => {
                this.window.Close();
            };

            TextureManager.LoadTexture();
            background = new Sprite();
            background.Texture = TextureManager.BackgroundTexture;
            player = new Player();
        }

        public void run()
        {
            while (this.window.IsOpen)
            {
                this.handleEvents();
                this.update();
                this.draw();
            }
        }

        private void handleEvents()
        {
            this.window.DispatchEvents();
        }

        private void update()
        {
            player.update();
        }

        private void draw()
        {
            this.window.Clear(Color.Blue);
            this.window.Draw(this.background);
            player.draw(this.window);
            this.window.Display();
        }
    }
}