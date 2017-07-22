using Assets.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Assets.Classes
{
    class GridMap : IMap
    {
        Dictionary<int, Dictionary<int, ITile>> tiles = new Dictionary<int, Dictionary<int, ITile>>();

        class TileInternal : ITile
        {
            public int X
            {
                get;
                set;
            }

            public int Y
            {
                get;
                set;
            }
            public int Height
            {
                get;
                set;
            }
            public TileInternal(int x, int y, int height)
            {
                this.X = x;
                this.Y = y;
                this.Height = height;
            }
        }
        
        public GridMap(int sizeX, int sizeY)
        {
            for (int i = 0; i < sizeX; i++)
            {
                var dict = new Dictionary<int, ITile>();
                for (int j = 0; i < sizeY; j++)
                {
                    dict.Add(j, new TileInternal(i, j, 4));
                }
                tiles.Add(i, dict);
            }
        }

        public bool canUnitPassTile(int x, int y, ICharacter character)
        {
            return tiles[x][y].Height > character.ClimbingFactor;
        }

    }
}
