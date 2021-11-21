using System.Collections.Generic;
using cse210_batter_csharp.Casting;
using cse210_batter_csharp.Services;


namespace cse210_batter_csharp
{
    public class HandleCollisionsAction : Action
    {
        private AudioService _audioService = new AudioService();
        private PhysicsService _physicsService = new PhysicsService();
        private List<Actor> _bricksToRemove = new List<Actor>();
        private List<Actor> _ballsToRemove = new List<Actor>();
        
        public HandleCollisionsAction(PhysicsService physicsService, AudioService audioService)
        {
            _physicsService = physicsService;
            _audioService = audioService;
        }

        public override void Execute(Dictionary<string, List<Actor>> cast)
        {
            List<Actor> balls = cast["balls"];
            Actor paddle = cast["paddle"][0];

            List<Actor> bricks = cast["bricks"];

            
            foreach (Ball ball in balls)
            {
                foreach (Actor brick in bricks)
                {
                    if (_physicsService.IsCollision(ball, brick))
                    {
                        if (_physicsService.IsActorVerticalCollision(ball, brick))
                        {
                            ball.VerticalBounce();
                            _bricksToRemove.Add(brick);
                            _audioService.PlaySound(Constants.SOUND_BOUNCE);
                            
                            break;
                        }
                        if (_physicsService.IsHorizontalCollision(ball, brick))
                        {    
                            ball.HorizontalBounce();
                            _bricksToRemove.Add(brick);
                            _audioService.PlaySound(Constants.SOUND_BOUNCE);

                            break;
                        }
  
                    }
                    
                }

            
                if (_physicsService.IsHorizontalWallCollision(ball))
                {    
                    ball.HorizontalBounce();
                    _audioService.PlaySound(Constants.SOUND_BOUNCE);
                }

                if (_physicsService.IsTopWallCollision(ball))
                {
                    ball.VerticalBounce();
                    _audioService.PlaySound(Constants.SOUND_BOUNCE);
                }

                if (_physicsService.IsBottomWallCollision(ball))
                {
                    _ballsToRemove.Add(ball);
                }
                
                if (_physicsService.IsCollision(ball, paddle))
                {
                    if (_physicsService.IsActorVerticalCollision(ball, paddle))
                    {
                        ball.VerticalBounce();
                        _audioService.PlaySound(Constants.SOUND_BOUNCE);
                    }
                    else if (_physicsService.IsHorizontalCollision(ball, paddle))
                    {    
                        ball.HorizontalBounce();
                        _audioService.PlaySound(Constants.SOUND_BOUNCE);
                    }
                    
                }
            }

            ActorsCleanUp(cast);
        }

        private void ActorsCleanUp(Dictionary<string, List<Actor>> cast)
        {
            foreach (Actor brick in _bricksToRemove)
            {
                cast["bricks"].Remove(brick);
            }

            foreach (Actor ball in _ballsToRemove)
            {
                cast["balls"].Remove(ball);
            }

            _ballsToRemove.Clear();
            _bricksToRemove.Clear();
        }
    }
}