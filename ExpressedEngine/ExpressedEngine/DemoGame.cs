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

        bool left;
        bool right;
        bool up;
        bool down;


        Vector2 lastPos = Vector2.Zero();
        string[,] Map =
        {
            {"g","g","g","g","g","g","g" },
            {"g","c","c","c","c","c","g" },
            {"g","c","c","c","g","c","g" },
            {"g","c","g","g","g","c","g" },
            {"g","c","g","c","g","c","g" },
            {"g","c","g","c","c","c","g" },
            {"g","g","g","g","g","g","g" },
        };
        public DemoGame() : base(new Vector2(615,515),"Express Engine Demo") { }

        public override void OnLoad()
        {
            BackGroundColor = Color.Black;
            CameraPosition.X = 100;
            CameraZoom.X = 0.8f;
            CameraZoom.Y = 0.8f;
            Sprite2D groundref = new Sprite2D("Tiles/tile_0040");
            Sprite2D coinref = new Sprite2D("Tiles/tile_0101");
            //player = new Shape2D(new Vector2(10, 10), new Vector2(10, 10), "Test");
            //player = new Sprite2D(new Vector2(10, 10), new Vector2(36, 45), "Tiles/tile_0088", "Player");
            for (int i = 0; i<Map.GetLength(1);i++)
            {
                for(int j = 0; j < Map.GetLength(0); j++)
                {
                    if (Map[j, i] == "g")
                    {
                        new Sprite2D(new Vector2(i * 50, j * 50), new Vector2(50, 50), groundref, "Ground");
                    }
                    if (Map[j, i] == "c")
                    {
                        new Sprite2D(new Vector2(i * 50+12, j * 50+12), new Vector2(30, 30), coinref, "Coin");
                    }
                }
            }
            player = new Sprite2D(new Vector2(70, 70), new Vector2(30, 30), "Tiles/tile_0088", "Player");
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
            Sprite2D coin = player.IsColiding("Coin");
            if (coin != null)
            {
                coin.DestroySelf();
            }
            if (player.IsColiding("Ground") != null)
            {
                //Log.Info($"[Colision Count] - {count}");
                //count++;
                player.Position.X = lastPos.X;
                player.Position.Y = lastPos.Y;
            }
            else
            {
                lastPos.X = player.Position.X;
                lastPos.Y = player.Position.Y;
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
