using Microsoft.Xna.Framework;
using SadConsole;

namespace UnnamedSFRL.MapObjects
{
    public class TileBase: Cell
    {
        public bool IsBlockingMove;
        public bool IsBlockingLOS;

        public TileBase(Color foreground, Color background, int glyph) : base(foreground, background, glyph)
        {
            
        }
    }
}