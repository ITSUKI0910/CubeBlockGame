using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game3
{
    class Chank
    {
        /// <summary>
        /// ブロックリスト
        /// 点データ
        /// 面データ
        /// 理想も何も４こ消したら６こ消せばいい
        /// 4個追加したら６こ追加すればいい
        /// 
        private Dictionary<IVector3, int> blockList;
        private Dictionary<IVector4, VertexPositionTexture> vertices_list = new Dictionary<IVector4, VertexPositionTexture>();
        private LinkedList<int> indices_list = new LinkedList<int>();
        private VertexPositionTexture[] vertices_Arry;
        private int[] indices_Arry;
        private int vertices_Size = 0;
        private int indices_Size = 0;
        ///座標とどの面なのかがわかる
        public void Add(int X, int Y, int Z, int number)
        {
            bool drawflag = false;
            switch (number)
            {
                case 1://正面
                    vertices_list.Add(new IVector4(X, Y, Z, 1), new VertexPositionTexture(new Vector3(X, Y + 1, Z), Vector2.Zero));
                    vertices_list.Add(new IVector4(X, Y, Z, 2),new VertexPositionTexture(new Vector3(X, Y + 1, Z + 1), new Vector2(0.16f, 0)));
                    vertices_list.Add(new IVector4(X, Y, Z, 3), new VertexPositionTexture(new Vector3(X, Y, Z), Vector2.UnitY));
                    vertices_list.Add(new IVector4(X, Y, Z, 4), new VertexPositionTexture(new Vector3(X, Y, Z + 1), new Vector2(0.16f, 1)));
                    drawflag = true;
                    break;
                case 2://右
                    vertices_list.Add(new IVector4(X, Y, Z, 5), new VertexPositionTexture(new Vector3(X, Y + 1, Z + 1), new Vector2(0.17f, 0)));//6
                    vertices_list.Add(new IVector4(X, Y, Z, 6), new VertexPositionTexture(new Vector3(X + 1, Y + 1, Z + 1), new Vector2(0.33f, 0)));//8
                    vertices_list.Add(new IVector4(X, Y, Z, 7), new VertexPositionTexture(new Vector3(X, Y, Z + 1), new Vector2(0.17f, 1)));//2
                    vertices_list.Add(new IVector4(X, Y, Z, 8), new VertexPositionTexture(new Vector3(X + 1, Y, Z + 1), new Vector2(0.33f, 1)));//4
                    drawflag = true;
                    break;
                case 3://後ろ
                    vertices_list.Add(new IVector4(X, Y, Z, 9), new VertexPositionTexture(new Vector3(X + 1, Y + 1, Z + 1), new Vector2(0.3333f, 0)));//8
                    vertices_list.Add(new IVector4(X, Y, Z, 10), new VertexPositionTexture(new Vector3(X + 1, Y + 1, Z), new Vector2(0.50f, 0)));//7
                    vertices_list.Add(new IVector4(X, Y, Z, 11), new VertexPositionTexture(new Vector3(X + 1, Y, Z + 1), new Vector2(0.3333f, 1)));//4
                    vertices_list.Add(new IVector4(X, Y, Z, 12), new VertexPositionTexture(new Vector3(X + 1, Y, Z), new Vector2(0.50f, 1)));//3
                    drawflag = true;
                    break;
                case 4://左
                    vertices_list.Add(new IVector4(X, Y, Z, 13), new VertexPositionTexture(new Vector3(X + 1, Y + 1, Z), new Vector2(0.50f, 0)));//7
                    vertices_list.Add(new IVector4(X, Y, Z, 14), new VertexPositionTexture(new Vector3(X, Y + 1, Z), new Vector2(0.66f, 0)));//5
                    vertices_list.Add(new IVector4(X, Y, Z, 15), new VertexPositionTexture(new Vector3(X + 1, Y, Z), new Vector2(0.50f, 1)));//3
                    vertices_list.Add(new IVector4(X, Y, Z, 16), new VertexPositionTexture(new Vector3(X, Y, Z), new Vector2(0.66f, 1)));//1
                    drawflag = true;
                    break;
                case 5://上
                    vertices_list.Add(new IVector4(X, Y, Z, 17), new VertexPositionTexture(new Vector3(X + 1, Y + 1, Z), new Vector2(0.67f, 0)));//7
                    vertices_list.Add(new IVector4(X, Y, Z, 18), new VertexPositionTexture(new Vector3(X + 1, Y + 1, Z + 1), new Vector2(0.83f, 0)));//8
                    vertices_list.Add(new IVector4(X, Y, Z, 19), new VertexPositionTexture(new Vector3(X, Y + 1, Z), new Vector2(0.67f, 1)));//5
                    vertices_list.Add(new IVector4(X, Y, Z, 20), new VertexPositionTexture(new Vector3(X, Y + 1, Z + 1), new Vector2(0.83f, 1)));//6
                    drawflag = true;
                    break;
                case 6://下
                    vertices_list.Add(new IVector4(X, Y, Z, 21), new VertexPositionTexture(new Vector3(X, Y, Z + 1), new Vector2(0.84f, 1)));//2
                    vertices_list.Add(new IVector4(X, Y, Z, 22), new VertexPositionTexture(new Vector3(X + 1, Y, Z + 1), new Vector2(0.84f, 0)));//4
                    vertices_list.Add(new IVector4(X, Y, Z, 23), new VertexPositionTexture(new Vector3(X, Y, Z), new Vector2(0.99f, 1)));//1
                    vertices_list.Add(new IVector4(X, Y, Z, 24), new VertexPositionTexture(new Vector3(X + 1, Y, Z), new Vector2(0.99f, 0)));//3
                    drawflag = true;
                    break;
            }
            if (drawflag)
            {
                //なぜかvertices_listと同じ数字を持っている
                int W = vertices_list.Count;
                indices_list.AddLast(W + 2);
                indices_list.AddLast(W + 1);
                indices_list.AddLast(W + 3);
                indices_list.AddLast(W + 2);
                indices_list.AddLast(W + 0);
                indices_list.AddLast(W + 1);
            }
        }
        public void Initialize(Dictionary<IVector3, int> _blocklist)
        {
            blockList = _blocklist;
            ToArray();
        }
        private void ToArray()
        {
            vertices_Arry = vertices_list.Values.ToArray();
            indices_Arry = indices_list.ToArray();
            vertices_Size = vertices_Arry.Length;
            indices_Size = indices_Arry.Length/3;
        }
        public void BreakBlock(int X,int Y,int Z)
        {
            bool a = false;
            for (int i = 1; i < 25; i+=4)
            {
                if (vertices_list.ContainsKey(new IVector4(X, Y, Z, i)))
                {
                    vertices_list.Remove(new IVector4(X, Y, Z, i));
                    vertices_list.Remove(new IVector4(X, Y, Z, i+1));
                    vertices_list.Remove(new IVector4(X, Y, Z, i+2));
                    vertices_list.Remove(new IVector4(X, Y, Z, i+3));
                    indices_list.RemoveLast();
                    indices_list.RemoveLast();
                    indices_list.RemoveLast();
                    indices_list.RemoveLast();
                    indices_list.RemoveLast();
                    indices_list.RemoveLast();
                    a = true;
                }
            }
            if(a)ToArray();
        }
        public void Draw(GraphicsDevice graphicsDevice)
        {
            graphicsDevice.DrawUserIndexedPrimitives(
                PrimitiveType.TriangleList,
                vertices_Arry,
                0,
                vertices_Size,
                indices_Arry,
                0,
                indices_Size);
        }
    }
}