using BallBounce.Levels;
using BallBounce.Models;
using Microsoft.Xna.Framework;
using NUnit.Framework;

namespace BallBounce.Test
{
    [TestFixture]
    public class OneBrickCollisionTests
    {
        private World _world;
        private BallsModel _ballsModel;
        private const int BoxLength = 18;

        [SetUp]
        public void Setup()
        {
            _world = new World(800, 600) { GameSpeed = 2f };
            _world.LoadLevel(new LevelWithOneBrick());

            _ballsModel = new BallsModel(_world, BoxLength, BoxLength, new Vector2(0f, 0f), new Vector2(0f, 0f));
        }

        [TestCase(383f)]
        [TestCase(400f)]
        [TestCase(410f)]
        [TestCase(420f)]
        [TestCase(450f)]
        [TestCase(459f)]
        public void Ball_TravellingUpHitsBrickBottom_ShouldReflectBack(float xPosition)
        {
            var firstBall = _ballsModel.GetFirstBall();
            firstBall.Position = new Vector2(xPosition, 332f);
            firstBall.Velocity = new Vector2(0f, -4f);

            _ballsModel.Update(1.0f);

            Assert.That(firstBall.Velocity.Y, Is.GreaterThan(0));
            Assert.That(firstBall.Position.Y, Is.EqualTo(332f));
        }

        [TestCase(383f)]
        [TestCase(400f)]
        [TestCase(410f)]
        [TestCase(420f)]
        [TestCase(450f)]
        [TestCase(459f)]
        public void Ball_TravellingDownHitsBrickTop_ShouldReflectBack(float xPosition)
        {
            var firstBall = _ballsModel.GetFirstBall();
            firstBall.Position = new Vector2(xPosition, 280f);
            firstBall.Velocity = new Vector2(0f, 4f);

            _ballsModel.Update(1.0f);

            Assert.That(firstBall.Velocity.Y, Is.LessThan(0));
            Assert.That(firstBall.Position.Y, Is.EqualTo(280f));
        }

        [TestCase(283f)]
        [TestCase(300f)]
        [TestCase(310f)]
        [TestCase(320f)]
        [TestCase(325f)]
        [TestCase(329f)]
        public void Ball_TravellingRightHitsBrickLeft_ShouldReflectBack(float yPosition)
        {
            var firstBall = _ballsModel.GetFirstBall();
            firstBall.Position = new Vector2(382f, yPosition);
            firstBall.Velocity = new Vector2(4f, 0f);

            _ballsModel.Update(1.0f);

            Assert.That(firstBall.Velocity.X, Is.LessThan(0));
            Assert.That(firstBall.Position.X, Is.EqualTo(382f));
        }

        [TestCase(283f)]
        [TestCase(300f)]
        [TestCase(310f)]
        [TestCase(320f)]
        [TestCase(325f)]
        [TestCase(329f)]
        public void Ball_TravellingLeftHitsBrickRight_ShouldReflectBack(float yPosition)
        {
            var firstBall = _ballsModel.GetFirstBall();
            firstBall.Position = new Vector2(462f, yPosition);
            firstBall.Velocity = new Vector2(-4f, 0f);

            _ballsModel.Update(1.0f);

            Assert.That(firstBall.Velocity.X, Is.GreaterThan(0));
            Assert.That(firstBall.Position.X, Is.EqualTo(462f));
        }

    }
}