using Extensions;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using static Main.PhysicsFuncs;

namespace Main
{
    public class Obj
    {

        public BoundingBox gravityBox;

        public static int globalId = 0;

        public float mass;

        public int id;
        public BoundingBox hitbox;

        public float currentDrag = Game1.defaultDrag;

        public Vector2 position;
        public Vector2 velocity;

        public Vector2 size;

        public float bounce = 0; //Between 0 or 1; 0 equals no bounce; don't set this to 1

        float? distCheck = null;


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
            this.size = Vector2.Zero;
        }
        public Obj(Vector2 pos) 
        {
            this.position = pos;
            this.id = globalId++;
            this.size = Vector2.Zero;
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



        public void ApplyForce(Vector2 force)
        {
            this.velocity.Add(force);
        }

        public void ApplyGravity()
        {
            ApplyGravity(new Vector2(0, 1));
        }

        public void ApplyGravity(Vector2 direction)
        {
            direction.Normalize();

            this.gravityBox = new BoundingBox(this.Hitbox.Min, Vector3.Add(this.hitbox.Max, new Vector3(Math.Sign(direction.X), Math.Sign(direction.Y), 0)));

            foreach(KeyValuePair<int, Obj> solid in Obj.Solids)
            {
                if (solid.Value.Hitbox.Contains(gravityBox) == ContainmentType.Contains || solid.Value.Hitbox.Contains(gravityBox) == ContainmentType.Intersects)
                {
                    return;
                }
            }
            
            ApplyForce(Vector2.Multiply(direction, Game1.gConst));
        }



        public void Update(GameTime gameTime)
        {

            ApplyGravity();

            Extend(this.Hitbox, velocity, distCheck);

            if(velocity.Length() < distCheck)
            {
                position.Add(Vector2.Multiply(velocity, (float)gameTime.ElapsedGameTime.TotalSeconds));
            }
            else
            {
                position = Extend(this.Hitbox, velocity);
                velocity = Vector2.Multiply(velocity, bounce * (-1));
            }


            /*
             Add screws  | |
            */



        }

    }
}