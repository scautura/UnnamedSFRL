using System.Collections.ObjectModel;

namespace UnnamedSFRL
{
    public class Map
    {
        public int Width { get; private set; }
        public int Height { get; private set; }

        public ObservableCollection<Entities.EntityBase> Entities;

        public MapObjects.TileBase[] Tiles;

        public Map(int width, int height)
        {
            Width = width;
            Height = height;

            Tiles = new MapObjects.TileBase[width * height];

            for (int i = 0; i < Tiles.Length; i++)
                Tiles[i] = new MapObjects.Floor();

            Tiles[5 * Width + 5] = new MapObjects.Wall();
            Tiles[2 * Width + 5] = new MapObjects.Wall();
            Tiles[10 * Width + 29] = new MapObjects.Wall();
            Tiles[17 * Width + 44] = new MapObjects.Wall();

            Entities = new ObservableCollection<Entities.EntityBase>();
        }

        public bool IsTileWalkable(int x, int y)
        {
            if (x < 0 || y < 0 || x >= Width || y >= Height)
                return false;

            return !Tiles[y * Width + x].IsBlockingMove;
        }
    }
}