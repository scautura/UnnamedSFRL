using Microsoft.Xna.Framework;

namespace UnnamedSFRL.Entities
{
    public class EntityBase: SadConsole.GameHelpers.GameObject
    {
        public EntityBase(Color foreground, Color background, int glyph) : base(1, 1)
        {
            Animation.CurrentFrame[0].Foreground = foreground;
            Animation.CurrentFrame[0].Background = background;
            Animation.CurrentFrame[0].Glyph = glyph;
        }

        public void MoveBy(Point change, Map map)
        {
            var newPosition = Position + change;

            if (map.IsTileWalkable(newPosition.X, newPosition.Y))
                Position = newPosition;
        }
    }
}