using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game3
{
    class CreateBlockDate
    {
        //チャンクごとに入れる
        //チャンクの番号とチャンク分の座標とブロックデータ
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
            int x, y;
            foreach (IVector2 _list in ChankList)
            {
                for (y = 0; y < 64; y++)
                {
                    for (x = 0; x < 16; x++)
                    {
                        blockList.Add(new IVector3(x + _list.X, y, 0 + _list.Y), 1);
                        blockList.Add(new IVector3(x + _list.X, y, 1 + _list.Y), 1);
                        blockList.Add(new IVector3(x + _list.X, y, 2 + _list.Y), 1);
                        blockList.Add(new IVector3(x + _list.X, y, 3 + _list.Y), 1);
                        blockList.Add(new IVector3(x + _list.X, y, 4 + _list.Y), 1);
                        blockList.Add(new IVector3(x + _list.X, y, 5 + _list.Y), 1);
                        blockList.Add(new IVector3(x + _list.X, y, 6 + _list.Y), 1);
                        blockList.Add(new IVector3(x + _list.X, y, 7 + _list.Y), 1);
                        blockList.Add(new IVector3(x + _list.X, y, 8 + _list.Y), 1);
                        blockList.Add(new IVector3(x + _list.X, y, 9 + _list.Y), 1);
                        blockList.Add(new IVector3(x + _list.X, y, 10 + _list.Y), 1);
                        blockList.Add(new IVector3(x + _list.X, y, 11 + _list.Y), 1);
                        blockList.Add(new IVector3(x + _list.X, y, 12 + _list.Y), 1);
                        blockList.Add(new IVector3(x + _list.X, y, 13 + _list.Y), 1);
                        blockList.Add(new IVector3(x + _list.X, y, 14 + _list.Y), 1);
                        blockList.Add(new IVector3(x + _list.X, y, 15 + _list.Y), 1);
                    }
                }

            }
        }
        public ref Dictionary<IVector3, int> GetBlockDate()
        {
            return ref blockList;
        }
        public ref List<IVector2> chank()
        {
            return ref ChankList;
        }
    }
}
