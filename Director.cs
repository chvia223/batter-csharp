using System;
using System.Collections.Generic;
using cse210_batter_csharp.Casting;
using cse210_batter_csharp.Services;
using cse210_batter_csharp.Scripting;

namespace cse210_batter_csharp
{
    /// <summary>
    /// The director is responsible to direct the game, including to keep track of all
    /// the actors and to control the sequence of play.
    /// 
    /// Stereotype:
    ///     Controller
    /// </summary>
    public class Director
    {
        private AudioService _audioService = new AudioService();
        private bool _keepPlaying = true;
        private Dictionary<string, List<Actor>> _cast;
        private Dictionary<string, List<Action>> _script;

        public Director(Dictionary<string, List<Actor>> cast, Dictionary<string, List<Action>> script)
        {
            _cast = cast;
            _script = script;
        }

        /// <summary>
        /// This method starts the game and continues running until it is finished.
        /// </summary>
        public void Direct()
        {
            while (_keepPlaying)
            {
                CueAction("input");
                CueAction("update");
                CueAction("output");

                if (_cast["balls"].Count == 0)
                {
                    _audioService.PlaySound(Constants.SOUND_OVER);
                    _keepPlaying = false;
                    Console.WriteLine("Game over!");
                }

                if (_cast["bricks"].Count == 0)
                {
                    _audioService.PlaySound(Constants.SOUND_OVER);
                    _keepPlaying = false;
                    Console.WriteLine("You win!");
                }

                if (Raylib_cs.Raylib.WindowShouldClose())
                {
                    _audioService.PlaySound(Constants.SOUND_OVER);
                    _keepPlaying = false;
                    Console.WriteLine("Game over!");
                }
            }

            
        }

        /// <summary>
        /// Executes all of the actions for the provided phase.
        /// </summary>
        /// <param name="phase"></param>
        private void CueAction(string phase)
        {
            List<Action> actions = _script[phase];

            foreach (Action action in actions)
            {
                action.Execute(_cast);
            }
        }

    }
}
