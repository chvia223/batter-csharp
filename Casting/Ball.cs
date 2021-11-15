using System;

namespace cse210_batter_csharp.Casting
{
    public class Ball : Actor
    {
        public Ball()
        {
            SetHeight(Constants.BALL_HEIGHT);
            SetWidth(Constants.BALL_WIDTH);
            SetImage(Constants.IMAGE_BALL); 
            SetPosition(new Point(Constants.BALL_X, Constants.BALL_Y));
            SetVelocity(new Point(5,-5));
        }
    }
}