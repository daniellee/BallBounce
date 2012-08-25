using BallBounce.Levels;
using BallBounce.Models;
using Microsoft.Xna.Framework;
using NUnit.Framework;

namespace BallBounce.Test
{
    [TestFixture]
    public class MultipleBrickCollisionTests
    {
        private World _world;
        private BallsModel _ballsModel;
        private const int BoxLength = 18;

        [SetUp]
        public void Setup()
        {
            _world = new World(800, 600) { GameSpeed = 2f };
            _world.LoadLevel(new LevelWithFourBricks());

            _ballsModel = new BallsModel(_world, BoxLength, BoxLength, new Vector2(0f, 0f), new Vector2(0f, 0f));
        }

        [Test]
        public void Ball_TravellingUpHitsTwoBricks_ShouldReflectBackOnlyOnYAxis()
        {
            var firstBall = _ballsModel.GetFirstBall();
            firstBall.Position = new Vector2(458, 363f);
            firstBall.Velocity = new Vector2(1f, -4f);

            _ballsModel.Update(1.0f);

            Assert.That(firstBall.Velocity.Y, Is.GreaterThan(0));
            Assert.That(firstBall.Velocity.X, Is.EqualTo(1f));
            Assert.That(firstBall.Position.Y, Is.EqualTo(363f));
        }

        [Test]
        public void Ball_TravellingDownHitsTwoBricks_ShouldReflectBackOnlyOnYAxis()
        {
            var firstBall = _ballsModel.GetFirstBall();
            firstBall.Position = new Vector2(458, 280f);
            firstBall.Velocity = new Vector2(1f, 4f);

            _ballsModel.Update(1.0f);

            Assert.That(firstBall.Velocity.Y, Is.LessThan(0));
            Assert.That(firstBall.Velocity.X, Is.EqualTo(1f));
            Assert.That(firstBall.Position.Y, Is.EqualTo(280f));
        }

        [Test]
        public void Ball_TravellingRightHitsTwoBricks_ShouldReflectBackOnlyOnXAxis()
        {
            var firstBall = _ballsModel.GetFirstBall();
            firstBall.Position = new Vector2(380f, 328f);
            firstBall.Velocity = new Vector2(4f, 1f);

            _ballsModel.Update(1.0f);

            Assert.That(firstBall.Velocity.X, Is.LessThan(0));
            Assert.That(firstBall.Velocity.Y, Is.EqualTo(1f));
            Assert.That(firstBall.Position.X, Is.EqualTo(380f));
        }

        [Test]
        public void Ball_TravellingLeftHitsTwoBricks_ShouldReflectBackOnlyOnXAxis()
        {
            var firstBall = _ballsModel.GetFirstBall();
            firstBall.Position = new Vector2(522f, 328f);
            firstBall.Velocity = new Vector2(-4f, 1f);

            _ballsModel.Update(1.0f);

            Assert.That(firstBall.Velocity.X, Is.GreaterThan(0));
            Assert.That(firstBall.Velocity.Y, Is.EqualTo(1f));
            Assert.That(firstBall.Position.X, Is.EqualTo(522f));
        }
    }
}