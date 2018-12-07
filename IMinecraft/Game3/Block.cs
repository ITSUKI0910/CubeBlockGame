using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game3
{
    /// <summary>
    /// とりあえず
    /// ブロックの中で
    /// 面をマテリアル化して
    /// 消したり生成したりする
    /// 
    /// その管理方法がどうするかで悩んでる
    /// enumでディクショナリ化するのが手段かな
    /// 配列で準備するってのもあんま意味ないからな
    /// とりまディクショナリでやるわ
    /// 
    /// bool型を使って入ってるか入ってないかを確認
    /// 追加するか消すかをする
    /// </summary>
    class Block
    {
        public BlockID ID { get; }
        private IVector3 vec3;
        private bool[] drawPossible;
        ContentManager Content;
        GraphicsDevice graphicsDevice;
        private Dictionary<BlockMaterialID, BlockMaterial> material = new Dictionary<BlockMaterialID, BlockMaterial>();
        public Block(IVector3 vec3, BlockID id, bool[] FRBLUD, ContentManager Content)
        {
            ID = id;
            drawPossible = FRBLUD;
            this.vec3 = vec3;
            this.Content = Content;
        }
        public void Front() {
            drawPossible[0] = !drawPossible[0];
            if (drawPossible[0])
            {
                material.Add(BlockMaterialID.front, new FrontMaterial(Content.Load<Texture2D>("stone_1"), vec3.X, vec3.Y, vec3.Z));
            }
            else
            {
                material.Remove(BlockMaterialID.front);
            }
        }
        public void RightMaterial() {
            drawPossible[1] = !drawPossible[1];
            if (drawPossible[1])
            {
                material.Add(BlockMaterialID.right, new RightMaterial(Content.Load<Texture2D>("stone_2"), vec3.X, vec3.Y, vec3.Z));
            }
            else
            {
                material.Remove(BlockMaterialID.right);
            }
        }
        public void BackMaterial()  {
            drawPossible[2] = !drawPossible[2];
            if (drawPossible[2])
            {
                material.Add(BlockMaterialID.back, new BackMaterial(Content.Load<Texture2D>("stone_3"), vec3.X, vec3.Y, vec3.Z));
            }
            else
            {
                material.Remove(BlockMaterialID.back);
            }
        }
        public void LeftMaterial()  {
            drawPossible[3] = !drawPossible[3];
            if (drawPossible[3])
            {
                material.Add(BlockMaterialID.left, new LeftMaterial(Content.Load<Texture2D>("stone_4"), vec3.X, vec3.Y, vec3.Z));
            }
            else
            {
                material.Remove(BlockMaterialID.left);
            }
        }
        public void UpMaterial()    {
            drawPossible[4] = !drawPossible[4];
            if (drawPossible[4])
            {
                material.Add(BlockMaterialID.up, new UpMaterial(Content.Load<Texture2D>("stone_5"), vec3.X, vec3.Y, vec3.Z));
            }
            else
            {
                material.Remove(BlockMaterialID.up);
            }
        }
        public void DownMaterial()  {
            drawPossible[5] = !drawPossible[5];
            if (drawPossible[5])
            {
                material.Add(BlockMaterialID.down, new DownMaterial(Content.Load<Texture2D>("stone_6"), vec3.X, vec3.Y, vec3.Z));
            }
            else
            {
                material.Remove(BlockMaterialID.down);
            }
        }
        public void LoadContent(GraphicsDevice graphicsDevice)
        {
            this.graphicsDevice = graphicsDevice;
        }
        public void Draw(ref BasicEffect effect, BlockMaterialawd block)
        {
            //これを使ってstaticさせた本物のブロックからテクスチャデータを持ってくる
            foreach (BlockMaterial a in material.Values)
            {
                a.Draw();
            }
        }
    }
}