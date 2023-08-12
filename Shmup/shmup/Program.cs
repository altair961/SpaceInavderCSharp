using System;
using SFML.Graphics;
using SFML.Window;

namespace shmup
{
    class Program
    {
        const int WIDTH = 640;
        const int HEIGHT = 480;
        const string TITLE = "SHMUP";
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            VideoMode mode = new VideoMode(WIDTH, HEIGHT);
            RenderWindow window = new RenderWindow(mode, TITLE);
            window.SetVerticalSyncEnabled(true);
            window.Closed += (sender, args) => window.Close();


            while (window.IsOpen)
            {
                window.DispatchEvents();
                window.Clear(Color.Blue);
                window.Display();
            }

        }
    }
}

