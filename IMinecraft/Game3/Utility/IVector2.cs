using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game3
{
    class IVector2
    {
        public int X { get; set; }
        public int Y { get; set; }

        public IVector2(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
        }
        public bool Equals(IVector4 other)
        {
            return X == other.X && Y == other.Y;
        }
        public override int GetHashCode()
        {
            return X.GetHashCode() ^ Y.GetHashCode();
        }
    }
}
