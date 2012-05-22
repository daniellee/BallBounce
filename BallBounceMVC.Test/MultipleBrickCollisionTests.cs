using BallBounceMVC.Levels;
using BallBounceMVC.Models;
using Microsoft.Xna.Framework;
using NUnit.Framework;

namespace BallBounceMVC.Test
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
        public void Ball_TravellingUpHitsTwoBricks_ShouldReflectBack()
        {
            var firstBall = _ballsModel.GetFirstBall();
            firstBall.Position = new Vector2(428, 334f);
            firstBall.Velocity = new Vector2(1f, -4f);

            _ballsModel.Update(1.0f);
            _ballsModel.Update(1.0f);

            Assert.That(firstBall.Velocity.Y, Is.GreaterThan(0));
            Assert.That(firstBall.Velocity.X, Is.EqualTo(1f));
            Assert.That(firstBall.Position.Y, Is.EqualTo(334f));
        }
    }
}