using System;
using System.Collections.Generic;
using System.Text;
using Raylib;
using rl = Raylib.Raylib;

namespace ConsoleApp1
{
    struct Vector2Int
    {
        public int x;
        public int y;
    }

    class Player
    {
        public Vector2Int Position = new Vector2Int();
        public Color MyColor = Color.BEIGE;
        public static Texture2D MyTexture;
        public float SprScale = 1f;
        //public void SetTexture(string _FileName)
        //{
            //MyTexture = rl.LoadTexture(_FileName);
        //}

        public void RunUpdate()
        {
            if (rl.IsKeyDown(KeyboardKey.KEY_W))
            {
                Position.y--;
            }
            if (rl.IsKeyDown(KeyboardKey.KEY_S))
            {
                Position.y++;
            }
            if (rl.IsKeyDown(KeyboardKey.KEY_A))
            {
                Position.x--;
            }
            if (rl.IsKeyDown(KeyboardKey.KEY_D))
            {
                Position.x++;
            }

            if (rl.IsKeyDown(KeyboardKey.KEY_W) && (rl.IsKeyDown(KeyboardKey.KEY_LEFT_SHIFT) || rl.IsKeyDown(KeyboardKey.KEY_RIGHT_SHIFT)))
            {
                Position.y -= 3;
            }
            if (rl.IsKeyDown(KeyboardKey.KEY_S) && (rl.IsKeyDown(KeyboardKey.KEY_LEFT_SHIFT) || rl.IsKeyDown(KeyboardKey.KEY_RIGHT_SHIFT)))
            {
                Position.y += 3;
            }
            if (rl.IsKeyDown(KeyboardKey.KEY_A) && (rl.IsKeyDown(KeyboardKey.KEY_LEFT_SHIFT) || rl.IsKeyDown(KeyboardKey.KEY_RIGHT_SHIFT)))
            {
                Position.x -= 3;
            }
            if (rl.IsKeyDown(KeyboardKey.KEY_D) && (rl.IsKeyDown(KeyboardKey.KEY_LEFT_SHIFT) || rl.IsKeyDown(KeyboardKey.KEY_RIGHT_SHIFT)))
            {
                Position.x += 3;
            }
        }

        public void Draw()
        {
            //rl.DrawCircle(Position.x, Position.y, 5f, MyColor);
            //rl.DrawRectangleLines(Position.x, Position.y, 35, 50, MyColor);
            rl.DrawTextureEx(MyTexture, new Vector2(Position.x, Position.y), 0f, SprScale - .3f, MyColor);
        }
    }
}
