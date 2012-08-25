using System.Collections.Generic;
using BallBounce.Entities;

namespace BallBounce.Models
{
    public class LevelModel
    {
        protected IList<Brick> Bricks;
        public const int MaxNumberOfRows = 20;
        public const int MaxNumberOfColumns = 13;

        public LevelModel()
        {
            Bricks = new List<Brick>();
        }

        public int LevelNumber { get; set; }

        public IList<Brick> GetBricks()
        {
            return Bricks;
        }

        public void AddBrick(BrickData brickData, int xPos, int yPos)
        {
            var brick = new Brick(xPos, yPos) {ColumnNumber = brickData.ColumnNumber, RowNumber = brickData.RowNumber};
            Bricks.Add(brick);
        }
    }
}