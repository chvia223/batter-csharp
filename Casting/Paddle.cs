using System;

namespace cse210_batter_csharp.Casting
{
    public class Paddle : Actor
    {
        public Paddle()
        {
            SetHeight(Constants.PADDLE_HEIGHT);
            SetWidth(Constants.PADDLE_WIDTH);
            SetImage(Constants.IMAGE_PADDLE); 
            SetPosition(new Point(Constants.PADDLE_X, Constants.PADDLE_Y));
        }
    }
}