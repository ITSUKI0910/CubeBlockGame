using Microsoft.Xna.Framework;
using System;

namespace Game3
{
    class IVector4 : IEquatable<IVector4>, IComparable<IVector4>
    {
        //ベクター４(intバージョン)
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }
        public int W { get; set; }

        public IVector4(int X, int Y, int Z, int W)
        {
            this.Y = Y;
            this.X = X;
            this.Z = Z;
            this.W = W;
        }
        public IVector4(IVector3 vector3, int W)
        {
            this.X = vector3.X;
            this.Y = vector3.Y;
            this.Z = vector3.Z;
            this.W = W;
        }
        public IVector4(Vector3 vector3, int W)
        {
            this.X = (int)vector3.X;
            this.Y = (int)vector3.Y;
            this.Z = (int)vector3.Z;
            this.W = W;
        }
        public Vector4 ToVector4()
        {
            return new Vector4(X, Y, Z, W);
        }
        public Vector3 ToVector3()
        {
            return new Vector3(X, Y, Z);
        }
        public bool Equals(IVector4 other)
        {
            return X == other.X && Y == other.Y && Z == other.Z && W == other.W;
        }
        public override int GetHashCode()
        {
            return X.GetHashCode() ^ Y.GetHashCode() ^ Z.GetHashCode() ^ W.GetHashCode();
        }

        int IComparable<IVector4>.CompareTo(IVector4 other)
        {
            //まずYをみてXをみてZをみてWをみる
            if (other.Y == Y)
            {
                if (other.X == X)
                {
                    if (other.Z == Z)
                    {
                        if (other.W == W)
                        {
                            return 0;
                        }
                        else if (other.W > W) return -1; else return 1;
                    }
                    else if (other.Z > Z) return -1; else return 1;
                }
                else if (other.X > X) return -1; else return 1;
            }
            else if (other.Y > Y) return -1; else return 1;
        }
    }
}