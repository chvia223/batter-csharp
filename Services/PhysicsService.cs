using System;
using Raylib_cs;
using cse210_batter_csharp.Casting;

namespace cse210_batter_csharp.Services
{
    /// <summary>
    /// Handles all the physics related parts of the game such as
    /// determining collisions.
    /// </summary>
    public class PhysicsService
    {
        public PhysicsService()
        {

        }

        /// <summary>
        /// Returns true if the two actors overlap.
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public bool IsCollision(Actor first, Actor second)
        {
            int x1 = first.GetX();
            int y1 = first.GetY();
            int width1 = first.GetWidth();
            int height1 = first.GetHeight();

            Raylib_cs.Rectangle rectangle1
                = new Raylib_cs.Rectangle(x1, y1, width1, height1);

            int x2 = second.GetX();
            int y2 = second.GetY();
            int width2 = second.GetWidth();
            int height2 = second.GetHeight();

            Raylib_cs.Rectangle rectangle2
                = new Raylib_cs.Rectangle(x2, y2, width2, height2);

            return Raylib.CheckCollisionRecs(rectangle1, rectangle2);
        }

        public bool IsHorizontalWallCollision(Actor actor)
        {
            return (actor.GetRightEdge() >= Constants.MAX_X || actor.GetLeftEdge() <= 0);
        }


        public bool IsTopWallCollision(Actor actor)
        {
            return actor.GetTopEdge() <= 0;
        }

        public bool IsBottomWallCollision(Actor actor)
        {
            return actor.GetBottomEdge() >= Constants.MAX_Y;
        }

        public bool IsHorizontalCollision(Actor actor1, Actor actor2)
        {
            if (actor1.GetLeftEdge() <= (actor2.GetRightEdge()) || 
                actor1.GetRightEdge() >= (actor2.GetLeftEdge()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsActorVerticalCollision(Actor actor1, Actor actor2)
        {
            if (actor1.GetTopEdge() <= (actor2.GetBottomEdge())  || 
                actor1.GetBottomEdge() >= (actor2.GetTopEdge()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

}