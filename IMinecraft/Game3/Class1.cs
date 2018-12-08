using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game3
{
}
//    class Class1
//    {
//        public GameControl(ContentManager Content)
//        {
//            this.Content = Content;
//            material.Add(BlockID.stone, new Stone());
//        }
//        public void Initialize(Dictionary<IVector3, int> wbd, List<IVector2> ChankList)
//        {
//            WorldBlockDate = wbd;
//            int x, y, z;
//            bool[] FRBLUD = new bool[6] { false, false, false, false, false, false };
//            foreach (var Chank in ChankList)
//            {
//                int X = Chank.Y, Z = Chank.Y;
//                for (y = 0; y < 64; y++)
//                {
//                    for (x = 0; x < 16; x++)
//                    {
//                        for (z = 0; z < 16; z++)
//                        {
//                            if (wbd[new IVector3(x, y, z)] == 1)
//                            {
//                                //この書き方するとなぜかバグる
//                                //FRBLUD[0] = false;
//                                //FRBLUD[1] = false;
//                                //FRBLUD[2] = false;
//                                //FRBLUD[3] = false;
//                                //FRBLUD[4] = false;
//                                //FRBLUD[5] = false;
//                                FRBLUD = new bool[6] { false, false, false, false, false, false };
//                                bool a = false;
//                                if (wbd.ContainsKey(new IVector3(X + x - 1, y, z + Z)) && wbd[new IVector3(X + x - 1, y, z + Z)] != 0) { } else { FRBLUD[0] = true; a = true; }
//                                if (wbd.ContainsKey(new IVector3(X + x, y, z + 1 + Z)) && wbd[new IVector3(X + x, y, z + 1 + Z)] != 0) { } else { FRBLUD[1] = true; a = true; }
//                                if (wbd.ContainsKey(new IVector3(X + x + 1, y, z + Z)) && wbd[new IVector3(X + x + 1, y, z + Z)] != 0) { } else { FRBLUD[2] = true; a = true; }
//                                if (wbd.ContainsKey(new IVector3(X + x, y, z - 1 + Z)) && wbd[new IVector3(X + x, y, z - 1 + Z)] != 0) { } else { FRBLUD[3] = true; a = true; }
//                                if (wbd.ContainsKey(new IVector3(X + x, y + 1, z + Z)) && wbd[new IVector3(X + x, y + 1, z + Z)] != 0) { } else { FRBLUD[4] = true; a = true; }
//                                if (wbd.ContainsKey(new IVector3(X + x, y - 1, z + Z)) && wbd[new IVector3(X + x, y - 1, z + Z)] != 0) { } else { FRBLUD[5] = true; a = true; }
//                                if (a) DrawBlocks.Add(new IVector3(X + x, y, z + Z), new Block(new IVector3(X + x, y, z + Z), BlockID.stone, FRBLUD, Content));
//                            }
//                        }
//                    }

//                }
//            }
//        }
//        public void LoadContent(GraphicsDevice graphicsDevice)
//        {
//            this.GraphicsDevice = graphicsDevice;
//            effect = new BasicEffect(GraphicsDevice)
//            {
//                TextureEnabled = true,
//                View = Matrix.CreateLookAt(
//                _position,   //カメラの位置
//                new Vector3(0, 0, 0),  //カメラの見る点
//                new Vector3(0, 1, 0)    //カメラの上向きベクトル。(0, -1, 0)にすると画面が上下逆になる
//                ),
//                Projection = Matrix.CreatePerspectiveFieldOfView
//                (
//                MathHelper.ToRadians(45),   //視野の角度。
//                GraphicsDevice.Viewport.AspectRatio,//画面のアスペクト比(=横/縦)
//                1,      //カメラからこれより近い物体は画面に映らない
//                1000     //カメラからこれより遠い物体は画面に映らない
//                )
//            };
//            foreach (Block block in DrawBlocks.Values)
//            {
//                block.LoadContent(graphicsDevice);
//            }
//            effect.Texture = Content.Load<Texture2D>("grass");
//        }
//        public void UnloadContent()
//        {
//            effect.Dispose();
//        }
//        float _yaw =179;
//        float _pitch = 3.5f;
//        Vector3 CameraPosition;
//        public void Update()
//        {
//            KeyboardState keyboardState = Keyboard.GetState();
//            // マウスが画面中央からどれだけ移動したかを取得し、値を変化させる
//            // YawはY軸を中心とした横回転
//            _yaw += ((Mouse.GetState().X - GraphicsDevice.Viewport.Width / 2) / 1000f) * 2;
//            // PitchはX軸を中心とした縦回転
//            _pitch += ((Mouse.GetState().Y - GraphicsDevice.Viewport.Height / 2) / 1000f) * 2;

