using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game3
{
    class CreateBlockDate
    {
        private Dictionary<IVector3, int> blockList = new Dictionary<IVector3, int>();
        private List<IVector2> ChankList = new List<IVector2>();
        public CreateBlockDate()
        {
            ///5*5のチャンクを生成する
            for (int X = -16; X < 16; X += 16)
            {
                for (int Z = -16; Z < 16; Z += 16)
                {
                    ChankList.Add(new IVector2(X, Z));
                }
            }
            int x, y, z;
            foreach (var list in ChankList)
            {
                for (y = 0; y < 64; y++)
                {
                    for (x = 0; x < 16; x++)
                    {
                        blockList.Add(new IVector3(x + list.X, y, 0 + list.Y), 1);
                        blockList.Add(new IVector3(x + list.X, y, 1 + list.Y), 1);
                        blockList.Add(new IVector3(x + list.X, y, 2 + list.Y), 1);
                        blockList.Add(new IVector3(x + list.X, y, 3 + list.Y), 1);
                        blockList.Add(new IVector3(x + list.X, y, 4 + list.Y), 1);
                        blockList.Add(new IVector3(x + list.X, y, 5 + list.Y), 1);
                        blockList.Add(new IVector3(x + list.X, y, 6 + list.Y), 1);
                        blockList.Add(new IVector3(x + list.X, y, 7 + list.Y), 1);
                        blockList.Add(new IVector3(x + list.X, y, 8 + list.Y), 1);
                        blockList.Add(new IVector3(x + list.X, y, 9 + list.Y), 1);
                        blockList.Add(new IVector3(x + list.X, y, 10 + list.Y), 1);
                        blockList.Add(new IVector3(x + list.X, y, 11 + list.Y), 1);
                        blockList.Add(new IVector3(x + list.X, y, 12 + list.Y), 1);
                        blockList.Add(new IVector3(x + list.X, y, 13 + list.Y), 1);
                        blockList.Add(new IVector3(x + list.X, y, 14 + list.Y), 1);
                        blockList.Add(new IVector3(x + list.X, y, 15 + list.Y), 1);
                    }
                }
            }
        }
        public Dictionary<IVector3, int> GetBlockDate()
        {
            return blockList;
        }
        public List<IVector2> GetChankDate()
        {
            return ChankList;
        }
    }
}
