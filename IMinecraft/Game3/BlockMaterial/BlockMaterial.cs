using Microsoft.Xna.Framework.Graphics;

namespace Game3
{
    class BlockMaterial
    {
        protected Texture2D TextureName;

        protected BlockMaterial(Texture2D name)
        {
            TextureName = name;
        }
        //public void Draw(ref BasicEffect effect, BlockMaterialawd block)
        //{
        //    //これを使ってstaticさせた本物のブロックからテクスチャデータを持ってくる
        //    effect.Texture = TextureName;
        //    graphicsDevice.DrawUserIndexedPrimitives(
        //        PrimitiveType.TriangleList,
        //        vertices,
        //        0,
        //        vertices.Length,
        //        indices,
        //        0,
        //        indices.Length / 3);
        //}
    }
}
