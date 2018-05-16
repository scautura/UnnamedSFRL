using System;
using Microsoft.Xna.Framework;
using UnnamedSFRL.Entities;

namespace UnnamedSFRL.Screens
{
    public class Adventure: SadConsole.Screen
    {
        private Map map;

        public Entities.Player Player;
        public Dungeon DungeonScreen;

        public Map Map { get { return map; } }

        public Point MapViewPoint
        {
            get { return DungeonScreen.MapViewPoint; }
            set
            {
                DungeonScreen.MapViewPoint = value;
                SyncEntityOffset();
            }
        }

        public Adventure()
        {
            DungeonScreen=new Dungeon(0,0,Program.ScreenWidth, Program.ScreenHeight);

            Children.Add(DungeonScreen);
        }

        public void LoadMap(Map map)
        {
            if (this.map != null)
                map.Entities.CollectionChanged -= Entities_CollectionChanged;

            DungeonScreen.LoadMap(map);

            map.Entities.CollectionChanged += Entities_CollectionChanged;

            this.map = map;
        }

        private void Entities_CollectionChanged(object sender,
            System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                    foreach (var item in e.NewItems)
                        DungeonScreen.Children.Add((EntityBase) item);
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
                    foreach (var item in e.OldItems)
                        DungeonScreen.Children.Remove((EntityBase) item);
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Reset:
                    DungeonScreen.Children.Clear();
                    break;
                default:
                    break;
            }

            SyncEntityOffset();
        }

        private void SyncEntityOffset()
        {
            foreach (var item in map.Entities)
            {
                item.PositionOffset = new Point(-DungeonScreen.MapViewPoint.X, -DungeonScreen.MapViewPoint.Y);
            }
        }

        public override void Update(TimeSpan timeElapsed)
        {
            base.Update(timeElapsed);

            if (SadConsole.Global.KeyboardState.IsKeyPressed(Microsoft.Xna.Framework.Input.Keys.Left))
                Player.MoveBy(new Point(-1, 0), map);

            if (SadConsole.Global.KeyboardState.IsKeyPressed(Microsoft.Xna.Framework.Input.Keys.Right))
                Player.MoveBy(new Point(1, 0), map);

            if (SadConsole.Global.KeyboardState.IsKeyPressed(Microsoft.Xna.Framework.Input.Keys.Up))
                Player.MoveBy(new Point(0, -1), map);

            if (SadConsole.Global.KeyboardState.IsKeyPressed(Microsoft.Xna.Framework.Input.Keys.Down))
                Player.MoveBy(new Point(0, 1), map);
        }
    }
}