//            CameraPosition = new Vector3((float)(Math.Cos(_yaw) * Math.Cos(_pitch)), (float)Math.Sin(_pitch), (float)(Math.Sin(_yaw) * Math.Cos(_pitch)));

//            // マウスを画面の中心に置く
//            Mouse.SetPosition(GraphicsDevice.Viewport.Width / 2, GraphicsDevice.Viewport.Height / 2);
//            float amerika = 14.155554f;
//            // キー入力情報を取得
//            if (keyboardState.IsKeyDown(Keys.W)) _position += new Vector3((float)(Math.Cos(_yaw) * Math.Cos(_pitch)), 0, (float)(Math.Sin(_yaw) * Math.Cos(_pitch))) * 0.15f;
//            if (keyboardState.IsKeyDown(Keys.S)) _position -= new Vector3((float)(Math.Cos(_yaw) * Math.Cos(_pitch)), 0, (float)(Math.Sin(_yaw) * Math.Cos(_pitch))) * 0.15f;
//            if (keyboardState.IsKeyDown(Keys.A)) _position -= new Vector3((float)(Math.Cos(_yaw + amerika) * Math.Cos(_pitch)), 0, (float)(Math.Sin(_yaw + amerika) * Math.Cos(_pitch))) * 0.15f;
//            if (keyboardState.IsKeyDown(Keys.D)) _position += new Vector3((float)(Math.Cos(_yaw + amerika) * Math.Cos(_pitch)), 0, (float)(Math.Sin(_yaw + amerika) * Math.Cos(_pitch))) * 0.15f;
//            if (keyboardState.IsKeyUp(Keys.LeftShift))
//            {
//                //下に下りたときの処理
//                _position -= new Vector3(0, 0.5f, 0);
//                //int Y = (int)Math.Truncate(_position.Y - CollisionDown);
//                //int X0 = (int)Math.Truncate(_position.X - CollisionSide);
//                //int X1 = (int)Math.Truncate(_position.X + CollisionSide);
//                //int Z0 = (int)Math.Truncate(_position.Z - CollisionSide);
//                //int Z1 = (int)Math.Truncate(_position.Z + CollisionSide);
//                //bool ITSUKI = false;
//                //if (X0 == X1)
//                //{
//                //    if (Z0 == Z1)
//                //    {
//                //        if (blockList.ContainsKey(new IVector3(X0, Y, Z0)) && blockList[new IVector3(X0, Y, Z0)] != 0) ITSUKI = true;
//                //    }
//                //    else
//                //    {
//                //        if (blockList.ContainsKey(new IVector3(X0, Y, Z0)) && blockList[new IVector3(X0, Y, Z0)] != 0) { ITSUKI = true; }
//                //        else if (blockList.ContainsKey(new IVector3(X0, Y, Z1)) && blockList[new IVector3(X0, Y, Z1)] != 0) ITSUKI = true;
//                //    }
//                //}
//                //else
//                //{
//                //    if (Z0 == Z1)
//                //    {
//                //        if (blockList.ContainsKey(new IVector3(X0, Y, Z0)) && blockList[new IVector3(X0, Y, Z0)] != 0) { ITSUKI = true; }
//                //        else if (blockList.ContainsKey(new IVector3(X1, Y, Z0)) && blockList[new IVector3(X1, Y, Z0)] != 0) ITSUKI = true;
//                //    }
//                //    else
//                //    {
//                //        if (blockList.ContainsKey(new IVector3(X0, Y, Z0)) && blockList[new IVector3(X0, Y, Z0)] != 0) { ITSUKI = true; }
//                //        else if (blockList.ContainsKey(new IVector3(X1, Y, Z0)) && blockList[new IVector3(X1, Y, Z0)] != 0) { ITSUKI = true; }
//                //        else if (blockList.ContainsKey(new IVector3(X0, Y, Z1)) && blockList[new IVector3(X0, Y, Z1)] != 0) { ITSUKI = true; }
//                //        else if (blockList.ContainsKey(new IVector3(X1, Y, Z1)) && blockList[new IVector3(X1, Y, Z1)] != 0) { ITSUKI = true; }
//                //    }
//                //}
//                //if (ITSUKI) _position = new Vector3(_position.X, Y + 1 + CollisionDown, _position.Z);
//            }
//            if (keyboardState.IsKeyDown(Keys.Space))
//            {
//                //上に上がったときの処理
//                _position += new Vector3(0, 0.5f, 0);
//                //int Y = (int)Math.Truncate(_position.Y + CollisionUp);
//                //int X0 = (int)Math.Truncate(_position.X - CollisionSide);
//                //int X1 = (int)Math.Truncate(_position.X + CollisionSide);
//                //int Z0 = (int)Math.Truncate(_position.Z - CollisionSide);
//                //int Z1 = (int)Math.Truncate(_position.Z + CollisionSide);
//                //bool ITSUKI = false;
//                //if (X0 == X1)
//                //{
//                //    if (Z0 == Z1)
//                //    {
//                //        if (blockList.ContainsKey(new IVector3(X0, Y, Z0)) && blockList[new IVector3(X0, Y, Z0)] != 0) ITSUKI = true;
//                //    }
//                //    else
//                //    {
//                //        if (blockList.ContainsKey(new IVector3(X0, Y, Z0)) && blockList[new IVector3(X0, Y, Z0)] != 0)
//                //        {
//                //            ITSUKI = true;
//                //        }
//                //        else if (blockList.ContainsKey(new IVector3(X0, Y, Z1)) && blockList[new IVector3(X0, Y, Z1)] != 0)
//                //        {
//                //            ITSUKI = true;
//                //        }
//                //    }
//                //}
//                //else
//                //{
//                //    if (Z0 == Z1)
//                //    {
//                //        if (blockList.ContainsKey(new IVector3(X0, Y, Z0)) && blockList[new IVector3(X0, Y, Z0)] != 0)
//                //        {
//                //            ITSUKI = true;
//                //        }
//                //        else if (blockList.ContainsKey(new IVector3(X1, Y, Z0)) && blockList[new IVector3(X1, Y, Z0)] != 0)
//                //        {
//                //            ITSUKI = true;
//                //        }
//                //    }
//                //    else
//                //    {
//                //        if (blockList.ContainsKey(new IVector3(X0, Y, Z0)) && blockList[new IVector3(X0, Y, Z0)] != 0) { ITSUKI = true; }
//                //        else if (blockList.ContainsKey(new IVector3(X1, Y, Z0)) && blockList[new IVector3(X1, Y, Z0)] != 0) { ITSUKI = true; }
//                //        else if (blockList.ContainsKey(new IVector3(X0, Y, Z1)) && blockList[new IVector3(X0, Y, Z1)] != 0) { ITSUKI = true; }
//                //        else if (blockList.ContainsKey(new IVector3(X1, Y, Z1)) && blockList[new IVector3(X1, Y, Z1)] != 0) { ITSUKI = true; }
//                //    }
//                //}
//                //if (ITSUKI) _position = new Vector3(_position.X, Y - CollisionUp, _position.Z);
//            }
//            // ビュー行列を作成
//            Vector3 b = _position + CameraPosition * 2.5f;// 0.3f;
//            effect.View = Matrix.CreateLookAt(_position, b, new Vector3(0, 1, 0));

