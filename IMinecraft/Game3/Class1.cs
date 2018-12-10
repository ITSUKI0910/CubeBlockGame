//using Microsoft.Xna.Framework;
//using Microsoft.Xna.Framework.Graphics;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Game3
//{
//    /// ブロックデータ
//    /// 点データ
//    /// 面データ
//    /// 
//    ///面クラスをnewして配列で管理して
//    ///配列の一部を消して後ろからそこに持ってきて
//    ///もってきた数字に対して配列番号から割り出す
//    ///
//    ///面クラスを座標で管理
//    ///面クラスは点データと面データを持ち
//    ///面データに関しては生成と同時に配列番号を割り当てて
//    ///全て足しても壊れないようにする
//    ///
//    ///プレートで行こうかな
//    class FrontPlate : Plate
//    {
//        public FrontPlate(int X, int Y, int Z, int W)
//        {
//            vertices[0] = new VertexPositionTexture(new Vector3(X, Y + 1, Z), Vector2.Zero);
//            vertices[1] = new VertexPositionTexture(new Vector3(X, Y + 1, Z + 1), new Vector2(0.16f, 0));
//            vertices[2] = new VertexPositionTexture(new Vector3(X, Y, Z), Vector2.UnitY);
//            vertices[3] = new VertexPositionTexture(new Vector3(X, Y, Z + 1), new Vector2(0.16f, 1));
//            indices[0] = W + 2;
//            indices[1] = W + 1;
//            indices[2] = W + 3;
//            indices[3] = W + 2;
//            indices[4] = W + 0;
//            indices[5] = W + 1;
//        }
//    }
//    class RightPlate : Plate
//    {
//        public RightPlate(int X, int Y, int Z, int W)
//        {
//            vertices[0] = new VertexPositionTexture(new Vector3(X, Y + 1, Z + 1), new Vector2(0.17f, 0));//6
//            vertices[1] = new VertexPositionTexture(new Vector3(X + 1, Y + 1, Z + 1), new Vector2(0.33f, 0));//8
//            vertices[2] = new VertexPositionTexture(new Vector3(X, Y, Z + 1), new Vector2(0.17f, 1));//2
//            vertices[3] = new VertexPositionTexture(new Vector3(X + 1, Y, Z + 1), new Vector2(0.33f, 1));//4
//            indices[0] = W + 2;
//            indices[1] = W + 1;
//            indices[2] = W + 3;
//            indices[3] = W + 2;
//            indices[4] = W + 0;
//            indices[5] = W + 1;
//        }
//    }
//    class BackPlate : Plate
//    {
//        public BackPlate(int X, int Y, int Z, int W)
//        {
//            vertices[0] = new VertexPositionTexture(new Vector3(X + 1, Y + 1, Z + 1), new Vector2(0.3333f, 0));//8
//            vertices[1] = new VertexPositionTexture(new Vector3(X + 1, Y + 1, Z), new Vector2(0.50f, 0));//7
//            vertices[2] = new VertexPositionTexture(new Vector3(X + 1, Y, Z + 1), new Vector2(0.3333f, 1));//4
//            vertices[3] = new VertexPositionTexture(new Vector3(X + 1, Y, Z), new Vector2(0.50f, 1));//3
//            indices[0] = W + 2;
//            indices[1] = W + 1;
//            indices[2] = W + 3;
//            indices[3] = W + 2;
//            indices[4] = W + 0;
//            indices[5] = W + 1;
//        }
//    }
//    class LeftPlate : Plate
//    {
//        public LeftPlate(int X, int Y, int Z, int W)
//        {
//            vertices[0] = new VertexPositionTexture(new Vector3(X + 1, Y + 1, Z), new Vector2(0.50f, 0));//7
//            vertices[1] = new VertexPositionTexture(new Vector3(X, Y + 1, Z), new Vector2(0.66f, 0));//5
//            vertices[2] = new VertexPositionTexture(new Vector3(X + 1, Y, Z), new Vector2(0.50f, 1));//3
//            vertices[3] = new VertexPositionTexture(new Vector3(X, Y, Z), new Vector2(0.66f, 1));//1
//            indices[0] = W + 2;
//            indices[1] = W + 1;
//            indices[2] = W + 3;
//            indices[3] = W + 2;
//            indices[4] = W + 0;
//            indices[5] = W + 1;
//        }
//    }
//    class UpPlate : Plate
//    {
//        public UpPlate(int X, int Y, int Z, int W)
//        {
//            vertices[0] = new VertexPositionTexture(new Vector3(X + 1, Y + 1, Z), new Vector2(0.67f, 0));//7
//            vertices[1] = new VertexPositionTexture(new Vector3(X + 1, Y + 1, Z + 1), new Vector2(0.83f, 0));//8
//            vertices[2] = new VertexPositionTexture(new Vector3(X, Y + 1, Z), new Vector2(0.67f, 1));//5
//            vertices[3] = new VertexPositionTexture(new Vector3(X, Y + 1, Z + 1), new Vector2(0.83f, 1));//6
//            indices[0] = W + 2;
//            indices[1] = W + 1;
//            indices[2] = W + 3;
//            indices[3] = W + 2;
//            indices[4] = W + 0;
//            indices[5] = W + 1;
//        }
//    }
//    class DownPlate : Plate
//    {
//        public DownPlate(int X, int Y, int Z, int W)
//        {
//            vertices[0] = new VertexPositionTexture(new Vector3(X, Y, Z + 1), new Vector2(0.84f, 1));//2
//            vertices[1] = new VertexPositionTexture(new Vector3(X + 1, Y, Z + 1), new Vector2(0.84f, 0));//4
//            vertices[2] = new VertexPositionTexture(new Vector3(X, Y, Z), new Vector2(0.99f, 1));//1
//            vertices[3] = new VertexPositionTexture(new Vector3(X + 1, Y, Z), new Vector2(0.99f, 0));//3
//            indices[0] = W + 2;
//            indices[1] = W + 1;
//            indices[2] = W + 3;
//            indices[3] = W + 2;
//            indices[4] = W + 0;
//            indices[5] = W + 1;
//        }
//    }
//    /// <summary>
//    /// やばい
//    /// 点がだるい
//    /// </summary>
//    class Plate
//    {
//        protected VertexPositionTexture[] vertices = new VertexPositionTexture[4];
//        protected int[] indices = new int[6];
//        public VertexPositionTexture[] GetVertices()
//        {
//            return vertices;
//        }
//        public int[] GetIndices()
//        {
//            return indices;
//        }
//    }
//    class Chank
//    {
//        /// <summary>
//        /// ブロックリスト
//        /// 点データ
//        /// 面データ
//        /// 
//        /// 理想
//        /// ブロックを消せと言われたら
//        /// その座標で登録したやつを消す
//        /// 消すと面データがずれる
//        /// 
//        /// 配列だったら
//        /// 点配列[]
//        /// 面配列[]を用意
//        /// 
//        /// ただ配列だとうまくいかないのでリスト使おうかな
//        /// 
//        /// XYZで何番目のやつなのかを登録して
//        /// その部分を消した後
//        /// 後ろのやつを消す
//        /// </summary>
//        private Dictionary<IVector3, int> blockList;
//        private SortedDictionary<IVector4, Plate> drawplate = new SortedDictionary<IVector4, Plate>();

