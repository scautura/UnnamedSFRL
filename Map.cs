using System.Collections.ObjectModel;
using GoRogue.MapViews;

namespace UnnamedSFRL
{
    public class Map
    {
        public int Width { get; private set; }
        public int Height { get; private set; }

        public ObservableCollection<Entities.EntityBase> Entities;

        public MapObjects.TileBase[] Tiles {
            get
            {
                MapObjects.TileBase[] tileCells = new MapObjects.TileBase[Width * Height];
                for (int x = 0; x < Width; x++)
                {
                    for (int y = 0; y < Height; y++)
                    {
                        tileCells[y * Width + x] = TileMap[x, y];
                    }
                }

                return tileCells;
            }
        }

        public ArrayMap<MapObjects.TileBase> TileMap;

        public Map(int width, int height)
        {
            Width = width;
            Height = height;

            TileMap = new ArrayMap<MapObjects.TileBase>(width, height);

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    TileMap[x, y] = new MapObjects.Floor();
                }
            }



            TileMap[5, 5] = new MapObjects.Wall();
            TileMap[2, 5] = new MapObjects.Wall();
            TileMap[10, 29] = new MapObjects.Wall();
            TileMap[17, 44] = new MapObjects.Wall();

            Entities = new ObservableCollection<Entities.EntityBase>();
        }

        public bool IsTileWalkable(int x, int y)
        {
            if (x < 0 || y < 0 || x >= Width || y >= Height)
                return false;

            return !TileMap[x, y].IsBlockingMove;
        }

        public MapObjects.TileBase[] TileCells()
        {
            MapObjects.TileBase[] tileCells = new MapObjects.TileBase[Width * Height];
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    tileCells[y * Width + x] = TileMap[x, y];
                }
            }

            return tileCells;
        }
    }
}