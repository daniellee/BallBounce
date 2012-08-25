using System.IO;
using BallBounce.Levels;
using NUnit.Framework;

namespace BallBounce.Test
{
    [TestFixture]
    public class LevelSerializationTests
    {
        private LevelSerializer _serializer;

        [SetUp]
        public void SetUp()
        {
            _serializer = new LevelSerializer();
        }

        [Test]
        public void IfValidJSONFileWithOneRow_ShouldLoadLevelWithOneRow()
        {
            var streamReader = new StreamReader("TestData\\1.json");
            var levelData = _serializer.DeserializeFromReader(streamReader);
            streamReader.Close();

            Assert.That(levelData.LevelNumber, Is.EqualTo(1));
            Assert.That(levelData.Bricks.Count, Is.GreaterThan(0));
        }

        [Test, Ignore]
        public void SerializeLevelIntoJSONFile()
        {
            var levelData = new LevelData(1);
            const int value = 10;
            for (int row = 2; row < 7;row++ )
                for (int col = 0; col < 13; col++)
                {
                    levelData.AddBrickData(row, col, value);
                }
                

            _serializer.SaveToFile(levelData);
        }


    }
}