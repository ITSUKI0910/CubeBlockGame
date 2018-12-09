using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game3
{
    class IVector2: IEquatable<IVector2>
    {
        public int X { get; set; }
        public int Y { get; set; }

        public IVector2(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
        }
        public bool Equals(IVector2 other)
        {
            return X == other.X && Y == other.Y;
        }
        public override int GetHashCode()
        {
            return X.GetHashCode() ^ Y.GetHashCode();
        }
    }
}

//int size = vertices_list.Count;
//            switch (number)
//            {
//                case 1://正面
//                    vertices_list.Add(new VertexPositionTexture(new Vector3(X, Y + 1, Z), Vector2.Zero));
//                    vertices_list.Add(new VertexPositionTexture(new Vector3(X, Y + 1, Z + 1), new Vector2(0.16f,0)));
//                    vertices_list.Add(new VertexPositionTexture(new Vector3(X, Y, Z), Vector2.UnitY));
//                    vertices_list.Add(new VertexPositionTexture(new Vector3(X, Y, Z + 1), new Vector2(0.16f, 1)));
//                    break;
//                case 2://右
//                    vertices_list.Add(new VertexPositionTexture(new Vector3(X, Y + 1, Z + 1), new Vector2(0.17f, 0)));//6
//                    vertices_list.Add(new VertexPositionTexture(new Vector3(X + 1, Y + 1, Z + 1), new Vector2(0.33f, 0)));//8
//                    vertices_list.Add(new VertexPositionTexture(new Vector3(X, Y, Z + 1), new Vector2(0.17f, 1)));//2
//                    vertices_list.Add(new VertexPositionTexture(new Vector3(X + 1, Y, Z + 1), new Vector2(0.33f, 1)));//4
//                    break;
//                case 3://後ろ
//                    vertices_list.Add(new VertexPositionTexture(new Vector3(X + 1, Y + 1, Z + 1), new Vector2(0.3333f, 0)));//8
//                    vertices_list.Add(new VertexPositionTexture(new Vector3(X + 1, Y + 1, Z), new Vector2(0.50f, 0)));//7
//                    vertices_list.Add(new VertexPositionTexture(new Vector3(X + 1, Y, Z + 1), new Vector2(0.3333f, 1)));//4
//                    vertices_list.Add(new VertexPositionTexture(new Vector3(X + 1, Y, Z), new Vector2(0.50f, 1)));//3
//                    break;
//                case 4://左
//                    vertices_list.Add(new VertexPositionTexture(new Vector3(X + 1, Y + 1, Z), new Vector2(0.50f, 0)));//7
//                    vertices_list.Add(new VertexPositionTexture(new Vector3(X, Y + 1, Z), new Vector2(0.66f, 0)));//5
//                    vertices_list.Add(new VertexPositionTexture(new Vector3(X + 1, Y, Z), new Vector2(0.50f, 1)));//3
//                    vertices_list.Add(new VertexPositionTexture(new Vector3(X, Y, Z), new Vector2(0.66f, 1)));//1
//                    break;
//                case 5://上
//                    vertices_list.Add(new VertexPositionTexture(new Vector3(X + 1, Y + 1, Z), new Vector2(0.67f, 0)));//7
//                    vertices_list.Add(new VertexPositionTexture(new Vector3(X + 1, Y + 1, Z + 1), new Vector2(0.83f, 0)));//8
//                    vertices_list.Add(new VertexPositionTexture(new Vector3(X, Y + 1, Z), new Vector2(0.67f, 1)));//5
//                    vertices_list.Add(new VertexPositionTexture(new Vector3(X, Y + 1, Z + 1), new Vector2(0.83f, 1)));//6
//                    break;
//                case 6://下
//                    vertices_list.Add(new VertexPositionTexture(new Vector3(X, Y, Z + 1), new Vector2(0.84f, 1)));//2
//                    vertices_list.Add(new VertexPositionTexture(new Vector3(X + 1, Y, Z + 1), new Vector2(0.84f, 0)));//4
//                    vertices_list.Add(new VertexPositionTexture(new Vector3(X, Y, Z), new Vector2(0.99f, 1)));//1
//                    vertices_list.Add(new VertexPositionTexture(new Vector3(X + 1, Y, Z), new Vector2(0.99f, 0)));//3
//                    break;
//            }
//            indices_list.Add(size + 2);
//            indices_list.Add(size + 1);
//            indices_list.Add(size + 3);
//            indices_list.Add(size + 2);
//            indices_list.Add(size + 0);
//            indices_list.Add(size + 1);