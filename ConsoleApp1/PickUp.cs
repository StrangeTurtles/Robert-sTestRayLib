using System;
using System.Collections.Generic;
using System.Text;
using Raylib;
using rl = Raylib.Raylib;

namespace ConsoleApp1
{
    class PickUp
    {
        public Vector2Int Position;
        public Color MyColor = Color.BLUE;
        public bool Enabled = true;
        public static Texture2D MyTexture;
        public static Sound MySound;
        public bool FirstTime = true;
        public float SprScale = 1f;
        //public void SetTexture(string _FileName)
        //{
        //    MyTexture = rl.LoadTexture(_FileName);
        //}
        public void Noise()
        {
            if (!FirstTime)
            {
                rl.StopSound(MySound);
                return;
            }
            rl.PlaySound(MySound);
        }
        public void Draw()
        {
            if (!Enabled)
                return;
            //rl.DrawCircleLines(Position.x, Position.y, 10f, MyColor);
            rl.DrawTextureEx(MyTexture, new Vector2(Position.x - 30, Position.y - 30), 0f, SprScale, MyColor);
        }
    }
}
