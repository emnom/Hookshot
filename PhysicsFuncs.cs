using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;


namespace Main
{
    static class PhysicsFuncs
    {

        public static Vector2 Extend(Vector2 start, Vector2 direction)
        {                 

            if (start.Equals(direction))
            {
                return start;
            }

            int screenWidth = Game1._graphics.PreferredBackBufferWidth;
            int screenHeight = Game1._graphics.PreferredBackBufferHeight;


            //The vector pointing from start to direction
            Vector2 pointer = Vector2.Subtract(direction, start);

            //Makes a rectangle with one corner at start and the other corner at one of the corners of the screen
            Vector2 shortScreen = Vector2.Subtract(new Vector2(screenWidth * (Math.Sign(pointer.X) + 1) / 2,
                screenHeight * (Math.Sign(pointer.Y) + 1) / 2), start);

            //To find if it intersects the x or y axis
            Vector2 ratios = Vector2.Divide(shortScreen, pointer);

            if(ratios.X == ratios.Y)
            { 
                
                return new Vector2(screenWidth * (Math.Sign(pointer.X) + 1)/2,
                    screenHeight * (Math.Sign(pointer.Y) + 1)/2);
            }
            else if (ratios.X < ratios.Y)
            {
                return new Vector2(screenWidth * (Math.Sign(pointer.X) + 1) / 2,
                (pointer.Y * ((screenWidth * (Math.Sign(pointer.X) + 1) / 2) - start.X) / pointer.X) + start.Y);
            }
            else
            {
                return new Vector2((pointer.X * ((screenHeight * (Math.Sign(pointer.Y) + 1) / 2) - start.Y) / pointer.Y) + start.X,
                screenHeight * (Math.Sign(pointer.Y) + 1) / 2);

            }
        }



    }
}


