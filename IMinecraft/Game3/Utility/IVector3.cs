using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game3
{
    class IVector3 : IEquatable<IVector3>
    {
        //ベクター3(intバージョン)
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

        public IVector3(int X, int Y, int Z)
        {
            this.Y = Y;
            this.X = X;
            this.Z = Z;
        }
        public bool Equals(IVector3 other)
        {
            return X == other.X && Y == other.Y && Z == other.Z;
        }
        public override int GetHashCode()
        {
            return X.GetHashCode() ^ Y.GetHashCode() ^ Z.GetHashCode();
        }
        public Vector3 ToVector3()
        {
            return new Vector3(X, Y, Z);
        }
    }
}