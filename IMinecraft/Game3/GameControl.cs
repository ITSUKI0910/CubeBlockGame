 using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game3
{
    /// <summary>
    /// Drow関数を呼ぶのを少なくしなければならない
    /// そこで考えたのが１チャンクに対し1個Drawをする手段である
    /// 
    /// リストの中で
    /// 消される部分があるとするそしたら最初に消された部分の配列番号
    /// その配列はディクショナリで管理したほうがとても楽だと思う
    /// チャンクに対し番号を付ける、チャンクの原点の番号
    /// 
    /// ただブロックの設置がうまく出来ないんだよな～
    /// 描画用の配列を作るか
    /// 
    /// ワールドのブロックデータは必要
    /// 
    /// XYZを指定　ブロックリストをみて１かつ上下左右に何もなかったら設置関数を呼ぶ
    /// 上を表示させる関数を呼ぶ　　現状の点データの大きさを送る
    /// 点と面を生成させて　それを配列に入れる
    /// 
    /// 最後にチャンクで指定したリストに入れる
    /// 
    /// 
    /// </summary>
    class GameControl
    {
        ContentManager Content;
        GraphicsDevice GraphicsDevice;
        BasicEffect effect;
        private Dictionary<BlockID, BlockMaterialawd> material = new Dictionary<BlockID, BlockMaterialawd>();
        Vector3 _position = new Vector3(0, 68, 0);

        /// <summary>
        /// 描画するためデータ
        /// 視点を16で割ってキーに入れる
        /// チャンクを16単位をキーにチャンクデータを入れている
        /// オープンワールドにするときは
        ///　16*16で描画する　毎フレーム256ループをする（えぐい）
        ///　
        /// やっぱブロックデータはチャンクごとに持たせる
        /// 方向性で生きたい
        /// </summary>
        ///　これを素材にしてここで管理しなければなにもうまくいかない気がする
        private Dictionary<IVector2, Chank> ChankList = new Dictionary<IVector2, Chank>();
        public GameControl(ContentManager Content)
        {
            this.Content = Content;
            //material.Add(BlockID.stone, new Stone());
        }
        public void Initialize(ref Dictionary<IVector3, int> blockList, ref List<IVector2> chanklist)
        {
            foreach (var chank in chanklist)
            {
                ChankList.Add(chank, new Chank());
                Dictionary<IVector3, int> Initialize_blockList = new Dictionary<IVector3, int>();

                for (int y = 0; y < 64; y++)
                {
                    for (int x = chank.X; x < chank.X + 16; x++)
                    {
                        for (int z = chank.Y; z < chank.Y + 16; z++)
                        {
                            if (blockList[new IVector3(x, y, z)] == 1)
                            {
                                ///これをやると隣にブロックがあるかどうかがわかる
                                if (blockList.ContainsKey(new IVector3(x - 1, y, z)) && blockList[new IVector3(x - 1, y, z)] != 0) { } else { ChankList[chank].Add( x, y, z, 1); }
                                if (blockList.ContainsKey(new IVector3(x, y, z + 1)) && blockList[new IVector3(x, y, z + 1)] != 0) { } else { ChankList[chank].Add( x, y, z, 2); }
                                if (blockList.ContainsKey(new IVector3(x + 1, y, z)) && blockList[new IVector3(x + 1, y, z)] != 0) { } else { ChankList[chank].Add( x, y, z, 3); }
                                if (blockList.ContainsKey(new IVector3(x, y, z - 1)) && blockList[new IVector3(x, y, z - 1)] != 0) { } else { ChankList[chank].Add( x, y, z, 4); }
                                if (blockList.ContainsKey(new IVector3(x, y + 1, z)) && blockList[new IVector3(x, y + 1, z)] != 0) { } else { ChankList[chank].Add( x, y, z, 5); }
                                if (blockList.ContainsKey(new IVector3(x, y - 1, z)) && blockList[new IVector3(x, y - 1, z)] != 0) { } else { ChankList[chank].Add( x, y, z, 6); }
                            }
                            Initialize_blockList.Add(new IVector3(x, y, z), blockList[new IVector3(x, y, z)]);
                        }
                    }
                }
                ChankList[chank].Initialize(Initialize_blockList);
            }
        }
        public void LoadContent(GraphicsDevice graphicsDevice)
        {
            this.GraphicsDevice = graphicsDevice;
            effect = new BasicEffect(GraphicsDevice)
            {
                TextureEnabled = true,
                View = Matrix.CreateLookAt(
                _position,   //カメラの位置
                new Vector3(0, 0, 0),  //カメラの見る点
                new Vector3(0, 1, 0)    //カメラの上向きベクトル。(0, -1, 0)にすると画面が上下逆になる
                ),
                Projection = Matrix.CreatePerspectiveFieldOfView
                (
                MathHelper.ToRadians(45),   //視野の角度。
                GraphicsDevice.Viewport.AspectRatio,//画面のアスペクト比(=横/縦)
                1,      //カメラからこれより近い物体は画面に映らない
                1000     //カメラからこれより遠い物体は画面に映らない
                )
            };
            effect.Texture = Content.Load<Texture2D>("grass2");
            //48*48のサイズ
        }
        public void UnloadContent()
        {
            effect.Dispose();
        }
        float _yaw =179;
        float _pitch = 3.5f;
        Vector3 CameraPosition;
        public void Update()
        {

            KeyboardState keyboardState = Keyboard.GetState();
            // マウスが画面中央からどれだけ移動したかを取得し、値を変化させる
            // YawはY軸を中心とした横回転
            _yaw += ((Mouse.GetState().X - GraphicsDevice.Viewport.Width / 2) / 1000f) * 2;
            // PitchはX軸を中心とした縦回転
            _pitch += ((Mouse.GetState().Y - GraphicsDevice.Viewport.Height / 2) / 1000f) * 2;

            CameraPosition = new Vector3((float)(Math.Cos(_yaw) * Math.Cos(_pitch)), (float)Math.Sin(_pitch), (float)(Math.Sin(_yaw) * Math.Cos(_pitch)));

            // マウスを画面の中心に置く
            Mouse.SetPosition(GraphicsDevice.Viewport.Width / 2, GraphicsDevice.Viewport.Height / 2);
            float amerika = 14.155554f;
            // キー入力情報を取得
            if (keyboardState.IsKeyDown(Keys.W)) _position += new Vector3((float)(Math.Cos(_yaw) * Math.Cos(_pitch)), 0, (float)(Math.Sin(_yaw) * Math.Cos(_pitch))) * 0.15f;
            if (keyboardState.IsKeyDown(Keys.S)) _position -= new Vector3((float)(Math.Cos(_yaw) * Math.Cos(_pitch)), 0, (float)(Math.Sin(_yaw) * Math.Cos(_pitch))) * 0.15f;
            if (keyboardState.IsKeyDown(Keys.A)) _position -= new Vector3((float)(Math.Cos(_yaw + amerika) * Math.Cos(_pitch)), 0, (float)(Math.Sin(_yaw + amerika) * Math.Cos(_pitch))) * 0.15f;
            if (keyboardState.IsKeyDown(Keys.D)) _position += new Vector3((float)(Math.Cos(_yaw + amerika) * Math.Cos(_pitch)), 0, (float)(Math.Sin(_yaw + amerika) * Math.Cos(_pitch))) * 0.15f;
            if (keyboardState.IsKeyUp(Keys.LeftShift))
            {
                //下に下りたときの処理
                _position -= new Vector3(0, 0.5f, 0);
                //int Y = (int)Math.Truncate(_position.Y - CollisionDown);
                //int X0 = (int)Math.Truncate(_position.X - CollisionSide);
                //int X1 = (int)Math.Truncate(_position.X + CollisionSide);
                //int Z0 = (int)Math.Truncate(_position.Z - CollisionSide);
                //int Z1 = (int)Math.Truncate(_position.Z + CollisionSide);
            }
            if (keyboardState.IsKeyDown(Keys.Space))
            {
                //上に上がったときの処理
                _position += new Vector3(0, 0.5f, 0);
            }
            // ビュー行列を作成
            Vector3 b = _position + CameraPosition * 2.5f;// 0.3f;
            effect.View = Matrix.CreateLookAt(_position, b, new Vector3(0, 1, 0));

            //ブロックを消す
            if (Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                //Player_Mouse_X
                int pmx = (int)Math.Truncate(b.X);//上下
                int pmy = (int)Math.Truncate(b.Y);
                int pmz = (int)Math.Truncate(b.Z);//左右
                double c_x = pmx / 16;
                double c_z = pmz / 16;
                int chank_x = (int)Math.Truncate(c_x) * 16;
                int chank_z = (int)Math.Truncate(c_z) * 16;
                if (ChankList.ContainsKey(new IVector2(chank_x, chank_z)))
                {

                    //////////////////////////////////////////////////////////////////////
                    //2番目のやつ
                    //最終的に消す処理だから
                    //となりに描画させるプログラム
                    //pmxの入ってるチャンクの原点を見てるから　小数点以下を消した時同じになるから
                    //上　右　下　左　の順番でやる
                    if (pmx == chank_x && pmz == chank_z)//左下
                    {
                        ChankList[new IVector2(chank_x, chank_z)].Add(pmx, pmz++, 0, 0);
                        ChankList[new IVector2(chank_x, chank_z)].Add(pmx++, pmz, 0, 0);
                        if (ChankList.ContainsKey(new IVector2(chank_x - 16, chank_z))) ChankList[new IVector2(chank_x - 16, chank_z)].Add(pmx--, pmz, 0, 0);
                        if (ChankList.ContainsKey(new IVector2(chank_x, chank_z - 16))) ChankList[new IVector2(chank_x, chank_z - 16)].Add(pmx, pmz--, 0, 0);
                    }
                    else
                    if (pmx == chank_x + 15 && pmz == chank_z)//左上
                    {
                        if (ChankList.ContainsKey(new IVector2(chank_x + 16, chank_z))) ChankList[new IVector2(chank_x + 16, chank_z)].Add(pmx++, pmz, 0, 0);
                        ChankList[new IVector2(chank_x, chank_z)].Add(pmx, pmz++, 0, 0);
                        ChankList[new IVector2(chank_x, chank_z)].Add(pmx--, pmz, 0, 0);
                        if (ChankList.ContainsKey(new IVector2(chank_x, chank_z - 16))) ChankList[new IVector2(chank_x, chank_z - 16)].Add(pmx, pmz--, 0, 0);
                    }
                    else
                    if (pmx == chank_x && pmz == chank_z + 15)//右下
                    {
                        ChankList[new IVector2(chank_x, chank_z)].Add(pmx++, pmz, 0, 0);
                        if (ChankList.ContainsKey(new IVector2(chank_x, chank_z + 16))) ChankList[new IVector2(chank_x, chank_z + 16)].Add(pmx, pmz++, 0, 0);
                        if (ChankList.ContainsKey(new IVector2(chank_x - 16, chank_z))) ChankList[new IVector2(chank_x - 16, chank_z)].Add(pmx--, pmz, 0, 0);
                        ChankList[new IVector2(chank_x, chank_z - 16)].Add(pmx, pmz--, 0, 0);
                    }
                    else
                    if (pmx == chank_x + 15&& pmz == chank_z + 15)//右上
                    {
                        if (ChankList.ContainsKey(new IVector2(chank_x + 16, chank_z))) ChankList[new IVector2(chank_x + 16, chank_z)].Add(pmx++, pmz, 0, 0);
                        if (ChankList.ContainsKey(new IVector2(chank_x, chank_z + 16))) ChankList[new IVector2(chank_x, chank_z + 16)].Add(pmx, pmz++, 0, 0);
                        ChankList[new IVector2(chank_x, chank_z)].Add(pmx--, pmz, 0, 0);
                        ChankList[new IVector2(chank_x, chank_z)].Add(pmx, pmz++, 0, 0);
                    }
                    else
                    {
                        ChankList[new IVector2(chank_x, chank_z)].Add(pmx++, pmz, 0, 0);
                        ChankList[new IVector2(chank_x, chank_z)].Add(pmx, pmz++, 0, 0);
                        ChankList[new IVector2(chank_x, chank_z)].Add(pmx--, pmz, 0, 0);
                        ChankList[new IVector2(chank_x, chank_z)].Add(pmx, pmz--, 0, 0);
                    }
                        ChankList[new IVector2(chank_x, chank_z)].Add(1, 2, 3, 1);
                }
                ///ここで左右のブロックの状態を見てやる
                ///ただ上下は送った先で処理できる
                ///処理の候補
                ///+-して同じようにダブル型にして小数点をけして検索かけて
                ///そこの数字を貰って来て
                ///比較してやるほうほう
                //////////////////////////////////////////////////////////////////////
                //1番目のやつ
                //いいところ(俺が見ると)分かり易い
                //悪いところ　合計で計算が８+8+8回　　　　　　　24回
                //double abx = pmx + 1;
                //double abz = pmz + 1;
                //ChankList[new IVector2((int)Math.Truncate(abx) * 16, (int)Math.Truncate(abz) * 16)].Add(1, 2, 3, 1);
                //abx = pmx - 1;
                //abz = pmz + 1;
                //ChankList[new IVector2((int)Math.Truncate(abx) * 16, (int)Math.Truncate(abz) * 16)].Add(1, 2, 3, 1);
                //abx = pmx + 1;
                //abz = pmz - 1;
                //ChankList[new IVector2((int)Math.Truncate(abx) * 16, (int)Math.Truncate(abz) * 16)].Add(1, 2, 3, 1);
                //abx = pmx - 1;
                //abz = pmz - 1;
                //ChankList[new IVector2((int)Math.Truncate(abx) * 16, (int)Math.Truncate(abz) * 16)].Add(1, 2, 3, 1);
            }





            //    if (WorldBlockDate.ContainsKey(new IVector3(player_mouse_x, player_mouse_y, player_mouse_z)) && WorldBlockDate[new IVector3(player_mouse_x, player_mouse_y, player_mouse_z)] != 0)
            //    {
            //        WorldBlockDate[new IVector3(player_mouse_x, player_mouse_y, player_mouse_z)] = 0;
            //        if (DrawBlocks.ContainsKey(new IVector3(player_mouse_x, player_mouse_y, player_mouse_z))) DrawBlocks.Remove(new IVector3(player_mouse_x, player_mouse_y, player_mouse_z));
            //        IVector3 vec3 = new IVector3(player_mouse_x + 1, player_mouse_y, player_mouse_z);
            //        if (WorldBlockDate.ContainsKey(vec3) && WorldBlockDate[vec3] != 0)
            //        {
            //            if (DrawBlocks.ContainsKey(vec3))
            //            {
            //                DrawBlocks[vec3].Front();
            //            }
            //            else
            //            {
            //                DrawBlocks.Add(vec3, new Block(vec3, BlockID.stone, new bool[] { true, false, false, false, false, false }, Content));
            //                DrawBlocks[vec3].LoadContent(GraphicsDevice);
            //            }
            //        }
            //        vec3 = new IVector3(player_mouse_x, player_mouse_y, player_mouse_z - 1);
            //        if (WorldBlockDate.ContainsKey(vec3) && WorldBlockDate[vec3] != 0)
            //        {
            //            if (DrawBlocks.ContainsKey(vec3))
            //            {
            //                DrawBlocks[vec3].Right();
            //            }
            //            else
            //            {
            //                DrawBlocks.Add(vec3, new Block(vec3, BlockID.stone, new bool[] { false, true, false, false, false, false }, Content));
            //                DrawBlocks[vec3].LoadContent(GraphicsDevice);
            //            }
            //        }
            //        vec3 = new IVector3(player_mouse_x - 1, player_mouse_y, player_mouse_z);
            //        if (WorldBlockDate.ContainsKey(vec3) && WorldBlockDate[vec3] != 0)
            //        {
            //            if (DrawBlocks.ContainsKey(vec3))
            //            {
            //                DrawBlocks[vec3].Back();
            //            }
            //            else
            //            {
            //                DrawBlocks.Add(vec3, new Block(vec3, BlockID.stone, new bool[] { false, false, true, false, false, false }, Content));
            //                DrawBlocks[vec3].LoadContent(GraphicsDevice);
            //            }
            //        }
            //        vec3 = new IVector3(player_mouse_x, player_mouse_y, player_mouse_z + 1);
            //        if (WorldBlockDate.ContainsKey(vec3) && WorldBlockDate[vec3] != 0)
            //        {
            //            if (DrawBlocks.ContainsKey(vec3))
            //            {
            //                DrawBlocks[vec3].Left();
            //            }
            //            else
            //            {
            //                DrawBlocks.Add(vec3, new Block(vec3, BlockID.stone, new bool[] { false, false, false, true, false, false }, Content));
            //                DrawBlocks[vec3].LoadContent(GraphicsDevice);
            //            }
            //        }
            //        vec3 = new IVector3(player_mouse_x, player_mouse_y - 1, player_mouse_z);
            //        if (WorldBlockDate.ContainsKey(vec3) && WorldBlockDate[vec3] != 0)
            //        {
            //            if (DrawBlocks.ContainsKey(vec3))
            //            {
            //                DrawBlocks[vec3].Up();
            //            }
            //            else
            //            {
            //                DrawBlocks.Add(vec3, new Block(vec3, BlockID.stone, new bool[] { false, false, false, false, true, false }, Content));
            //                DrawBlocks[vec3].LoadContent(GraphicsDevice);
            //            }
            //        }
            //        vec3 = new IVector3(player_mouse_x, player_mouse_y + 1, player_mouse_z);
            //        if (WorldBlockDate.ContainsKey(vec3) && WorldBlockDate[vec3] != 0)
            //        {
            //            if (DrawBlocks.ContainsKey(vec3))
            //            {
            //                DrawBlocks[vec3].Down();
            //            }
            //            else
            //            {
            //                DrawBlocks.Add(vec3, new Block(vec3, BlockID.stone, new bool[] { false, false, false, false, false, true }, Content));
            //                DrawBlocks[vec3].LoadContent(GraphicsDevice);
            //            }
            //        }
            //    }
            //}
            ///ブロックを置く
            //if (Mouse.GetState().RightButton == ButtonState.Pressed)
            //{
            //    kx = (int)Math.Truncate(b.X);
            //    ky = (int)Math.Truncate(b.Y);
            //    kz = (int)Math.Truncate(b.Z);
            //    if (blockList.ContainsKey(new IVector3(kx, ky, kz)))
            //    {
            //        if (blockList[new IVector3(kx, ky, kz)] == 0)
            //        {
            //            blockList[new IVector3(kx, ky, kz)] = 1;
            //            //まわりのブロックの描画を消す
            //            if (SetBlock(kx - 1, ky, kz, 13)) Front(kx, ky, kz);
            //            if (SetBlock(kx, ky, kz + 1, 19)) Right(kx, ky, kz);
            //            if (SetBlock(kx + 1, ky, kz, 1)) Back(kx, ky, kz);
            //            if (SetBlock(kx, ky, kz - 1, 7)) Left(kx, ky, kz);
            //            if (SetBlock(kx, ky + 1, kz, 31)) Up(kx, ky, kz);
            //            if (SetBlock(kx, ky - 1, kz, 25)) Down(kx, ky, kz);
            //        }
            //    }
            //    else
            //    {
            //        blockList.Add(new IVector3(kx, ky, kz), 1);
            //        //まわりのブロックの描画を消す
            //        if (SetBlock(kx - 1, ky, kz, 13)) Front(kx, ky, kz);
            //        if (SetBlock(kx, ky, kz + 1, 19)) Right(kx, ky, kz);
            //        if (SetBlock(kx + 1, ky, kz, 1)) Back(kx, ky, kz);
            //        if (SetBlock(kx, ky, kz - 1, 7)) Left(kx, ky, kz);
            //        if (SetBlock(kx, ky + 1, kz, 31)) Up(kx, ky, kz);
            //        if (SetBlock(kx, ky - 1, kz, 25)) Down(kx, ky, kz);
            //    }
            //}
        }
        public void Draw()
        {
            foreach (EffectPass pass in effect.CurrentTechnique.Passes)
            {
                pass.Apply();
                foreach (Chank block in ChankList.Values)
                {
                    block.Draw(GraphicsDevice);
                }
            }

           
        }
    }
}
