﻿using System;
using Microsoft.Xna.Framework;
using SadConsole.Renderers;
using SadConsole.Surfaces;

namespace UnnamedSFRL.Screens
{
    public class Dungeon: SadConsole.Screen
    {
        private SurfaceRenderer renderer=new SurfaceRenderer();
        private BasicSurface surface;
        private SadConsole.DrawCallSurface drawCall;

        public Point MapViewPoint {  get { return surface.RenderArea.Location; } set
            {
                surface.RenderArea = new Rectangle(value, new Point(Width, Height));
            } }

        public int Width { get; private set; }
        public int Height { get; private set; }

        public Dungeon(int screenX, int screenY, int screenWidth, int screenHeight)
        {
            Position = new Point(screenX, screenY);
            Width = screenWidth;
            Height = screenHeight;
        }

        public void LoadMap(Map map)
        {
            surface = new BasicSurface(map.Width, map.Height, map.Tiles, SadConsole.Global.FontDefault,
                new Rectangle(0, 0, Width, Height));
            drawCall = new SadConsole.DrawCallSurface(surface, position, false);
        }

        public override void Draw(TimeSpan timeElapsed)
        {
            renderer.Render(surface);
            SadConsole.Global.DrawCalls.Add(drawCall);

            base.Draw(timeElapsed);
        }
    }
}