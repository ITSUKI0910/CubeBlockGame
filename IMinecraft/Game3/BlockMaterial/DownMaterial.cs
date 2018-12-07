using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game3
{
    class DownMaterial : BlockMaterial
    {
        public DownMaterial(Texture2D name, int X, int Y, int Z) : base(name)
        {
            vertices = new VertexPositionTexture[4]
            {
                new VertexPositionTexture(new Vector3(X, Y, Z + 1), Vector2.UnitX),//2
                new VertexPositionTexture(new Vector3(X + 1, Y, Z + 1), Vector2.One),//4
                new VertexPositionTexture(new Vector3(X, Y, Z), Vector2.Zero),//1
                new VertexPositionTexture(new Vector3(X + 1, Y, Z), Vector2.UnitY)//3
            };
            indices = new int[6] { 2, 1, 3, 2, 0, 1 };
        }
    }
}
