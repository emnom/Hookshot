using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Main
{
    public class Wall : Obj
    {
        public Wall(int x, int y, Texture2D sprite, Vector2 size) : base(x, y, sprite, size) {this.IsSolid = true;}
        public Wall(Vector2 pos, Texture2D sprite, Vector2 size) : base(pos, sprite, size) { this.IsSolid = true; }

        public Wall(int x, int y, Vector2 size) : base(x, y, size) { this.IsSolid = true; }

        public Wall(Vector2 pos, Vector2 size) : base(pos, size) { this.IsSolid = true; }



        public Wall(int x, int y, Vector2 spriteShift, Texture2D sprite, Vector2 size) : base(x, y, spriteShift, sprite, size) { this.IsSolid = true; }

        public Wall(Vector2 pos, Vector2 spriteShift, Texture2D sprite, Vector2 size) : base(pos, spriteShift, sprite, size) { this.IsSolid = true; }


        public Wall(int x, int y, Texture2D sprite, int sizeX, int sizeY) : base(x, y, sprite, sizeX, sizeY) { this.IsSolid = true; }
        public Wall(Vector2 pos, Texture2D sprite, int sizeX, int sizeY) : base(pos, sprite, sizeX, sizeY) { this.IsSolid = true; }



        public Wall(int x, int y, int sizeX, int sizeY) : base(x, y, sizeX, sizeY) { this.IsSolid = true; }

        public Wall(Vector2 pos, int sizeX, int sizeY) : base(pos, sizeX, sizeY) { this.IsSolid = true; }



        public Wall(int x, int y, Vector2 spriteShift, Texture2D sprite, int sizeX, int sizeY) : base(x, y, spriteShift, sprite, sizeX, sizeY) { this.IsSolid = true; }

        public Wall(Vector2 pos, Vector2 spriteShift, Texture2D sprite, int sizeX, int sizeY) : base(pos, spriteShift, sprite, sizeX, sizeY) { this.IsSolid = true; }

    }
}
