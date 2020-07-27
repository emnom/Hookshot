using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Extensions
{
    public static class LineRenderer
    {
        public static void DrawLine(this SpriteBatch spriteBatch, Texture2D texture, Vector2 start, Vector2 end)
        {
            spriteBatch.Draw(texture, start, null, Color.White,
                (float)Math.Atan2(end.Y - start.Y, end.X - start.X),
                new Vector2(0f, (float)texture.Height / 2),
                new Vector2(Vector2.Distance(start, end), 1f),
                SpriteEffects.None, 0f);
        }
    }

    public static class Convert
    {
        public static Vector2 To2(this Vector3 vector)
        {
            return new Vector2(vector.X, vector.Y);
        }

        public static Vector3 To3(this Vector2 vector)
        {
            return new Vector3(vector.X, vector.Y, 0);
        }

        public static Vector3 To3(this Vector2 vector, int z)
        {
            return new Vector3(vector.X, vector.Y, z);
        }
    }
}
