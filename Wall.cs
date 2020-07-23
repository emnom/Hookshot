using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Main
{
    class Wall : Obj
    {
        public Wall(int x, int y, Texture2D sprite) : base(x, y, sprite) {this.IsSolid = true;}
        public Wall(Vector2 pos, Texture2D sprite) : base(pos, sprite) { this.IsSolid = true; }

        public Wall(int x, int y) : base(x, y) { this.IsSolid = true; }

        public Wall(Vector2 pos) : base(pos) { this.IsSolid = true; }



        public Wall(int x, int y, Texture2D sprite, Vector2 spriteShift) : base(x, y, sprite, spriteShift) { this.IsSolid = true; }

        public Wall(Vector2 pos, Texture2D sprite, Vector2 spriteShift) : base(pos, sprite, spriteShift) { this.IsSolid = true; }





    }
}
