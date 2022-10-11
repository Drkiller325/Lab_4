using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using ExpressedEngine.ExpressedEngine;
using System.Windows.Forms;
using System.Media;

namespace ExpressedEngine
{
    class DemoGame : ExpressedEngine.ExpressedEngine
    {
        Sprite2D player;
        Sprite2D player2;

        bool left;
        bool right;
        bool up;
        bool down;


        string[,] Map =
        {
            {"g","g","g","g","g","g","g","g" },
            {"g",".",".",".",".",".",".","g" },
            {"g",".",".",".",".","g",".","g" },
            {"g",".",".","g","g","g",".","g" },
            {"g",".","g","g",".","g",".","g" },
            {"g",".","g",".",".",".",".","g" },
            {"g","g","g","g","g","g","g","g" },
        };
        public DemoGame() : base(new Vector2(615,515),"Express Engine Demo") { }

        public override void OnLoad()
        {
            BackGroundColor = Color.Black;
            CameraPosition.X = 100;

            //player = new Shape2D(new Vector2(10, 10), new Vector2(10, 10), "Test");
            //player = new Sprite2D(new Vector2(10, 10), new Vector2(36, 45), "Tiles/tile_0088", "Player");
            for(int i = 0; i<Map.GetLength(1);i++)
            {
                for(int j = 0; j < Map.GetLength(0); j++)
                {
                    if (Map[j, i] == "g")
                    {
                        new Sprite2D(new Vector2(i * 50, j * 50), new Vector2(50, 50), "Tiles/tile_0040", "Ground");
                    }
                }
            }
            player = new Sprite2D(new Vector2(30, 30), new Vector2(50, 50), "Tiles/tile_0088", "Player");
            player2 = new Sprite2D(new Vector2(50, 50), new Vector2(50, 50), "Tiles/tile_0088", "Player2");
        }

        public override void OnDraw()
        {
            
        }

        int count = 0;
        public override void OnUpdate()
        {
            if (up)
            {
                player.Position.Y -= 5f;
            }
            if (down)
            {
                player.Position.Y += 5f;
            }
            if (left)
            {
                player.Position.X -= 5f;
            }
            if (right)
            {
                player.Position.X += 5f;
            }
            if (player.IsColiding(player, player2))
            {
                Log.Info($"[Colision Count] - {count}");
                count++;
            }
        }

        public override void GetKeyDown(KeyEventArgs e)
        {
            if(e.KeyCode == Keys.W) { up = true; }
            if (e.KeyCode == Keys.S) { down = true; }
            if (e.KeyCode == Keys.A) { left = true; }
            if (e.KeyCode == Keys.D) { right = true; }
        }

        public override void GetKeyUp(KeyEventArgs e)
        {
            if(e.KeyCode == Keys.W) { up = false; }
            if (e.KeyCode == Keys.S) { down = false; }
            if (e.KeyCode == Keys.A) { left = false; }
            if (e.KeyCode == Keys.D) { right = false; }
        }
    }
}
