using BallBounceLogic.Entities;
using BallBounceLogic.Models;

namespace BallBounceLogic.Levels
{
    public class LevelWithOneBrick: LevelModel
    {
        public LevelWithOneBrick()
        {
            Bricks.Add(new Brick(400, 300, 1f));
        }
    }
}