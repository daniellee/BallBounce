using BallBounceMVC.Entities;
using BallBounceMVC.Models;
using Microsoft.Xna.Framework;
using NUnit.Framework;

namespace BallBounceMVC.Test
{
    [TestFixture]
    public class WorldTests
    {
        private World _world;

        [SetUp]
        public void SetUp()
        {
            _world = new World(800, 600) { GameSpeed = 1f };
        }

        [Test]
        public void IfBallGoesDeadThenNumberOfLivesIsReducedByOne()
        {
            SetupBallToDie();

            _world.Update(10.0f);

            Assert.That(_world.Lives, Is.EqualTo(2));
        }

        [Test]
        public void IfNumberOfLivesIsZeroThenGameOver()
        {
            SetupBallToDie();
            _world.Lives = 1;

            _world.Update(1.0f);
            _world.Update(1.0f);

            Assert.That(_world.Lives, Is.EqualTo(0));
            Assert.That(_world.GetBallsModel().GetFirstBall(), Is.Null);
            Assert.That(_world.CurrentState, Is.EqualTo(GameState.GameOver));
        }

        [Test]
        public void IfBallGoesDeadThenLevelShouldBeRestartedWithNewBall()
        {
            SetupBallToDie();

            _world.Update(1.0f);
            _world.Update(1.0f);

            Assert.That(_world.GetBallsModel().GetFirstBall(), Is.Not.Null);
        }

        [Test]
        public void IfBallGoesDeadThenLevelShouldBeRestartedWithPlayerShipMovedBackToMiddle()
        {
            SetupBallToDie();

            _world.GetPlayerModel().Update(50);
            _world.Update(1.0f);
            _world.Update(1.0f);

            Assert.That(_world.GetPlayerModel().GetShip().X, Is.EqualTo(_world.GetViewport().Center.X));
        }

        private void SetupBallToDie()
        {
            var firstBall = _world.GetBallsModel().GetFirstBall();
            firstBall.Position = new Vector2(785f, 1f);
            firstBall.Velocity = new Vector2(0f, -5f);
        }
    }
}