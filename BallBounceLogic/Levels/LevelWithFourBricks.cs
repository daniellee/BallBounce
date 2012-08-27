using BallBounceLogic.Entities;
using BallBounceLogic.Models;

namespace BallBounceLogic.Levels
{
    public class LevelWithFourBricks : LevelModel
    {
        public LevelWithFourBricks()
        {
            Bricks.Add(new Brick(400, 300, 1f) { ColumnNumber = 0, RowNumber = 1 });
            Bricks.Add(new Brick(460, 300, 1f) { ColumnNumber = 1, RowNumber = 1 });
            Bricks.Add(new Brick(400, 330, 1f) { ColumnNumber = 0, RowNumber = 2 });
            Bricks.Add(new Brick(460, 330, 1f) { ColumnNumber = 1, RowNumber = 2 });
        }
    }
}