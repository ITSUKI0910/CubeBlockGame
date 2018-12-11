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
    /// 
    ///面クラスをnewして配列で管理して
    ///配列の一部を消して後ろからそこに持ってきて
    ///もってきた数字に対して配列番号から割り出す
    ///
    ///面クラスを座標で管理
    ///面クラスは点データと面データを持ち
    ///面データに関しては生成と同時に配列番号を割り当てて
    ///全て足しても壊れないようにする
    ///
    ///プレートで行こうかな
    //class FrontPlate : Plate
    //{
    //    public FrontPlate(int X, int Y, int Z, int W)
    //    {
    //        vertices[0] = new VertexPositionTexture(new Vector3(X, Y + 1, Z), Vector2.Zero);
    //        vertices[1] = new VertexPositionTexture(new Vector3(X, Y + 1, Z + 1), new Vector2(0.16f, 0));
    //        vertices[2] = new VertexPositionTexture(new Vector3(X, Y, Z), Vector2.UnitY);
    //        vertices[3] = new VertexPositionTexture(new Vector3(X, Y, Z + 1), new Vector2(0.16f, 1));
    //        indices[0] = W + 2;
    //        indices[1] = W + 1;
    //        indices[2] = W + 3;
    //        indices[3] = W + 2;
    //        indices[4] = W + 0;
    //        indices[5] = W + 1;
    //    }
    //}
    //class RightPlate : Plate
    //{
    //    public RightPlate(int X, int Y, int Z, int W)
    //    {
    //        vertices[0] = new VertexPositionTexture(new Vector3(X, Y + 1, Z + 1), new Vector2(0.17f, 0));//6
    //        vertices[1] = new VertexPositionTexture(new Vector3(X + 1, Y + 1, Z + 1), new Vector2(0.33f, 0));//8
    //        vertices[2] = new VertexPositionTexture(new Vector3(X, Y, Z + 1), new Vector2(0.17f, 1));//2
    //        vertices[3] = new VertexPositionTexture(new Vector3(X + 1, Y, Z + 1), new Vector2(0.33f, 1));//4
    //        indices[0] = W + 2;
    //        indices[1] = W + 1;
    //        indices[2] = W + 3;
    //        indices[3] = W + 2;
    //        indices[4] = W + 0;
    //        indices[5] = W + 1;
    //    }
    //}
    //class BackPlate : Plate
    //{
    //    public BackPlate(int X, int Y, int Z, int W)
    //    {
    //        vertices[0] = new VertexPositionTexture(new Vector3(X + 1, Y + 1, Z + 1), new Vector2(0.3333f, 0));//8
    //        vertices[1] = new VertexPositionTexture(new Vector3(X + 1, Y + 1, Z), new Vector2(0.50f, 0));//7
    //        vertices[2] = new VertexPositionTexture(new Vector3(X + 1, Y, Z + 1), new Vector2(0.3333f, 1));//4
    //        vertices[3] = new VertexPositionTexture(new Vector3(X + 1, Y, Z), new Vector2(0.50f, 1));//3
    //        indices[0] = W + 2;
    //        indices[1] = W + 1;
    //        indices[2] = W + 3;
    //        indices[3] = W + 2;
    //        indices[4] = W + 0;
    //        indices[5] = W + 1;
    //    }
    //}
    //class LeftPlate : Plate
    //{
    //    public LeftPlate(int X, int Y, int Z, int W)
    //    {
    //        vertices[0] = new VertexPositionTexture(new Vector3(X + 1, Y + 1, Z), new Vector2(0.50f, 0));//7
    //        vertices[1] = new VertexPositionTexture(new Vector3(X, Y + 1, Z), new Vector2(0.66f, 0));//5
    //        vertices[2] = new VertexPositionTexture(new Vector3(X + 1, Y, Z), new Vector2(0.50f, 1));//3
    //        vertices[3] = new VertexPositionTexture(new Vector3(X, Y, Z), new Vector2(0.66f, 1));//1
    //        indices[0] = W + 2;
    //        indices[1] = W + 1;
    //        indices[2] = W + 3;
    //        indices[3] = W + 2;
    //        indices[4] = W + 0;
    //        indices[5] = W + 1;
    //    }
    //}
    //class UpPlate : Plate
    //{
    //    public UpPlate(int X, int Y, int Z, int W)
    //    {
    //        vertices[0] = new VertexPositionTexture(new Vector3(X + 1, Y + 1, Z), new Vector2(0.67f, 0));//7
    //        vertices[1] = new VertexPositionTexture(new Vector3(X + 1, Y + 1, Z + 1), new Vector2(0.83f, 0));//8
    //        vertices[2] = new VertexPositionTexture(new Vector3(X, Y + 1, Z), new Vector2(0.67f, 1));//5
    //        vertices[3] = new VertexPositionTexture(new Vector3(X, Y + 1, Z + 1), new Vector2(0.83f, 1));//6
    //        indices[0] = W + 2;
    //        indices[1] = W + 1;
    //        indices[2] = W + 3;
    //        indices[3] = W + 2;
    //        indices[4] = W + 0;
    //        indices[5] = W + 1;
    //    }
    //}
    //class DownPlate : Plate
    //{
    //    public DownPlate(int X, int Y, int Z, int W)
    //    {
    //        vertices[0] = new VertexPositionTexture(new Vector3(X, Y, Z + 1), new Vector2(0.84f, 1));//2
    //        vertices[1] = new VertexPositionTexture(new Vector3(X + 1, Y, Z + 1), new Vector2(0.84f, 0));//4
    //        vertices[2] = new VertexPositionTexture(new Vector3(X, Y, Z), new Vector2(0.99f, 1));//1
    //        vertices[3] = new VertexPositionTexture(new Vector3(X + 1, Y, Z), new Vector2(0.99f, 0));//3
    //        indices[0] = W + 2;
    //        indices[1] = W + 1;
    //        indices[2] = W + 3;
    //        indices[3] = W + 2;
    //        indices[4] = W + 0;
    //        indices[5] = W + 1;
    //    }
    //}
    /// <summary>
    /// やばい
    /// 点がだるい
    /// </summary>
    class Plate
    {
        protected VertexPositionTexture[] vertices = new VertexPositionTexture[4];
        protected int[] indices = new int[6];
        public VertexPositionTexture[] GetVertices()
        {
            return vertices;
        }
        public int[] GetIndices()
        {
            return indices;
        }
    }
    class Chank
    {
        /// <summary>
        /// ブロックリスト
        /// 点データ
        /// 面データ
        /// 
        /// 理想
        /// ブロックを消せと言われたら
        /// その座標で登録したやつを消す
        /// 消すと面データがずれる
        /// 
        /// 配列だったら
        /// 点配列[]
        /// 面配列[]を用意
        /// 
        /// ただ配列だとうまくいかないのでリスト使おうかな
        /// 
        /// XYZで何番目のやつなのかを登録して
        /// その部分を消した後
        /// 後ろのやつを消す
        /// </summary>
        private Dictionary<IVector3, int> blockList;
        //private SortedDictionary<IVector4, Plate> drawplate = new SortedDictionary<IVector4, Plate>();
        //private SortedDictionary<IVector4, VertexPositionTexture> drawNumber = new SortedDictionary<IVector, VertexPositionTexture>();




        /// <summary>
        /// 追加と削除を用意にすることにより
        /// 簡単に処理が出来る
        /// 
        /// 点を消すと
        /// インデックスがずれる
        /// ならば
        /// 点を消しても
        /// インデックスがずれない作りにする
        /// 方が簡単なのでは
        /// 
        /// 
        /// XYZW
        /// そのブロックの座標と何番目の面なのか
        /// 点を消す代わりに後ろから持ってくる
        /// 後ろを消す
        /// インデックスも後ろの６個を消す
        /// </summary>

        private Dictionary<IVector4, int> vertices_Number = new Dictionary<IVector4, int>();
        private List<VertexPositionTexture> vertices_list = new List<VertexPositionTexture>();
        private List<int> indices_list = new List<int>();
        private VertexPositionTexture[] vertices_Arry;
        private int[] indices_Arry;
        ///座標とどの面なのかがわかる
        public void Add(int X, int Y, int Z, int number)
        {
            bool drawflag = false;
            switch (number)
            {
                case 1://正面
                    vertices_list.Add(new VertexPositionTexture(new Vector3(X, Y + 1, Z), Vector2.Zero));
                    vertices_list.Add(new VertexPositionTexture(new Vector3(X, Y + 1, Z + 1), new Vector2(0.16f, 0)));
                    vertices_list.Add(new VertexPositionTexture(new Vector3(X, Y, Z), Vector2.UnitY));
                    vertices_list.Add(new VertexPositionTexture(new Vector3(X, Y, Z + 1), new Vector2(0.16f, 1)));
                    drawflag = true;
                    break;
                case 2://右
                    vertices_list.Add(new VertexPositionTexture(new Vector3(X, Y + 1, Z + 1), new Vector2(0.17f, 0)));//6
                    vertices_list.Add(new VertexPositionTexture(new Vector3(X + 1, Y + 1, Z + 1), new Vector2(0.33f, 0)));//8
                    vertices_list.Add(new VertexPositionTexture(new Vector3(X, Y, Z + 1), new Vector2(0.17f, 1)));//2
                    vertices_list.Add(new VertexPositionTexture(new Vector3(X + 1, Y, Z + 1), new Vector2(0.33f, 1)));//4
                    drawflag = true;
                    break;
                case 3://後ろ
                    vertices_list.Add(new VertexPositionTexture(new Vector3(X + 1, Y + 1, Z + 1), new Vector2(0.3333f, 0)));//8
                    vertices_list.Add(new VertexPositionTexture(new Vector3(X + 1, Y + 1, Z), new Vector2(0.50f, 0)));//7
                    vertices_list.Add(new VertexPositionTexture(new Vector3(X + 1, Y, Z + 1), new Vector2(0.3333f, 1)));//4
                    vertices_list.Add(new VertexPositionTexture(new Vector3(X + 1, Y, Z), new Vector2(0.50f, 1)));//3
                    drawflag = true;
                    break;
                case 4://左
                    vertices_list.Add(new VertexPositionTexture(new Vector3(X + 1, Y + 1, Z), new Vector2(0.50f, 0)));//7
                    vertices_list.Add(new VertexPositionTexture(new Vector3(X, Y + 1, Z), new Vector2(0.66f, 0)));//5
                    vertices_list.Add(new VertexPositionTexture(new Vector3(X + 1, Y, Z), new Vector2(0.50f, 1)));//3
                    vertices_list.Add(new VertexPositionTexture(new Vector3(X, Y, Z), new Vector2(0.66f, 1)));//1
                    drawflag = true;
                    break;
                case 5://上
                    vertices_list.Add(new VertexPositionTexture(new Vector3(X + 1, Y + 1, Z), new Vector2(0.67f, 0)));//7
                    vertices_list.Add(new VertexPositionTexture(new Vector3(X + 1, Y + 1, Z + 1), new Vector2(0.83f, 0)));//8
                    vertices_list.Add(new VertexPositionTexture(new Vector3(X, Y + 1, Z), new Vector2(0.67f, 1)));//5
                    vertices_list.Add(new VertexPositionTexture(new Vector3(X, Y + 1, Z + 1), new Vector2(0.83f, 1)));//6
                    drawflag = true;
                    break;
                case 6://下
                    vertices_list.Add(new VertexPositionTexture(new Vector3(X, Y, Z + 1), new Vector2(0.84f, 1)));//2
                    vertices_list.Add(new VertexPositionTexture(new Vector3(X + 1, Y, Z + 1), new Vector2(0.84f, 0)));//4
                    vertices_list.Add(new VertexPositionTexture(new Vector3(X, Y, Z), new Vector2(0.99f, 1)));//1
                    vertices_list.Add(new VertexPositionTexture(new Vector3(X + 1, Y, Z), new Vector2(0.99f, 0)));//3
                    drawflag = true;
                    break;
            }
            if (drawflag)
            {
                //なぜかvertices_listと同じ数字を持っている
                int W = 4 * vertices_Number.Count;
                vertices_Number.Add(new IVector4(X, Y, Z, number), W);
                indices_list.Add(W + 2);
                indices_list.Add(W + 1);
                indices_list.Add(W + 3);
                indices_list.Add(W + 2);
                indices_list.Add(W + 0);
                indices_list.Add(W + 1);
            }
        }
        public void Initialize(Dictionary<IVector3, int> _blocklist)
        {
            blockList = _blocklist;
            //vertices_Number.Remove(vertices_Number.Last().Key);
            vertices_Arry = vertices_list.ToArray();
            indices_Arry = indices_list.ToArray();
        }
        public void BreakBlock(int X,int Y,int Z)
        {
            ///XYZのブロックを消す
            /// そのブロックの座標と何番目の面なのか
            /// 点を消す代わりに後ろから持ってくる
            /// 後ろを消す
            /// インデックスも後ろの６個を消す
            /// うまくいかない
            for (int i = 1; i < 7; i++)
            {
                ///これが消そうとする面の座標
                if (vertices_Number.ContainsKey(new IVector4(X, Y, Z, i)))
                {
                    //if (i != 3 && i != 2&& i != 1) return;
                    //何番目の点なのかを確認
                    if(vertices_Number.Last().Key== new IVector4(X, Y, Z, i))
                    {
                        int aa = vertices_list.Count();
                        vertices_list.RemoveAt(aa - 1);
                        vertices_list.RemoveAt(aa - 2);
                        vertices_list.RemoveAt(aa - 3);
                        vertices_list.RemoveAt(aa - 4);
                        aa = indices_list.Count;
                        indices_list.RemoveAt(aa - 1);
                        indices_list.RemoveAt(aa - 2);
                        indices_list.RemoveAt(aa - 3);
                        indices_list.RemoveAt(aa - 4);
                        indices_list.RemoveAt(aa - 5);
                        indices_list.RemoveAt(aa - 6);
                        vertices_Number.Remove(vertices_Number.Last().Key);
                    }
                    else
                    {

                    }
                    //int number = vertices_Number[new IVector4(X, Y, Z, i)];
                    ////一番後ろから移動させてRemoveする

                    //vertices_list[number + 3] = vertices_list.Last();
                    //vertices_list.RemoveAt(vertices_list.Count() - 1);

                    //vertices_list[number + 2] = vertices_list.Last();
                    //vertices_list.RemoveAt(vertices_list.Count() - 1);

                    //vertices_list[number + 1] = vertices_list.Last();
                    //vertices_list.RemoveAt(vertices_list.Count() - 1);

                    //vertices_list[number] = vertices_list.Last();
                    //vertices_list.RemoveAt(vertices_list.Count() - 1);

                    //何番目の点の番号だけを一番最後のやつに移して
                    //何番目の点の配列をremoveする
                    //indices_list.RemoveAt(indices_list.Count - 1);
                    //indices_list.RemoveAt(indices_list.Count - 1);
                    //indices_list.RemoveAt(indices_list.Count - 1);
                    //indices_list.RemoveAt(indices_list.Count - 1);
                    //indices_list.RemoveAt(indices_list.Count - 1);
                    //indices_list.RemoveAt(indices_list.Count - 1);
                    //同じじゃない
                    //if (new IVector4(X, Y, Z, i) == vertices_Number.Last().Key) return;
                    //あとでここのラストキーを調べる
                    //if(vertices_Number[vertices_Number.Last().Key]> number)
                    //{
                    //vertices_Number[vertices_Number.Last().Key] = number;
                    //vertices_Number.Remove(new IVector4(X, Y, Z, i));
                    // }
                    //else
                    //{
                    //    vertices_Number[new IVector4(X, Y, Z, i)] = vertices_Number.Last().Value;
                    //    vertices_Number.Remove(vertices_Number.Last().Key);
                    //}
                    //iが3のとき最後のきーが５
                    vertices_Arry = vertices_list.ToArray();
                    indices_Arry = indices_list.ToArray();
                    
                }
            }

        }
        public void Draw(GraphicsDevice graphicsDevice)
        {
            graphicsDevice.DrawUserIndexedPrimitives(
                PrimitiveType.TriangleList,
                vertices_Arry,
                0,
                vertices_Arry.Length,
                indices_Arry,
                0,
                indices_Arry.Length / 3);

        }
    }
}