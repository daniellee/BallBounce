using BallBounce.Entities;
using BallBounce.Models;

namespace BallBounce.Levels
{
    public class LevelWithFourBricks : LevelModel
    {
        public LevelWithFourBricks()
        {
            Bricks.Add(new Brick(400, 300) { ColumnNumber = 0, RowNumber = 1 });
            Bricks.Add(new Brick(460, 300) { ColumnNumber = 1, RowNumber = 1 });
            Bricks.Add(new Brick(400, 330) { ColumnNumber = 0, RowNumber = 2 });
            Bricks.Add(new Brick(460, 330) { ColumnNumber = 1, RowNumber = 2 });
        }
    }
}