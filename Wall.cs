using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Main
{
    class Wall : Obj
    {
        public Wall(int x, int y, Texture2D sprite) : base(x, y, sprite) {this.isSolid = true;}
        public Wall(Vector2 pos, Texture2D sprite) : base(pos, sprite) { this.isSolid = true; }

        public Wall(int x, int y) : base(x, y) { this.isSolid = true; }

        public Wall(Vector2 pos) : base(pos) { this.isSolid = true; }



        public Wall(int x, int y, Texture2D sprite, Vector2 spriteShift) : base(x, y, sprite, spriteShift) { this.isSolid = true; }

        public Wall(Vector2 pos, Texture2D sprite, Vector2 spriteShift) : base(pos, sprite, spriteShift) { this.isSolid = true; }


        public Wall(int x, int y, Vector2 spriteShift) : base(x, y, spriteShift) { this.isSolid = true; }

        public Wall(Vector2 pos, Vector2 spriteShift) : base(pos, spriteShift) { this.isSolid = true; }





    }
}