//        private List<VertexPositionTexture> vertices_list = new List<VertexPositionTexture>();
//        private List<int> indices_list = new List<int>();

//        private VertexPositionTexture[] vertices_Arry;
//        private int[] indices_Arry;
//        public void Initialize(Dictionary<IVector3, int> _blocklist)
//        {
//            blockList = _blocklist;
//        }
//        ///座標とどの面なのかがわかる
//        public void Add(int X, int Y, int Z, int number)
//        {
//            ///1前
//            bool drawflag = false;
//            switch (number)
//            {
//                case 1://正面
//                    drawplate.Add(new IVector4(X, Y, Z, number), new FrontPlate(X, Y, Z, vertices_list.Count));
//                    drawflag = true;
//                    break;
//                case 2://右
//                    if (!drawplate.ContainsKey(new IVector4(X, Y, Z, number))) drawplate.Add(new IVector4(X, Y, Z, number), new RightPlate(X, Y, Z, vertices_list.Count));
//                    drawflag = true;
//                    break;
//                case 3://後ろ
//                    if (!drawplate.ContainsKey(new IVector4(X, Y, Z, number))) drawplate.Add(new IVector4(X, Y, Z, number), new BackPlate(X, Y, Z, vertices_list.Count));
//                    drawflag = true;
//                    break;
//                case 4://左
//                    if (!drawplate.ContainsKey(new IVector4(X, Y, Z, number))) drawplate.Add(new IVector4(X, Y, Z, number), new LeftPlate(X, Y, Z, vertices_list.Count));
//                    drawflag = true;
//                    break;
//                case 5://上
//                    if (!drawplate.ContainsKey(new IVector4(X, Y, Z, number))) drawplate.Add(new IVector4(X, Y, Z, number), new UpPlate(X, Y, Z, vertices_list.Count));
//                    drawflag = true;
//                    break;
//                case 6://下
//                    if (!drawplate.ContainsKey(new IVector4(X, Y, Z, number))) drawplate.Add(new IVector4(X, Y, Z, number), new DownPlate(X, Y, Z, vertices_list.Count));
//                    drawflag = true;
//                    break;
//            }
//            if (drawflag)
//            {
//                foreach (VertexPositionTexture item in drawplate[new IVector4(X, Y, Z, number)].GetVertices())
//                {
//                    vertices_list.Add(item);
//                }
//                foreach (int item in drawplate[new IVector4(X, Y, Z, number)].GetIndices())
//                {
//                    indices_list.Add(item);
//                }
//                vertices_Arry = vertices_list.ToArray();
//                indices_Arry = indices_list.ToArray();
//            }
//        }
//        public void BreakBlock(int X, int Y, int Z)
//        {
//            //このブロックが描画されてる部分があったら消す

//            int a = 0;
//            for (int i = 1; i < 7; i++)
//            {
//                if (drawplate.ContainsKey(new IVector4(X, Y, Z, i))) drawplate.Remove(new IVector4(X, Y, Z, i));
//                a++;
//            }
//            //ダメだった
//            drawplate2 = drawplate;
//            drawplate.Clear();
//            vertices_list.Clear();
//            indices_list.Clear();
//            foreach (var item in drawplate2)
//            {
//                Add(item.Key.X, item.Key.Y, item.Key.Z, item.Key.W);
//            }
//        }
//        public void Draw(GraphicsDevice graphicsDevice)
//        {
//            graphicsDevice.DrawUserIndexedPrimitives(
//                PrimitiveType.TriangleList,
//                vertices_Arry,
//                0,
//                vertices_Arry.Length,
//                indices_Arry,
//                0,
//                indices_Arry.Length / 3);

//        }
//    }
//}