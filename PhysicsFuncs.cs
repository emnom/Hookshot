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


            Ray ray = new Ray(start.To3(), Vector3.Subtract(direction.To3(), start.To3()));

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
                return Vector2.Add(Vector2.Multiply(ray.Direction.To2(), (float)lowestDist), start);
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Failed");
                return Vector2.Zero;
            }
        }

        public static Vector2 Extend(Vector2 start, Vector2 direction, float? distance)
        {


            Ray ray = new Ray(start.To3(), Vector3.Subtract(direction.To3(), start.To3()));

            int? minDistId = null;
            float? lowestDist = null;
            float? currentDist = null;

            foreach (KeyValuePair<int, Obj> solid in Obj.Solids)
            {
                currentDist = ray.Intersects(solid.Value.Hitbox);

                if (currentDist != null)
                {
                    if (minDistId == null)
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
                distance = lowestDist*(ray.Direction.To2().Length());
                return Vector2.Multiply(ray.Direction.To2(), (float)lowestDist);
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Failed");
                return Vector2.Zero;
            }
        }

        public static Vector2 Extend(BoundingBox boundingBox, Vector2 direction)
        {
            Vector3[] corners = boundingBox.GetCorners();

            float? currentdist = null;
            float? lowestdist = null;
            int cornerNum = 0;
            Vector2 currentVector;
            Vector2 returned = Extend(corners[0].To2(), direction, lowestdist);

            for (int i = 1; i < 4; i++)
            {
                currentVector = Extend(corners[i].To2(), Vector2.Add(Vector2.Subtract(direction, corners[0].To2()), corners[i].To2()) , currentdist);
                if(currentdist < lowestdist)
                {
                    cornerNum = i;
                    returned = currentVector;
                    lowestdist = currentdist;
                }
            }


            return Vector2.Add(returned, corners[0].To2());
        }

        public static Vector2 Extend(BoundingBox boundingBox, Vector2 direction, float? dist)
        {
            Vector3[] corners = boundingBox.GetCorners();

            float? currentdist = null;
            float? lowestdist = null;
            int cornerNum = 0;
            Vector2 currentVector;
            Vector2 returned = Extend(corners[0].To2(), direction, lowestdist);

            for (int i = 1; i < 4; i++)
            {
                currentVector = Extend(corners[i].To2(), Vector2.Add(Vector2.Subtract(direction, corners[0].To2()), corners[i].To2()), currentdist);
                if (currentdist < lowestdist)
                {
                    cornerNum = i;
                    returned = currentVector;
                    lowestdist = currentdist;
                }
            }


            dist = lowestdist;
            return Vector2.Add(returned, corners[0].To2());
        }

    }
}