//            //ブロックを消す
//            if (Mouse.GetState().LeftButton == ButtonState.Pressed)
//            {
//                int kx = (int)Math.Truncate(b.X);
//                int ky = (int)Math.Truncate(b.Y);
//                int kz = (int)Math.Truncate(b.Z);
//                if (WorldBlockDate.ContainsKey(new IVector3(kx, ky, kz)) && WorldBlockDate[new IVector3(kx, ky, kz)] != 0)
//                {
//                    WorldBlockDate[new IVector3(kx, ky, kz)] = 0;
//                    if (DrawBlocks.ContainsKey(new IVector3(kx, ky, kz))) DrawBlocks.Remove(new IVector3(kx, ky, kz));
//                    IVector3 vec3 = new IVector3(kx + 1, ky, kz);
//                    if (WorldBlockDate.ContainsKey(vec3) && WorldBlockDate[vec3] != 0)
//                    {
//                        if (DrawBlocks.ContainsKey(vec3))
//                        {
//                            DrawBlocks[vec3].Front();
//                        }
//                        else
//                        {
//                            DrawBlocks.Add(vec3, new Block(vec3, BlockID.stone, new bool[] { true, false, false, false, false, false }, Content));
//                            DrawBlocks[vec3].LoadContent(GraphicsDevice);
//                        }
//                    }
//                    vec3 = new IVector3(kx, ky, kz - 1);
//                    if (WorldBlockDate.ContainsKey(vec3) && WorldBlockDate[vec3] != 0)
//                    {
//                        if (DrawBlocks.ContainsKey(vec3))
//                        {
//                            DrawBlocks[vec3].Right();
//                        }
//                        else
//                        {
//                            DrawBlocks.Add(vec3, new Block(vec3, BlockID.stone, new bool[] { false, true, false, false, false, false }, Content));
//                            DrawBlocks[vec3].LoadContent(GraphicsDevice);
//                        }
//                    }
//                    vec3 = new IVector3(kx - 1, ky, kz);
//                    if (WorldBlockDate.ContainsKey(vec3) && WorldBlockDate[vec3] != 0)
//                    {
//                        if (DrawBlocks.ContainsKey(vec3))
//                        {
//                            DrawBlocks[vec3].Back();
//                        }
//                        else
//                        {
//                            DrawBlocks.Add(vec3, new Block(vec3, BlockID.stone, new bool[] { false, false, true, false, false, false }, Content));
//                            DrawBlocks[vec3].LoadContent(GraphicsDevice);
//                        }
//                    }
//                    vec3 = new IVector3(kx, ky, kz + 1);
//                    if (WorldBlockDate.ContainsKey(vec3) && WorldBlockDate[vec3] != 0)
//                    {
//                        if (DrawBlocks.ContainsKey(vec3))
//                        {
//                            DrawBlocks[vec3].Left();
//                        }
//                        else
//                        {
//                            DrawBlocks.Add(vec3, new Block(vec3, BlockID.stone, new bool[] { false, false, false, true, false, false }, Content));
//                            DrawBlocks[vec3].LoadContent(GraphicsDevice);
//                        }
//                    }
//                    vec3 = new IVector3(kx, ky - 1, kz);
//                    if (WorldBlockDate.ContainsKey(vec3) && WorldBlockDate[vec3] != 0)
//                    {
//                        if (DrawBlocks.ContainsKey(vec3))
//                        {
//                            DrawBlocks[vec3].Up();
//                        }
//                        else
//                        {
//                            DrawBlocks.Add(vec3, new Block(vec3, BlockID.stone, new bool[] { false, false, false, false, true, false }, Content));
//                            DrawBlocks[vec3].LoadContent(GraphicsDevice);
//                        }
//                    }
//                    vec3 = new IVector3(kx, ky + 1, kz);
//                    if (WorldBlockDate.ContainsKey(vec3) && WorldBlockDate[vec3] != 0)
//                    {
//                        if (DrawBlocks.ContainsKey(vec3))
//                        {
//                            DrawBlocks[vec3].Down();
//                        }
//                        else
//                        {
//                            DrawBlocks.Add(vec3, new Block(vec3, BlockID.stone, new bool[] { false, false, false, false, false, true }, Content));
//                            DrawBlocks[vec3].LoadContent(GraphicsDevice);
//                        }
//                    }
//                }
//            }
//            ///ブロックを置く
//            //if (Mouse.GetState().RightButton == ButtonState.Pressed)
//            //{
//            //    kx = (int)Math.Truncate(b.X);
//            //    ky = (int)Math.Truncate(b.Y);
//            //    kz = (int)Math.Truncate(b.Z);
//            //    if (blockList.ContainsKey(new IVector3(kx, ky, kz)))
//            //    {
//            //        if (blockList[new IVector3(kx, ky, kz)] == 0)
//            //        {
//            //            blockList[new IVector3(kx, ky, kz)] = 1;
//            //            //まわりのブロックの描画を消す
//            //            if (SetBlock(kx - 1, ky, kz, 13)) Front(kx, ky, kz);
//            //            if (SetBlock(kx, ky, kz + 1, 19)) Right(kx, ky, kz);
//            //            if (SetBlock(kx + 1, ky, kz, 1)) Back(kx, ky, kz);
//            //            if (SetBlock(kx, ky, kz - 1, 7)) Left(kx, ky, kz);
//            //            if (SetBlock(kx, ky + 1, kz, 31)) Up(kx, ky, kz);
//            //            if (SetBlock(kx, ky - 1, kz, 25)) Down(kx, ky, kz);
//            //        }
//            //    }
//            //    else
//            //    {
//            //        blockList.Add(new IVector3(kx, ky, kz), 1);
//            //        //まわりのブロックの描画を消す
//            //        if (SetBlock(kx - 1, ky, kz, 13)) Front(kx, ky, kz);
//            //        if (SetBlock(kx, ky, kz + 1, 19)) Right(kx, ky, kz);
//            //        if (SetBlock(kx + 1, ky, kz, 1)) Back(kx, ky, kz);
//            //        if (SetBlock(kx, ky, kz - 1, 7)) Left(kx, ky, kz);
//            //        if (SetBlock(kx, ky + 1, kz, 31)) Up(kx, ky, kz);
//            //        if (SetBlock(kx, ky - 1, kz, 25)) Down(kx, ky, kz);
//            //    }
//            //}
//        }

