using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game3
{
    /// ブロックデータ
    /// 点データ
    /// 面データ
    class Chank
    {
        private Dictionary<IVector3, int> blockList;
        private List<VertexPositionTexture> vertices_list = new List<VertexPositionTexture>();
        private List<int> indices_list = new List<int>();
        //private VertexPositionTexture[] vertices;
        //private int[] indices;
        public Chank()
        {

        }
        public void Initialize(Dictionary<IVector3, int> _blocklist)
        {
            blockList = _blocklist;
        }
        ///座標とどの面なのかがわかる
        public void Add(int X,int Y,int Z,int number)
        {
            int size = 0;
            switch (number)
            {
                case 1://正面
                    size = vertices_list.Count;
                    vertices_list.Add(new VertexPositionTexture(new Vector3(X, Y + 1, Z), Vector2.Zero));
                    vertices_list.Add(new VertexPositionTexture(new Vector3(X, Y + 1, Z + 1), new Vector2(0.16f,0)));
                    vertices_list.Add(new VertexPositionTexture(new Vector3(X, Y, Z), Vector2.UnitY));
                    vertices_list.Add(new VertexPositionTexture(new Vector3(X, Y, Z + 1), new Vector2(0.16f, 1)));
                    indices_list.Add(size + 2);
                    indices_list.Add(size + 1);
                    indices_list.Add(size + 3);
                    indices_list.Add(size + 2);
                    indices_list.Add(size + 0);
                    indices_list.Add(size + 1);
                    break;
                case 2://右
                    size = vertices_list.Count;
                    vertices_list.Add(new VertexPositionTexture(new Vector3(X, Y + 1, Z + 1), Vector2.Zero));//6
                    vertices_list.Add(new VertexPositionTexture(new Vector3(X + 1, Y + 1, Z + 1), Vector2.UnitX));//8
                    vertices_list.Add(new VertexPositionTexture(new Vector3(X, Y, Z + 1), Vector2.UnitY));//2
                    vertices_list.Add(new VertexPositionTexture(new Vector3(X + 1, Y, Z + 1), Vector2.One));//4
                    indices_list.Add(size + 2);
                    indices_list.Add(size + 1);
                    indices_list.Add(size + 3);
                    indices_list.Add(size + 2);
                    indices_list.Add(size + 0);
                    indices_list.Add(size + 1);
            break;
                case 3://後ろ
                    size = vertices_list.Count;
                    vertices_list.Add(new VertexPositionTexture(new Vector3(X + 1, Y + 1, Z + 1), Vector2.Zero));//8
                    vertices_list.Add(new VertexPositionTexture(new Vector3(X + 1, Y + 1, Z), Vector2.UnitX));//7
                    vertices_list.Add(new VertexPositionTexture(new Vector3(X + 1, Y, Z + 1), Vector2.UnitY));//4
                    vertices_list.Add(new VertexPositionTexture(new Vector3(X + 1, Y, Z), Vector2.One));//3
                    indices_list.Add(size + 2);
                    indices_list.Add(size + 1);
                    indices_list.Add(size + 3);
                    indices_list.Add(size + 2);
                    indices_list.Add(size + 0);
                    indices_list.Add(size + 1);
                    break;
                case 4://左
                    size = vertices_list.Count;
                    vertices_list.Add(new VertexPositionTexture(new Vector3(X + 1, Y + 1, Z), Vector2.Zero));//7
                    vertices_list.Add(new VertexPositionTexture(new Vector3(X, Y + 1, Z), Vector2.UnitX));//5
                    vertices_list.Add(new VertexPositionTexture(new Vector3(X + 1, Y, Z), Vector2.UnitY));//3
                    vertices_list.Add(new VertexPositionTexture(new Vector3(X, Y, Z), Vector2.One));//1
                    indices_list.Add(size + 2);
                    indices_list.Add(size + 1);
                    indices_list.Add(size + 3);
                    indices_list.Add(size + 2);
                    indices_list.Add(size + 0);
                    indices_list.Add(size + 1);
                    break;
                case 5://上
                    size = vertices_list.Count;
                    vertices_list.Add(new VertexPositionTexture(new Vector3(X + 1, Y + 1, Z), Vector2.Zero));//7
                    vertices_list.Add(new VertexPositionTexture(new Vector3(X + 1, Y + 1, Z + 1), Vector2.UnitX));//8
                    vertices_list.Add(new VertexPositionTexture(new Vector3(X, Y + 1, Z), Vector2.UnitY));//5
                    vertices_list.Add(new VertexPositionTexture(new Vector3(X, Y + 1, Z + 1), Vector2.One));//6
                    indices_list.Add(size + 2);
                    indices_list.Add(size + 1);
                    indices_list.Add(size + 3);
                    indices_list.Add(size + 2);
                    indices_list.Add(size + 0);
                    indices_list.Add(size + 1);
                    break;
                case 6://下
                    size = vertices_list.Count;
                    vertices_list.Add(new VertexPositionTexture(new Vector3(X, Y, Z + 1), Vector2.UnitX));//2
                    vertices_list.Add(new VertexPositionTexture(new Vector3(X + 1, Y, Z + 1), Vector2.One));//4
                    vertices_list.Add(new VertexPositionTexture(new Vector3(X, Y, Z), Vector2.Zero));//1
                    vertices_list.Add(new VertexPositionTexture(new Vector3(X + 1, Y, Z), Vector2.UnitY));//3
                    indices_list.Add(size + 2);
                    indices_list.Add(size + 1);
                    indices_list.Add(size + 3);
                    indices_list.Add(size + 2);
                    indices_list.Add(size + 0);
                    indices_list.Add(size + 1);
            break;
            }
        }
        public void Draw(GraphicsDevice graphicsDevice)
        {
                graphicsDevice.DrawUserIndexedPrimitives(
                    PrimitiveType.TriangleList,
                    vertices_list.ToArray(),
                    0,
                    vertices_list.Count,
                    indices_list.ToArray(),
                    0,
                    indices_list.Count / 3);
            
        }
    }
}




























    /// ブロックの本体

    /// 
    ///　入ってきたブロックデータを元に面と点データの作成をしなければいけない
    ///　ブロックデータから位置情報とブロック番号が手に入るから
    ///　それをブロッククラスに送って改造して貰って
    ///　配列に入れる
    /// 
    /// </summary>
        /// <summary>
        ///このチャンクの中にあるブロックの座標データとブロックの種類
        /// </summary>
        /// Dictionary<IVector3, int> block_date
