using System.Collections.Generic;
using cse210_batter_csharp.Casting;
using cse210_batter_csharp.Services;


namespace cse210_batter_csharp.Scripting
{
    /// <summary>
    /// An action to get user input and update actors accordingly.
    /// </summary>
    public class ControlActorsAction : Action
    {
        private InputService _inputService;

        public ControlActorsAction(InputService inputService)
        {
            _inputService = inputService;
        }

        public override void Execute(Dictionary<string, List<Actor>> cast)
        {
            Point direction = _inputService.GetDirection();
            Point velocity = new Point(0,0);
            Actor paddle = cast["paddle"][0];

            
            // This logic makes sure the paddle can't move off screen
            if (paddle.GetRightEdge() > Constants.MAX_X)
            {
                if (direction.GetX() == 1)
                {
                    velocity.Scale(0);
                }
                else
                {
                    velocity = direction.Scale(Constants.PADDLE_SPEED);
                }
            }
            else if (paddle.GetLeftEdge() < 0)
            {
                if (direction.GetX() == -1)
                {
                    velocity.Scale(0);
                }
                else
                {
                    velocity = direction.Scale(Constants.PADDLE_SPEED);
                }    
            }
            else
            {
                velocity = direction.Scale(Constants.PADDLE_SPEED);
            }
 
            paddle.SetVelocity(velocity);
        }
        
    }
}