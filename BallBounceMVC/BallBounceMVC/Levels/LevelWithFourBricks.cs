using BallBounceMVC.Entities;
using BallBounceMVC.Models;

namespace BallBounceMVC.Levels
{
    public class LevelWithFourBricks: LevelModel
    {
        public LevelWithFourBricks()
        {
            Bricks.Add(new Brick(400, 300));
            Bricks.Add(new Brick(440, 300));
            Bricks.Add(new Brick(400, 330));
            Bricks.Add(new Brick(440, 330));
        }
    }
}