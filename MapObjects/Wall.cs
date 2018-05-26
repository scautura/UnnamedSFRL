using Microsoft.Xna.Framework;

namespace UnnamedSFRL.MapObjects
{
    public class Wall: TileBase
    {
        public Wall() : base(Color.White, Color.Gray, 176)
        {
            IsBlockingLOS = true;
            IsBlockingMove = true;
        }
    }
}