//        /// <summary>
//        /// カメラポジションや
//        /// ブロックの配列を使う
//        /// 描画部分
//        /// 
//        /// 持ってくるものは
//        /// 点データと結ぶデータとテクスチャデータ
//        /// </summary>
//        public void Draw()
//        {
//            //
//            //大元のブロックにtextureを配列に当てはめてデータを取り出す
//            //ブロックIDとテクスチャの配列と点データと結ぶデータ
//            ///
//            ///このやり方はコピーが多いいから　重すぎる
//            ///
//            foreach (EffectPass pass in effect.CurrentTechnique.Passes)
//            {
//                pass.Apply();
//                foreach (Block block in DrawBlocks.Values)
//                {
//                    block.Draw(ref effect, material[block.ID]);
//                }
//            }
//                //int i = 0;
//                ////string[] texture = material[block.ID].Texture(block.DrawPossible());
//                //VertexPositionTexture[] vertices = block.Vertex();
//                //int[] indices = block.Indices();
//                //foreach (EffectPass pass in effect.CurrentTechnique.Passes)
//                //{
//                //    effect.Texture = Content.Load<Texture2D>("grass"); ;//もってきたテクスチャの配列を入れる？ｗ
//                //                                                        //順番は前右後ろ左上下と固定してる
//                //    pass.Apply();
//                //    GraphicsDevice.DrawUserIndexedPrimitives(
//                //        PrimitiveType.TriangleList,
//                //        vertices,
//                //        0,
//                //        vertices.Length,
//                //        indices,
//                //        0,
//                //        indices.Length / 3);
//                //    i++;
//                //}
           
//        }
//    }
//}