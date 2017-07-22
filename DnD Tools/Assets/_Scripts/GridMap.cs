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
        ITile[,] tiles;

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
            tiles = new ITile[sizeX,sizeY];
            for (int i = 0; i < sizeX; i++)
            {
                for (int j = 0; i < sizeY; j++)
                {
                    tiles[i, j] = new TileInternal(i, j, 0);
                }
            }
        }

        public bool canUnitPassTile(int x, int y, ICharacter character)
        {
            return tiles[x,y].Height > character.ClimbingFactor;
        }

        public IEnumerator<ITile> GetEnumerator()
        {
            for (int i = 0; i < tiles.GetLength(0); i++)
            {
                for (int j = 0; i < tiles.GetLength(1); j++)
                {
                    yield return tiles[i, j];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
