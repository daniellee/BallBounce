using BallBounceMVC.Entities;
using BallBounceMVC.Models;
using Microsoft.Xna.Framework;
using NUnit.Framework;

namespace BallBounceMVC.Test
{
    [TestFixture]
    public class BrickTests
    {
        private World _world;
        private BallsModel _ballsModel;
        private const int BoxLength = 18;

        [SetUp]
        public void Setup()
        {
            _world = new World(800, 600) { GameSpeed = 1f };

            _ballsModel = new BallsModel(_world, BoxLength, BoxLength, new Vector2(0f, 0f), new Vector2(0f, 0f));
        }
        [TestCase(385f)]
        [TestCase(390f)]
        [TestCase(400f)]
        [TestCase(410f)]
        [TestCase(420f)]
        public void Ball_TravellingUpHitsBrickBottom_ShouldReflectBack(float xPosition)
        {
            var firstBall = _ballsModel.GetFirstBall();
            firstBall.Position = new Vector2(xPosition, 334f);
            firstBall.Velocity = new Vector2(0f, -5f);

            _ballsModel.Update(1.0f);
            _ballsModel.Update(1.0f);

            Assert.That(firstBall.Velocity.Y, Is.GreaterThan(0));
            Assert.That(firstBall.Position.Y, Is.EqualTo(334f));
        }

        [Test]
        public void Ball_TravellingDownHitsBrickTop_ShouldReflectBack()
        {
            var firstBall = _ballsModel.GetFirstBall();
            firstBall.Position = new Vector2(400f, 296f);
            firstBall.Velocity = new Vector2(0f, 5f);

            _ballsModel.Update(1.0f);
            _ballsModel.Update(1.0f);

            Assert.That(firstBall.Velocity.Y, Is.GreaterThan(0));
            Assert.That(firstBall.Position.Y, Is.EqualTo(296f));
        }

    }
}