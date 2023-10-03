namespace Level41;

public class Map2D
{
    private readonly TileType[,] _tiles;

    public Map2D()
    {
        _tiles = new TileType[,]
        {
            { TileType.Water, TileType.Water, TileType.Grass, TileType.Grass },
            { TileType.Water, TileType.Grass, TileType.Grass, TileType.Grass },
            { TileType.Forest, TileType.Forest, TileType.Forest, TileType.Forest }
        };
    }

    public Map2D(int width, int height)
    {
        _tiles = new TileType[height, width];
    }

    public TileType this[int x, int y]
    {
        get
        {
            if (x >= Width || y >= Height)
                throw new IndexOutOfRangeException();

            return _tiles[y, x];
        }
        set
        {
            if (x >= Width || y >= Height)
                throw new IndexOutOfRangeException();

            _tiles[y, x] = value;
        }
    }

    public int Width => _tiles.GetLength(1);
    public int Height => _tiles.GetLength(0);
}

public enum TileType
{
    Grass,
    Water,
    Forest,
    Mountain
}