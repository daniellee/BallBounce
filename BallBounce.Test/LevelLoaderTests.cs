using System.Linq;
using BallBounce.Levels;
using Moq;
using NUnit.Framework;

namespace BallBounce.Test
{
    public class LevelLoaderTests
    {
        private const int FrameWidth = 10;
        private const int ViewPortWidth = 800;
        private Mock<ILevelDeserialize> _levelDeserializer;
        private LevelLoader _levelLoader;

        [SetUp]
        public void SetUp()
        {
            _levelDeserializer = new Mock<ILevelDeserialize>();
            _levelLoader = new LevelLoader(_levelDeserializer.Object, FrameWidth, ViewPortWidth - FrameWidth, FrameWidth);
        }

        [Test]
        public void LevelLoaderShouldReturnLevelModelWithLevelNumberSet()
        {
            const int levelNumber = 1;
            _levelDeserializer.Setup(ld => ld.LoadFromFile(levelNumber)).Returns(new LevelData(levelNumber));

            var levelModel = _levelLoader.LoadLevel(levelNumber);

            Assert.That(levelModel.LevelNumber, Is.EqualTo(1));
        }

        [Test]
        public void LevelLoaderShouldReturnLevelModelWithBricks()
        {
            const int levelNumber = 1;
            var levelData = new LevelData(levelNumber);
            levelData.AddBrickData(1, 1, 10);
            levelData.AddBrickData(1, 2, 10);
            _levelDeserializer.Setup(ld => ld.LoadFromFile(levelNumber)).Returns(levelData);

            var levelModel = _levelLoader.LoadLevel(levelNumber);

            Assert.That(levelModel.GetBricks().Count, Is.EqualTo(2));
        }

        [Test]
        public void LevelLoaderShouldReturnLevelModelWithBricksWithXYPositions()
        {
            const int levelNumber = 1;
            var levelData = new LevelData(levelNumber);
            levelData.AddBrickData(1, 0, 10);
            levelData.AddBrickData(1, 1, 10);
            _levelDeserializer.Setup(ld => ld.LoadFromFile(levelNumber)).Returns(levelData);

            var levelModel = _levelLoader.LoadLevel(levelNumber);

            Assert.That(levelModel.GetBricks().First().Boundary.Location.X, Is.EqualTo(FrameWidth));
            Assert.That(levelModel.GetBricks().First().Boundary.Location.Y, Is.EqualTo(40));
        }
    }
}