using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Game3
{
    /// <summary>
    /// クラス化（点と面を36個パターン分保存できるやつを作る
    /// それを一つにする
    /// Drawの部分を工夫するしかない
    /// クラスの中に入れたままにするか
    /// すべて一つにしておいてから描画する
    /// effectに直接テクスチャがあるから
    /// 別々にする
    /// pass.Apply();がなんなのかわからないここがわかればいいかなって
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        GameControl game;
        
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = 1850;
            graphics.PreferredBackBufferHeight = 1000;
            game = new GameControl(Content);
        }

        protected override void Initialize()
        {
            CreateBlockDate CreateBlockDate = new CreateBlockDate();
            game.Initialize(ref CreateBlockDate.GetBlockDate(), CreateBlockDate.GetChankDate());
            base.Initialize();
        }
        protected override void LoadContent()
        {
            game.LoadContent(GraphicsDevice);

        }
        protected override void UnloadContent()
        {
            game.UnloadContent();
        }
        int kx = 0, ky = 1, kz = 0;
        //四角の当たり判定を作る
        //1.5の目線で考えるので
        //上面は1.8
        //下は1.5
        //左右は0.7
        //private readonly float CollisionUp = 0.4f, CollisionDown=1.5f, CollisionSide = 0.3f;/*四角の半分だから0.6の半分で0.3*/
        protected override void Update(GameTime gameTime)
        {
            ///絶対消すな！/////////////////////////////////////////////////////////////////////////////////
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape)) Exit();
            ////////////////////////////////////////////////////////////////////////////////////////////////
            game.Update();
            ///やっぱプレイヤーに四角の判定をきちんと持たせておいたほうがええな
            ///そのほうが楽な気がする
            //KeyboardState keyboardState = Keyboard.GetState();
            //// マウスが画面中央からどれだけ移動したかを取得し、値を変化させる
            //// YawはY軸を中心とした横回転
            //_yaw += ((Mouse.GetState().X - GraphicsDevice.Viewport.Width / 2) / 1000f) * 2;
            //// PitchはX軸を中心とした縦回転
            //_pitch += ((Mouse.GetState().Y - GraphicsDevice.Viewport.Height / 2) / 1000f) * 2;

            //CameraPosition = new Vector3((float)(Math.Cos(_yaw) * Math.Cos(_pitch)), (float)Math.Sin(_pitch), (float)(Math.Sin(_yaw) * Math.Cos(_pitch)));

            //// マウスを画面の中心に置く
            //Mouse.SetPosition(GraphicsDevice.Viewport.Width / 2, GraphicsDevice.Viewport.Height / 2);
            //float amerika = 14.155554f;
            //// キー入力情報を取得
            //if (keyboardState.IsKeyDown(Keys.W)) _position += new Vector3((float)(Math.Cos(_yaw) * Math.Cos(_pitch)), 0, (float)(Math.Sin(_yaw) * Math.Cos(_pitch))) * 0.15f;
            //if (keyboardState.IsKeyDown(Keys.S)) _position -= new Vector3((float)(Math.Cos(_yaw) * Math.Cos(_pitch)), 0, (float)(Math.Sin(_yaw) * Math.Cos(_pitch))) * 0.15f;
            
            /////前に進んだ時の処理
            /////今のプレイヤーのポジションを見て
            /////Z上の計算を入れる進んだ時のブロックを見る
            /////X上の計算を入れる進んだ時のブロックを見る
            /////判定方法は0以上か０以下かで判断０だったらそもそも判定しなくて良い
            /////    Vector3 vec3 = new Vector3((float)(Math.Cos(_yaw) * Math.Cos(_pitch)), 0, (float)(Math.Sin(_yaw) * Math.Cos(_pitch)));
            /////    _position += vec3;
            /////    int Y = (int)Math.Truncate(_position.Y);
            /////    int X0, Z0;
            /////    Z0 = (int)Math.Truncate(_position.Z);
            /////    if (vec3.X > 0)
            /////    {
            /////        X0 = (int)Math.Truncate(_position.X + CollisionSide);
            /////        if (blockList.ContainsKey(new IVector3(X0, Y, Z0)) && blockList[new IVector3(X0, Y, Z0)] != 0)
            /////        {
            /////            _position.X = X0 - CollisionSide - 10;
            /////        }
            /////    }
            /////    if (vec3.X < 0)
            /////    {
            /////        X0 = (int)Math.Truncate(_position.X - CollisionSide);
            /////        if (blockList.ContainsKey(new IVector3(X0, Y, Z0)) && blockList[new IVector3(X0, Y, Z0)] != 0)
            /////        {
            /////            _position.X = X0 + CollisionSide + 10;
            /////        }
            /////    }
            /////    X0 = (int)Math.Truncate(_position.X);
            /////    if (vec3.Z > 0)
            /////    {
            /////        Z0 = (int)Math.Truncate(_position.Z + CollisionSide);
            /////        if (blockList.ContainsKey(new IVector3(X0, Y, Z0)) && blockList[new IVector3(X0, Y, Z0)] != 0)
            /////        {
            /////            _position.Z = Z0 - CollisionSide - 10;
            /////        }
            /////    }
            /////    if (vec3.Z < 0)
            /////    {
            /////        Z0 = (int)Math.Truncate(_position.Z - CollisionSide);
            /////        if (blockList.ContainsKey(new IVector3(X0, Y, Z0)) && blockList[new IVector3(X0, Y, Z0)] != 0)
            /////        {
            /////            _position.Z = Z0 + CollisionSide + 10;
            /////        }
            /////    }
            /////}
            /////int Y = (int)Math.Truncate(_position.Y + CollisionUp);
            /////int X0 = (int)Math.Truncate(_position.X - CollisionSide);
            /////int X1 = (int)Math.Truncate(_position.X + CollisionSide);
            /////int Z0 = (int)Math.Truncate(_position.Z - CollisionSide);
            ///// Z1 = (int)Math.Truncate(_position.Z + CollisionSide);
            /////bool ITSUKI = false;
            /////if (X0 == X1)
            /////{
            /////    if (Z0 == Z1)
            /////    {
            /////        if (blockList.ContainsKey(new IVector3(X0, Y, Z0)) && blockList[new IVector3(X0, Y, Z0)] != 0) ITSUKI = true;
            /////    }
            /////    else
            /////    {
            /////        if (blockList.ContainsKey(new IVector3(X0, Y, Z0)) && blockList[new IVector3(X0, Y, Z0)] != 0) ITSUKI = true;
            /////        else if (blockList.ContainsKey(new IVector3(X0, Y, Z1)) && blockList[new IVector3(X0, Y, Z1)] != 0) ITSUKI = true;
            /////    }
            /////}
            /////else
            /////{
            /////    if (Z0 == Z1)
            /////    {
            /////        if (blockList.ContainsKey(new IVector3(X0, Y, Z0)) && blockList[new IVector3(X0, Y, Z0)] != 0) ITSUKI = true;
            /////        else if (blockList.ContainsKey(new IVector3(X1, Y, Z0)) && blockList[new IVector3(X1, Y, Z0)] != 0) ITSUKI = true;
            /////    }
            /////    else
            /////    {
            /////        if (blockList.ContainsKey(new IVector3(X0, Y, Z0)) && blockList[new IVector3(X0, Y, Z0)] != 0) ITSUKI = true;
            /////        else if (blockList.ContainsKey(new IVector3(X1, Y, Z0)) && blockList[new IVector3(X1, Y, Z0)] != 0) ITSUKI = true;
            /////        else if (blockList.ContainsKey(new IVector3(X0, Y, Z1)) && blockList[new IVector3(X0, Y, Z1)] != 0) ITSUKI = true;
            /////        else if (blockList.ContainsKey(new IVector3(X1, Y, Z1)) && blockList[new IVector3(X1, Y, Z1)] != 0) ITSUKI = true;
            /////    }
            /////}
            /////if (ITSUKI) _position = new Vector3(_position.X, Y - CollisionUp, _position.Z);

            //if (keyboardState.IsKeyDown(Keys.A)) _position -= new Vector3((float)(Math.Cos(_yaw + amerika) * Math.Cos(_pitch)), 0, (float)(Math.Sin(_yaw + amerika) * Math.Cos(_pitch))) * 0.15f;
            //if (keyboardState.IsKeyDown(Keys.D)) _position += new Vector3((float)(Math.Cos(_yaw + amerika) * Math.Cos(_pitch)), 0, (float)(Math.Sin(_yaw + amerika) * Math.Cos(_pitch))) * 0.15f;
            //if (keyboardState.IsKeyUp(Keys.LeftShift))
            //{
            //    //下に下りたときの処理
            //    _position -= new Vector3(0, 0.5f, 0);
            //    int Y = (int)Math.Truncate(_position.Y - CollisionDown);
            //    int X0 = (int)Math.Truncate(_position.X - CollisionSide);
            //    int X1 = (int)Math.Truncate(_position.X + CollisionSide);
            //    int Z0 = (int)Math.Truncate(_position.Z - CollisionSide);
            //    int Z1 = (int)Math.Truncate(_position.Z + CollisionSide);
            //    bool ITSUKI = false;
            //    if (X0 == X1)
            //    {
            //        if (Z0 == Z1)
            //        {
            //            if (blockList.ContainsKey(new IVector3(X0, Y, Z0)) && blockList[new IVector3(X0, Y, Z0)] != 0) ITSUKI = true;
            //        }
            //        else
            //        {
            //            if (blockList.ContainsKey(new IVector3(X0, Y, Z0)) && blockList[new IVector3(X0, Y, Z0)] != 0) { ITSUKI = true; }
            //            else if (blockList.ContainsKey(new IVector3(X0, Y, Z1)) && blockList[new IVector3(X0, Y, Z1)] != 0) ITSUKI = true;
            //        }
            //    }
            //    else
            //    {
            //        if (Z0 == Z1)
            //        {
            //            if (blockList.ContainsKey(new IVector3(X0, Y, Z0)) && blockList[new IVector3(X0, Y, Z0)] != 0) { ITSUKI = true; }
            //            else if (blockList.ContainsKey(new IVector3(X1, Y, Z0)) && blockList[new IVector3(X1, Y, Z0)] != 0) ITSUKI = true;
            //        }
            //        else
            //        {
            //            if (blockList.ContainsKey(new IVector3(X0, Y, Z0)) && blockList[new IVector3(X0, Y, Z0)] != 0) { ITSUKI = true; }
            //            else if (blockList.ContainsKey(new IVector3(X1, Y, Z0)) && blockList[new IVector3(X1, Y, Z0)] != 0) { ITSUKI = true; }
            //            else if (blockList.ContainsKey(new IVector3(X0, Y, Z1)) && blockList[new IVector3(X0, Y, Z1)] != 0) { ITSUKI = true; }
            //            else if (blockList.ContainsKey(new IVector3(X1, Y, Z1)) && blockList[new IVector3(X1, Y, Z1)] != 0) { ITSUKI = true; }
            //        }
            //    }
            //    if(ITSUKI) _position = new Vector3(_position.X, Y + 1 + CollisionDown, _position.Z);
            //}
            //if (keyboardState.IsKeyDown(Keys.Space)) {
            //    //上に上がったときの処理
            //    _position+= new Vector3(0,0.5f,0);
            //    int Y = (int)Math.Truncate(_position.Y + CollisionUp);
            //    int X0 = (int)Math.Truncate(_position.X - CollisionSide);
            //    int X1 = (int)Math.Truncate(_position.X + CollisionSide);
            //    int Z0 = (int)Math.Truncate(_position.Z - CollisionSide);
            //    int Z1 = (int)Math.Truncate(_position.Z + CollisionSide);
            //    bool ITSUKI = false;
            //    if (X0 == X1)
            //    {
            //        if (Z0 == Z1)
            //        {
            //            if (blockList.ContainsKey(new IVector3(X0, Y, Z0)) && blockList[new IVector3(X0, Y, Z0)] != 0) ITSUKI = true;
            //        }
            //        else
            //        {
            //            if (blockList.ContainsKey(new IVector3(X0, Y, Z0)) && blockList[new IVector3(X0, Y, Z0)] != 0)
            //            {
            //                ITSUKI = true;
            //            }
            //            else if (blockList.ContainsKey(new IVector3(X0, Y, Z1)) && blockList[new IVector3(X0, Y, Z1)] != 0)
            //            {
            //                ITSUKI = true;
            //            }
            //        }
            //    }
            //    else
            //    {
            //        if (Z0 == Z1)
            //        {
            //            if (blockList.ContainsKey(new IVector3(X0, Y, Z0)) && blockList[new IVector3(X0, Y, Z0)] != 0)
            //            {
            //                ITSUKI = true;
            //            }
            //            else if (blockList.ContainsKey(new IVector3(X1, Y, Z0)) && blockList[new IVector3(X1, Y, Z0)] != 0)
            //            {
            //                ITSUKI = true;
            //            }
            //        }
            //        else
            //        {
            //            if (blockList.ContainsKey(new IVector3(X0, Y, Z0)) && blockList[new IVector3(X0, Y, Z0)] != 0) { ITSUKI = true; }
            //            else if (blockList.ContainsKey(new IVector3(X1, Y, Z0)) && blockList[new IVector3(X1, Y, Z0)] != 0) { ITSUKI = true; }
            //            else if (blockList.ContainsKey(new IVector3(X0, Y, Z1)) && blockList[new IVector3(X0, Y, Z1)] != 0) { ITSUKI = true; }
            //            else if (blockList.ContainsKey(new IVector3(X1, Y, Z1)) && blockList[new IVector3(X1, Y, Z1)] != 0) { ITSUKI = true; }
            //        }
            //    }
            //    if (ITSUKI) _position = new Vector3(_position.X, Y - CollisionUp, _position.Z);
            //}
            //// ビュー行列を作成
            //Vector3 b = _position + CameraPosition * 2.5f;// 0.3f;
            //effect.View = Matrix.CreateLookAt(_position, b, new Vector3(0, 1, 0));

            // YawとPitchから前方の座標と左側、上側の座標を取得
            //Vector3 forward =
            //    Vector3.TransformNormal(Vector3.Forward,
            //    Matrix.CreateFromYawPitchRoll(_yaw, _pitch, 0));
            //Vector3 left =
            //    Vector3.TransformNormal(Vector3.Left,
            //    Matrix.CreateFromYawPitchRoll(_yaw, _pitch, 0));
            //Vector3 up =
            //    Vector3.TransformNormal(Vector3.Up,
            //    Matrix.CreateFromYawPitchRoll(_yaw, _pitch, 0));
            //kx = (int)Math.Truncate(_position.X);
            //if (blockList.ContainsKey(new IVector3(kx, ky - 2, kz)) && blockList[new IVector3(kx, ky - 2, kz)] != 0) { } else _position -= new Vector3(0, 0.1f, 0);
            //Debug.WriteLine(_position.X + "," + _position.Y + "," + _position.Z);
            //Debug.WriteLine(b.X +","+b.Y+","+b.Z);
            //Debug.WriteLine(kx + "," + ky + "," + kz);

            //ブロックを消す
            //if (Mouse.GetState().LeftButton == ButtonState.Pressed)
            //{
            //    kx = (int)Math.Truncate(b.X);
            //    ky = (int)Math.Truncate(b.Y);
            //    kz = (int)Math.Truncate(b.Z);           
            //    if (blockList.ContainsKey(new IVector3(kx, ky, kz)) && blockList[new IVector3(kx, ky, kz)] != 0)
            //    {
            //        blockList[new IVector3(kx, ky, kz)] = 0;
            //        for (int i = 1; i < 37; i++)
            //        {
            //            if (indices.ContainsKey(new IVector4(kx, ky, kz, i))) indices.Remove(new IVector4(kx, ky, kz, i));
            //        }
            //        if (blockList.ContainsKey(new IVector3(kx, ky - 1, kz)) && blockList[new IVector3(kx, ky - 1, kz)] != 0) Up(kx, ky - 1, kz);//上
            //        if (blockList.ContainsKey(new IVector3(kx, ky + 1, kz)) && blockList[new IVector3(kx, ky + 1, kz)] != 0) Down(kx, ky + 1, kz);//下
            //        if (blockList.ContainsKey(new IVector3(kx + 1, ky, kz)) && blockList[new IVector3(kx + 1, ky, kz)] != 0) Front(kx + 1, ky, kz);//前
            //        if (blockList.ContainsKey(new IVector3(kx, ky, kz - 1)) && blockList[new IVector3(kx, ky, kz - 1)] != 0) Right(kx, ky, kz - 1);//右
            //        if (blockList.ContainsKey(new IVector3(kx - 1, ky, kz)) && blockList[new IVector3(kx - 1, ky, kz)] != 0) Back(kx - 1, ky, kz);//後ろ
            //        if (blockList.ContainsKey(new IVector3(kx, ky, kz + 1)) && blockList[new IVector3(kx, ky, kz + 1)] != 0) Left(kx, ky, kz + 1);//左
            //    }
            //}
            /////ブロックを置く
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
            base.Update(gameTime);
        }
        //private bool SetBlock(int X , int Y, int Z ,int StartPoint)
        //{
        //    if (!(blockList.ContainsKey(new IVector3(X, Y, Z)))) return true;
        //    if (blockList[new IVector3(X, Y, Z)] != 0) 
        //    {
        //        for (int i = StartPoint; i < StartPoint + 6; i++)
        //        {
        //            if (indices.ContainsKey(new IVector4(X, Y, Z, i))) indices.Remove(new IVector4(X, Y, Z, i));
        //        }
        //        return false;
        //    }
        //    return true;
        //}
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.SkyBlue);
            game.Draw();
            base.Draw(gameTime);
        }
    }
}
