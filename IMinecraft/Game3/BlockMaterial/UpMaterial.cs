﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game3
{
    class UpMaterial : BlockMaterial
    {
        public UpMaterial(Texture2D name, int X, int Y, int Z) : base(name)
        {
            vertices = new VertexPositionTexture[4]
            {
                new VertexPositionTexture(new Vector3(X + 1, Y + 1, Z), Vector2.Zero),//7
                new VertexPositionTexture(new Vector3(X + 1, Y + 1, Z + 1), Vector2.UnitX),//8
                new VertexPositionTexture(new Vector3(X, Y + 1, Z), Vector2.UnitY),//5
                new VertexPositionTexture(new Vector3(X, Y + 1, Z + 1), Vector2.One)//6
            };
            indices = new int[6] { 2, 1, 3, 2, 0, 1 };
        }
    }
}