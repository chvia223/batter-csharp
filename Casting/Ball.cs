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
            SetVelocity(new Point(Constants.BALL_DX,Constants.BALL_DY));     
        }

        public void VerticalBounce()
        {
            int dx = _velocity.GetX();
            int dy = _velocity.GetY();

            SetVelocity(new Point(dx, -dy));
        }

        public void HorizontalBounce()
        {
            int dx = _velocity.GetX();
            int dy = _velocity.GetY();

            SetVelocity(new Point(-dx, dy));
        }
    }
}