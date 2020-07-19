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
        public BoundingBox Hitbox 
        {
            get { return hitbox; }
            set 
            { 
                hitbox = value;
                position = hitbox.Min.To2();
            } 
        }
        public Vector2 Position
        {
            get { return position; }
            set { position = value; }

        }
        Texture2D sprite;
        Vector2 spriteToHitbox;

        public static Dictionary<int, Obj> Solids = new Dictionary<int, Obj>();

        public bool isSolid;

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
            this.Hitbox = new BoundingBox(new Vector3(x, y, 0), new Vector3(x + sprite.Width, y + sprite.Height, 0));
            this.sprite = sprite;
            spriteToHitbox = Vector2.Zero;

            this.id = globalId++;
        }
        public Obj(Vector2 pos, Texture2D sprite)
        {
            this.Hitbox = new BoundingBox(new Vector3(pos.X, pos.Y, 0), new Vector3(pos.X + sprite.Width, pos.Y + sprite.Height, 0));
            this.sprite = sprite;
            spriteToHitbox = Vector2.Zero;

            this.id = globalId++;
        }

        public Obj(int x, int y)
        {
            this.Hitbox = new BoundingBox(new Vector3(x, y, 0), new Vector3(x + sprite.Width, y + sprite.Height, 0));        
            spriteToHitbox = Vector2.Zero;

            this.id = globalId++;
        }
        public Obj(Vector2 pos) { 
            this.Hitbox = new BoundingBox(new Vector3(pos.X, pos.Y, 0), new Vector3(pos.X + sprite.Width, pos.Y + sprite.Height, 0));
            spriteToHitbox = Vector2.Zero;

            this.id = globalId++;
        }


        public Obj(int x, int y, Texture2D sprite, Vector2 spriteShift)
        {
            this.Hitbox = new BoundingBox(new Vector3(x, y, 0), new Vector3(x + sprite.Width, y + sprite.Height, 0));
            this.sprite = sprite;
            spriteToHitbox = spriteShift;

            this.id = globalId++;
        }
        public Obj(Vector2 pos, Texture2D sprite, Vector2 spriteShift)
        {
            this.Hitbox = new BoundingBox(new Vector3(pos.X, pos.Y, 0), new Vector3(pos.X + sprite.Width, pos.Y + sprite.Height, 0));
            this.sprite = sprite;
            spriteToHitbox = spriteShift;

            this.id = globalId++;
        }
        public Obj(int x, int y, Vector2 spriteShift)
        {
            this.Hitbox = new BoundingBox(new Vector3(x, y, 0), new Vector3(x + sprite.Width, y + sprite.Height, 0));
            spriteToHitbox = spriteShift;

            this.id = globalId++;
        }
        public Obj(Vector2 pos, Vector2 spriteShift)
        {
            this.Hitbox = new BoundingBox(new Vector3(pos.X, pos.Y, 0), new Vector3(pos.X + sprite.Width, pos.Y + sprite.Height, 0));
            spriteToHitbox = spriteShift;

            this.id = globalId++;
        }



        public void Draw()
        {
            Game1._spriteBatch.Draw(sprite, Vector2.Add(Hitbox.Min.To2(), spriteToHitbox), Color.White);
        }
    }
}
