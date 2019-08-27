using System;
using System.Collections.Generic;
using System.Text;
using Raylib;
using rl = Raylib.Raylib;

namespace ConsoleApp1
{
    static class Program
    {

        
        public static bool CheckCollisionV1(Player _pl, PickUp _pu)
        {
            bool rtn = false;
            Rectangle PickUpTest = new Rectangle(_pu.Position.x - 10, _pu.Position.y - 10, 20, 20);
            Rectangle PlayerCol = new Rectangle(_pl.Position.x, _pl.Position.y, 35, 50);
            //rl.CheckCollisionRecs(PickUpTest,PlayerCol);
            rtn = rl.CheckCollisionRecs(PickUpTest, PlayerCol);
            if (rtn)
            {
                _pu.Enabled = false;
                _pu.Noise();
                _pu.FirstTime = false;
            }
            return rtn;
        }

        public static int Main()
        {
            // Initialization
            //--------------------------------------------------------------------------------------
            int screenWidth = 800;
            int screenHeight = 450;
            int score = 0;
            int time = 0;
            Player MyPlayer = new Player();
            MyPlayer.Position.x = 75;
            MyPlayer.Position.y = 75;
            Random rand = new Random();

            rl.InitWindow(screenWidth, screenHeight, "raylib [core] example - basic window");

            Player.MyTexture = rl.LoadTexture("ghost_normal.png");
            PickUp.MyTexture = rl.LoadTexture("pickUpItem.png");
            PickUp.MySound = rl.LoadSound("powerUp6.ogg");

            PickUp[] Test = new PickUp[10];
            int idx = 0;
            for (int x = 100; x < 700 && idx < 10; x += 40)
            {
                Test[idx] = new PickUp();
                Test[idx].Position.x = rand.Next(801);
                Test[idx].Position.y = rand.Next(451);
                idx++;
            }

            rl.SetTargetFPS(60);
            //--------------------------------------------------------------------------------------
            int count = 1200;
            // Main game loop
            while (!rl.WindowShouldClose())    // Detect window close button or ESC key
            {
                // Update
                //----------------------------------------------------------------------------------
                // TODO: Update your variables here

                //MyPlayer.RunUpdate();
                if (time > 0)
                {
                    MyPlayer.RunUpdate();
                    if (MyPlayer.Position.x > screenWidth)
                    {
                        MyPlayer.Position.x = 0;
                    }
                    if (MyPlayer.Position.x < 0)
                    {
                        MyPlayer.Position.x = screenWidth;
                    }
                    if (MyPlayer.Position.y > screenHeight)
                    {
                        MyPlayer.Position.y = 0;
                    }
                    if (MyPlayer.Position.y < 0)
                    {
                        MyPlayer.Position.y = screenHeight;
                    }
                }
                count--;
                time = count / 60;
                if(count < 0)
                {
                    count = 0;
                }
                if(time <= 0)
                {
                    rl.DrawText("Times up!", 400, 200, 20, Color.BEIGE);
                }
                
                //----------------------------------------------------------------------------------

                // Draw
                //----------------------------------------------------------------------------------
                rl.BeginDrawing();
                

                rl.ClearBackground(Color.RAYWHITE);
                rl.DrawText($"Score {score}", 50, 50, 12, Color.BLACK);
                rl.DrawText($"Time {time}", 50, 60, 12, Color.BLACK);
                //rl.DrawText("Congrats! You created your first window!", 190, 200, 20, Color.BEIGE);
                MyPlayer.Draw();
                foreach (PickUp pickUp in Test)
                {
                    if (pickUp.Enabled)
                    {
                        pickUp.Draw();
                        score += CheckCollisionV1(MyPlayer, pickUp) ? 1:0;
                    }

                }
                rl.EndDrawing();
                //----------------------------------------------------------------------------------
            }

            // De-Initialization
            //--------------------------------------------------------------------------------------
            rl.CloseWindow();        // Close window and OpenGL context
                                     //--------------------------------------------------------------------------------------

            return 0;
        }
    }
}