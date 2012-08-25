using BallBounce.Entities;
using BallBounce.Models;

namespace BallBounce.Levels
{
    public class LevelWithOneBrick: LevelModel
    {
        public LevelWithOneBrick()
        {
            Bricks.Add(new Brick(400, 300));
        }
    }
}