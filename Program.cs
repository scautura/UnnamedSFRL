using Microsoft.Xna.Framework;
using Console = SadConsole.Console;

namespace UnnamedSFRL
{
    class Program
    {

        public const int ScreenWidth = 80;
        public const int ScreenHeight = 50;

        public static Screens.Adventure AdventureScreen;

        private static void Main()
        {
            // Setup the engine and creat the main window.
            SadConsole.Game.Create("C64.font", ScreenWidth, ScreenHeight);

            // Hook the start event so we can add consoles to the system.
            SadConsole.Game.OnInitialize = Init;

            // Hook the update event that happens each frame so we can trap keys and respond.
            SadConsole.Game.OnUpdate = Update;

            // Start the game.
            SadConsole.Game.Instance.Run();

            //
            // Code here will not run until the game window closes.
            //

            SadConsole.Game.Instance.Dispose();
        }

        private static void Update(GameTime time)
        {
            // Called each logic update.

            // As an example, we'll use the F5 key to make the game full screen
            if (SadConsole.Global.KeyboardState.IsKeyReleased(Microsoft.Xna.Framework.Input.Keys.F5))
            {
                SadConsole.Settings.ToggleFullScreen();
            }
            else if (SadConsole.Global.KeyboardState.IsKeyReleased(Microsoft.Xna.Framework.Input.Keys.Escape))
            {
                SadConsole.Game.Instance.Exit();
            }
        }

        private static void Init()
        {
            AdventureScreen = new Screens.Adventure();
            AdventureScreen.LoadMap(new Map(100, 100));
            AdventureScreen.Player = new Entities.Player
            {
                Position = new Point(13, 7)
            };
            AdventureScreen.Map.Entities.Add(AdventureScreen.Player);

            SadConsole.Global.CurrentScreen.Children.Add(AdventureScreen);
        }
    }
}
