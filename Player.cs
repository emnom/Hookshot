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
        public Player(int x, int y, Texture2D sprite) : base(x, y, sprite) { this.HookPosition = this.Position; }
        public Player(Vector2 pos, Texture2D sprite) : base(pos, sprite) { this.HookPosition = this.Position; }
 
        public Player(int x, int y) : base(x, y) { this.HookPosition = this.Position; }

        public Player(Vector2 pos) : base(pos) { this.HookPosition = this.Position; }


        public Player(int x, int y, Texture2D sprite, Vector2 spriteShift) : base(x, y, sprite, spriteShift) { this.HookPosition = this.Position; }
        public Player(Vector2 pos, Texture2D sprite, Vector2 spriteShift) : base(pos, sprite, spriteShift) { this.HookPosition = this.Position; }
        public Player(int x, int y, Vector2 spriteShift) : base(x, y, spriteShift) { this.HookPosition = this.Position; }
        public Player(Vector2 pos, Vector2 spriteShift) : base(pos, spriteShift) { this.HookPosition = this.Position; }










        public Vector2 HookPosition { get; set; }
        

        public void SendHook(Vector2 destination)
        {
            this.HookPosition = Extend(this.Position, destination);
        }

        public void SendHook(int destinationX, int destinationY)
        {
            Vector2 destination = new Vector2(destinationX, destinationY);

            this.HookPosition = Extend(this.Position, destination);
        }

        public void DrawHook()
        {
            Game1._spriteBatch.DrawLine(Game1.lineTexture, this.Position, this.HookPosition);   
        }
        
        public void DrawPlayer()
        {
            Game1._spriteBatch.Draw(
                Game1.ballTexture,
                this.Position,
                null,
                Color.White,
                0f,
                new Vector2(Game1.ballTexture.Width / 2, Game1.ballTexture.Height / 2),
                Vector2.One,
                SpriteEffects.None,
                0f
            ); 
        }

    }
}
