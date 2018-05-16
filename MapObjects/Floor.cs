using Microsoft.Xna.Framework;

namespace UnnamedSFRL.MapObjects
{
    public class Floor: TileBase
    {
        public Floor() : base(new Color(25, 25, 25), Color.Black, 46)
        {
            IsBlockingLOS = false;
            IsBlockingMove = false;
        }
    }
}