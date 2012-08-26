using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallBounceLogic.Levels
{
    class LevelSerializer:ILevelDeserialize
    {
        public LevelData LoadFromFile(int levelNumber)
        {
            return new LevelData(levelNumber) { Bricks = new List<Entities.BrickData> { new Entities.BrickData{ RowNumber = 2, ColumnNumber = 0}} };
        }
    }
}
