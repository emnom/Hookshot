using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Extensions;


namespace Main
{
    static class PhysicsFuncs
    {

        public static Vector2 Extend(Vector2 start, Vector2 direction)
        {
            Ray ray = new Ray(start.To3(), direction.To3());

            int? minDistId = null;
            float? lowestDist = null;
            float? currentDist = null;

            foreach(KeyValuePair<int, Obj> solid in Obj.Solids)
            {
                currentDist = ray.Intersects(solid.Value.Hitbox);

                if (currentDist != null)
                {
                    if(minDistId == null)
                    {
                        minDistId = solid.Key;
                        lowestDist = currentDist;
                    }
                    else if (currentDist < lowestDist)
                    {
                        minDistId = solid.Key;
                        lowestDist = currentDist;
                    }
                }
            }
            if (lowestDist != null)
            {
                return Vector2.Multiply(Vector2.Normalize(ray.Direction.To2()), (float)lowestDist);
            }
            else
            {
                return Vector2.Zero;
            }
        }



    }
}