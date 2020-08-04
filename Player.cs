using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Text;
using static Main.PhysicsFuncs;
using Extensions;
using Microsoft.Xna.Framework.Graphics;

namespace Main
{
    public class Player : Obj
    {
        public Player(int x, int y, Texture2D sprite) : base(x, y, sprite) { this.HookEnd = this.Position; }
        public Player(Vector2 pos, Texture2D sprite) : base(pos, sprite) { this.HookEnd = this.Position; }
 
        public Player(int x, int y) : base(x, y) { this.HookEnd = this.Position; }

        public Player(Vector2 pos) : base(pos) { this.HookEnd = this.Position; }


        public Player(int x, int y, Texture2D sprite, Vector2 spriteShift) : base(x, y, sprite, spriteShift) { this.HookEnd = this.Position; }
        public Player(Vector2 pos, Texture2D sprite, Vector2 spriteShift) : base(pos, sprite, spriteShift) { this.HookEnd = this.Position; }










        public Vector2 HookEnd { get; set; } 
        public Vector2 HookPosition { get; set; }
        public Vector2 HookDirection { get; set; }
        public float HookSpeed { get; set; } = 30;

        new public void Update(GameTime gameTime)
        {
            if(Vector2.Distance(HookEnd, HookPosition) <= HookSpeed)
            {
                this.HookPosition = this.HookEnd;
            }
            else
            {
                HookPosition = Vector2.Add(HookPosition, Vector2.Multiply(HookDirection, HookSpeed));
            }

            base.Update(gameTime);
        }


        public void SendHook(Vector2 destination)
        {
            this.HookEnd = Extend(this.Position, destination);
            this.HookPosition = this.Position;
            this.HookDirection = Vector2.Normalize(Vector2.Subtract(this.HookEnd, this.Position));
        }

        public void SendHook(int destinationX, int destinationY)
        {
            SendHook(new Vector2(destinationX, destinationY));
        }

        public void DrawHook()
        {
            Game1._spriteBatch.DrawLine(Game1.lineTexture, this.Position, this.HookPosition);   
        }


    }
}
