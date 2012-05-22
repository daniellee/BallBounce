using BallBounceMVC.Entities;
using BallBounceMVC.Models;

namespace BallBounceMVC.Levels
{
    public class LevelWithFourBricks: LevelModel
    {
        public LevelWithFourBricks()
        {
            _bricks.Add(new Brick(400, 300));
            _bricks.Add(new Brick(440, 300));
            _bricks.Add(new Brick(400, 330));
            _bricks.Add(new Brick(440, 330));
        }
    }
}