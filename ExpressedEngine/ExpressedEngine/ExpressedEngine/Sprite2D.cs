using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace ExpressedEngine.ExpressedEngine
{
    public class Sprite2D
    {
        public Vector2 Position = null;
        public Vector2 Scale = null;
        public string Directory = "";
        public string Tag = "";
        public Image Sprite = null;
        public bool isRefrence = false;

        public Sprite2D(Vector2 Position, Vector2 Scale, string Directory, string Tag)
        {
            this.Position = Position;
            this.Scale = Scale;
            this.Directory = Directory;
            this.Tag = Tag;

            Image tmp = Image.FromFile($"Assets/Sprites/{Directory}.png");
            Bitmap sprite = new Bitmap(tmp);
            Sprite = sprite;
           
            Log.Info($"[SHAPE2D]({Tag}) - Has been Registered");
            ExpressedEngine.RegisterSprite(this);
        }

        public Sprite2D(string Directory)
        {
            this.isRefrence = true;
            this.Directory = Directory;

            Image tmp = Image.FromFile($"Assets/Sprites/{Directory}.png");
            Bitmap sprite = new Bitmap(tmp);
            Sprite = sprite;

            Log.Info($"[SHAPE2D]({Tag}) - Has been Registered");
            ExpressedEngine.RegisterSprite(this);
        }

        public Sprite2D(Vector2 Position, Vector2 Scale, Sprite2D reference, string Tag)
        {
            this.Position = Position;
            this.Scale = Scale;
            this.Tag = Tag;

            Sprite = reference.Sprite;

            Log.Info($"[SHAPE2D]({Tag}) - Has been Registered");
            ExpressedEngine.RegisterSprite(this);
        }

        public Sprite2D IsColiding(string tag)
        {
            /*if (a.Position.X < b.Position.X + b.Scale.X &&
                a.Position.X + a.Scale.X > b.Position.X &&
                a.Position.Y < b.Position.Y + b.Scale.Y &&
                a.Position.Y + a.Scale.Y > b.Position.Y)
            {
                return true;
            }*/
            foreach(Sprite2D b in ExpressedEngine.AllSprites)
            {
                if (b.Tag == tag)
                {
                    if (Position.X < b.Position.X + b.Scale.X &&
                Position.X + Scale.X > b.Position.X &&
                Position.Y < b.Position.Y + b.Scale.Y &&
                Position.Y + Scale.Y > b.Position.Y)
                    {
                        return b;
                    }
                }
            }

            return null;
        }

        public bool IsColiding(Sprite2D a, Sprite2D b)
        {
            if (a.Position.X < b.Position.X + b.Scale.X&&
                a.Position.X + a.Scale.X > b.Position.X&&
                a.Position.Y < b.Position.Y +b.Scale.Y&&
                a.Position.Y + a.Scale.Y > b.Position.Y)
            {
                return true;
            }

            return false;
        }

        public void DestroySelf()
        {
            ExpressedEngine.UnRegisterSprite(this);
        }
    }
}
