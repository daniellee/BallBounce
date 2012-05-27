using BallBounceMVC.Entities;
using BallBounceMVC.Models;

namespace BallBounceMVC.Levels
{
    public class LevelWithOneBrick: LevelModel
    {
        public LevelWithOneBrick()
        {
            Bricks.Add(new Brick(400, 300));
        }
    }
}