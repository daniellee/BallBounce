using System.Collections.Generic;
using BallBounceLogic.Entities;

namespace BallBounceLogic.Levels
{
    public class LevelData
    {
        public List<BrickData> Bricks { get; set; }
        public int LevelNumber { get; set; }

        public LevelData(int levelNumber)
        {
            LevelNumber = levelNumber;
            Bricks = new List<BrickData>();
        }
        public void AddBrickData(int rowNumber, int colNumber, int value)
        {
            Bricks.Add(new BrickData {RowNumber = rowNumber, ColumnNumber = colNumber, Value = value, NumberOfHits = 1});
        }
    }
}