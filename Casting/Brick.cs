using System;

namespace cse210_batter_csharp.Casting
{
    /// <summary>
    /// Base class for all actors in the game.
    /// </summary>
    public class Brick : Actor
    {

        public Brick()
        {
            SetWidth(Constants.BRICK_WIDTH);
            SetHeight(Constants.BRICK_HEIGHT);
            SetImage(Constants.IMAGE_BRICK);
        }

    }

}