using Extensions;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Main
{
    public class Obj
    {
        public static int globalId = 0;


        public int id;
        public BoundingBox hitbox;
        public Vector2 position;
        public Vector2 size;
        public BoundingBox Hitbox 
        {
            get { return hitbox; }
            set 
            { 
                hitbox = value;
                position = hitbox.Min.To2();
                size = Vector2.Subtract(hitbox.Max.To2(), hitbox.Min.To2());
            } 
        }
        public Vector2 Position
        {
            get { return position; }
            set { position = value; }

        }
        Texture2D sprite;
        Vector2 spriteToHitbox;

        public float Friction { get; set; }


        public static Dictionary<int, Obj> Solids = new Dictionary<int, Obj>();

        public bool isSolid = false;

        public bool IsSolid
        {
            get { return isSolid; }
            set 
            {                
                if(value == true && isSolid == false)
                {
                    Solids.Add(this.id, this);
                }
                else if (value == false && isSolid == true)
                {
                    Solids.Remove(this.id);
                }

                isSolid = value;
            }
        }

        public Obj(int x, int y, Texture2D sprite)
        {
            Constructor(new Vector2(x, y), Vector2.Zero, sprite);
        }
        public Obj(Vector2 pos, Texture2D sprite)
        {
            Constructor(pos, Vector2.Zero, sprite);
        }
        public Obj(int x, int y, Texture2D sprite, Vector2 size)
        {
            Constructor(new Vector2(x, y), Vector2.Zero, sprite, size);
        }
        public Obj(Vector2 pos, Texture2D sprite, Vector2 size)
        {
            Constructor(pos, Vector2.Zero, sprite, size);
        }
        public Obj(int x, int y, Texture2D sprite, int sizeX, int sizeY)
        {
            Constructor(new Vector2(x, y), Vector2.Zero, sprite, new Vector2(sizeX, sizeY));
        }
        public Obj(Vector2 pos, Texture2D sprite, int sizeX, int sizeY)
        {
            Constructor(pos, Vector2.Zero, sprite, new Vector2(sizeX, sizeY));
        }

        public Obj(int x, int y)
        {
            this.Position = new Vector2(x, y);
            this.id = globalId++; 
        }
        public Obj(Vector2 pos) 
        {
            this.position = pos;
            this.id = globalId++;
        }

        public Obj(int x, int y, Vector2 size)
        {
            this.Hitbox = new BoundingBox(new Vector3(x, y, 0), new Vector3(x + size.X, y + size.Y, 0));
            this.id = globalId++;
        }
        public Obj(Vector2 pos, Vector2 size)
        {
            this.Hitbox = new BoundingBox(new Vector3(pos.X, pos.Y, 0), new Vector3(pos.X + size.X, pos.Y + size.Y, 0));
            this.id = globalId++;
        }

        public Obj(int x, int y, int sizeX, int sizeY)
        {
            this.Hitbox = new BoundingBox(new Vector3(x, y, 0), new Vector3(x + sizeX, y + sizeY, 0));
            this.id = globalId++;

        }
        public Obj(Vector2 pos, int sizeX, int sizeY)
        {
            this.Hitbox = new BoundingBox(new Vector3(pos.X, pos.Y, 0), new Vector3(pos.X + sizeX, pos.Y + sizeY, 0));
            this.id = globalId++;
        }




        public Obj(int x, int y, Vector2 spriteShift, Texture2D sprite )
        {
            Constructor(new Vector2(x, y), spriteShift, sprite);
        }
        public Obj(Vector2 pos, Vector2 spriteShift, Texture2D sprite)
        {
            Constructor(pos, spriteShift, sprite);
        }
        public Obj(int x, int y, int shiftX, int shiftY, Texture2D sprite)
        {
            Constructor(new Vector2(x, y), new Vector2(shiftX, shiftY), sprite);
        }
        public Obj(Vector2 pos, int shiftX, int shiftY, Texture2D sprite)
        {
            Constructor(pos, new Vector2(shiftX, shiftY), sprite);
        }

        public Obj(int x, int y, Vector2 spriteShift, Texture2D sprite, Vector2 size)
        {
            Constructor(new Vector2(x, y), spriteShift, sprite, size);
        }
        public Obj(Vector2 pos, Vector2 spriteShift, Texture2D sprite, Vector2 size)
        {
            Constructor(pos, spriteShift, sprite, size);
        }
        public Obj(int x, int y, int shiftX, int shiftY, Texture2D sprite, Vector2 size)
        {
            Constructor(new Vector2(x, y), new Vector2(shiftX, shiftY), sprite, size);
        }
        public Obj(Vector2 pos, int shiftX, int shiftY, Texture2D sprite, Vector2 size)
        {
            Constructor(pos, new Vector2(shiftX, shiftY), sprite, size);
        }


        public Obj(int x, int y, Vector2 spriteShift, Texture2D sprite, int sizeX, int sizeY)
        {
            Constructor(new Vector2(x, y), spriteShift, sprite, new Vector2(sizeX, sizeY));
        }
        public Obj(Vector2 pos, Vector2 spriteShift, Texture2D sprite, int sizeX, int sizeY)
        {
            Constructor(pos, spriteShift, sprite, new Vector2(sizeX, sizeY));
        }
        public Obj(int x, int y, int shiftX, int shiftY, Texture2D sprite, int sizeX, int sizeY)
        {
            Constructor(new Vector2(x, y), new Vector2(shiftX, shiftY), sprite, new Vector2(sizeX, sizeY));
        }
        public Obj(Vector2 pos, int shiftX, int shiftY, Texture2D sprite, int sizeX, int sizeY)
        {
            Constructor(pos, new Vector2(shiftX, shiftY), sprite, new Vector2(sizeX, sizeY));
        }


        private void Constructor(Vector2 pos, Vector2 spriteShift, Texture2D sprite, Vector2 size)
        {
            this.Hitbox = new BoundingBox(new Vector3(pos.X, pos.Y, 0), new Vector3(pos.X + size.X, pos.Y + size.Y, 0));
            this.sprite = sprite;
            this.spriteToHitbox = spriteShift;
            this.size = size;

            this.id = globalId++;
        }
        private void Constructor(Vector2 pos, Vector2 spriteShift, Texture2D sprite)
        {
            this.Hitbox = new BoundingBox(new Vector3(pos.X, pos.Y, 0), new Vector3(pos.X + sprite.Width, pos.Y + sprite.Height, 0));
            this.sprite = sprite;
            this.spriteToHitbox = spriteShift;
            this.size = new Vector2(sprite.Width, sprite.Height);

            this.id = globalId++;
        }



        public void Draw()
        {
            if (sprite != null)
            {
                Game1._spriteBatch.Draw(sprite, Vector2.Add(Hitbox.Min.To2(), spriteToHitbox), null, Color.White, 0, Vector2.Zero, Vector2.Divide(size, new Vector2(sprite.Width, sprite.Height)), SpriteEffects.None, 0);
            }
        }
    }
}