using BallBounceMVC.Models;

namespace BallBounceMVC.Levels
{
    public class LevelLoader
    {
        private readonly ILevelDeserialize _levelSerializer;
        private readonly int _insideFrameLeft;
        private readonly int _insideFrameRight;
        private readonly int _insideFrameTop;

        public LevelLoader(ILevelDeserialize levelSerializer, int insideFrameLeft, int insideFrameRight, 
            int insideFrameTop)
        {
            _levelSerializer = levelSerializer;
            _insideFrameLeft = insideFrameLeft;
            _insideFrameRight = insideFrameRight;
            _insideFrameTop = insideFrameTop;
        }

        public LevelModel LoadLevel(int levelNumber)
        {
            var levelData = _levelSerializer.LoadFromFile(levelNumber);

            var level = new LevelModel { LevelNumber = levelData.LevelNumber };

            foreach (var brickData in levelData.Bricks)
            {
                level.AddBrick(brickData, 
                    ConvertColumnNumberToXPosition(brickData.ColumnNumber), 
                    ConvertRowNumberToYPosition(brickData.RowNumber));
            }

            return level;
        }

        private int ConvertRowNumberToYPosition(int rowNumber)
        {
            return _insideFrameTop + (30 * rowNumber);
        }

        private int ConvertColumnNumberToXPosition(int columnNumber)
        {
            return _insideFrameLeft + (60 * columnNumber);
        }
    }
}