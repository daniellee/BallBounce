using BallBounceLogic.Models;

namespace BallBounceLogic.Levels
{
    public class LevelLoader
    {
        private readonly ILevelDeserialize _levelSerializer;
        private readonly int _insideFrameLeft;
        private readonly int _insideFrameRight;
        private readonly int _insideFrameTop;
        private readonly float _scale;

        public LevelLoader(ILevelDeserialize levelSerializer, int insideFrameLeft, int insideFrameRight, int insideFrameTop, float scale)
        {
            _levelSerializer = levelSerializer;
            _insideFrameLeft = insideFrameLeft;
            _insideFrameRight = insideFrameRight;
            _insideFrameTop = insideFrameTop;
            _scale = scale;
        }

        public LevelModel LoadLevel(int levelNumber)
        {
            var levelData = _levelSerializer.LoadFromFile(levelNumber);

            var level = new LevelModel { LevelNumber = levelData.LevelNumber };

            foreach (var brickData in levelData.Bricks)
            {
                level.AddBrick(brickData, 
                    ConvertColumnNumberToXPosition(brickData.ColumnNumber), 
                    ConvertRowNumberToYPosition(brickData.RowNumber),
                    _scale);
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