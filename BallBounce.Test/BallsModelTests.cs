using System.Diagnostics;
using BallBounceLogic.Models;
using Microsoft.Xna.Framework;
using NUnit.Framework;
namespace BallBounceLogic.Test
{
    [TestFixture]
    public class BallsModelTests
    {
        private World _world;
        private BallsModel _ballsModel;
        private const int BoxLength = 18;

        [SetUp]
        public void Setup()
        {
            _world = new World(800, 600, 1f) { GameSpeed = 1f };

            _ballsModel = new BallsModel(_world, BoxLength, BoxLength, new Vector2(0f, 0f), new Vector2(0f, 0f));
        }

        [Test]
        public void BallMovesTheCorrectDistanceInRightDirection()
        {
            _ballsModel.GetFirstBall().Position = new Vector2(0f, 0f);
            _ballsModel.GetFirstBall().Velocity = new Vector2(1f, 1f);

            _ballsModel.Update(1.0f);

            Assert.That(_ballsModel.GetFirstBall().Position.X, Is.EqualTo(1f));
            Assert.That(_ballsModel.GetFirstBall().Position.Y, Is.EqualTo(1f));
        }

        [Test]
        public void NewBallCreatedAtStartup()
        {
            Assert.That(_ballsModel.GetFirstBall(), Is.Not.Null);
        }

        [Test]
        public void DefaultPositionSetForNewBall()
        {
            Assert.That(_ballsModel.GetFirstBall().Position, Is.Not.Null);
        }

        [Test]
        public void DefaultVelocitySetForNewBall()
        {
            Assert.That(_ballsModel.GetFirstBall().Velocity, Is.Not.Null);
        }

        [Test]
        public void HeightAndWidthSetForNewBall()
        {
            Assert.That(_ballsModel.GetFirstBall().Height, Is.EqualTo(BoxLength));
            Assert.That(_ballsModel.GetFirstBall().Width, Is.EqualTo(BoxLength));
        }

        [Test]
        public void BallBouncesDownWhenHitsTheTopSideOfFrameWithWidth11()
        {
            var firstBall = _ballsModel.GetFirstBall();
            firstBall.Position = new Vector2(15f, 14f);
            firstBall.Velocity = new Vector2(0f, -5f);

            _ballsModel.Update(1.0f);
            _ballsModel.Update(1.0f);

            Assert.That(firstBall.Position.X, Is.EqualTo(15f));
            Assert.That(firstBall.Position.Y, Is.EqualTo(14f));
        }

        [Test]
        public void BallBouncesRightWhenHitsTheLeftSideOfFrameWithWidth11()
        {
            var firstBall = _ballsModel.GetFirstBall();
            firstBall.Position = new Vector2(14f, 15f);
            firstBall.Velocity = new Vector2(-5f, 0f);

            _ballsModel.Update(1.0f);
            _ballsModel.Update(1.0f);

            Assert.That(firstBall.Position.X, Is.EqualTo(14f));
            Assert.That(firstBall.Position.Y, Is.EqualTo(15f));
        }

        [Test]
        public void BallBouncesLeftWhenHitsTheRightSideOfFrameWithWidth11()
        {
            var firstBall = _ballsModel.GetFirstBall();
            firstBall.Position = new Vector2(785f, 15f);
            firstBall.Velocity = new Vector2(5f, 0f);

            _ballsModel.Update(1.0f);
            _ballsModel.Update(1.0f);

            Assert.That(firstBall.Position.X, Is.EqualTo(785f));
            Assert.That(firstBall.Position.Y, Is.EqualTo(15f));
        }

        [Test]
        public void BallIsRemovedIfItLeavesViewport()
        {
            var firstBall = _ballsModel.GetFirstBall();
            firstBall.Position = new Vector2(785f, 1f);
            firstBall.Velocity = new Vector2(0f, -5f);

            _ballsModel.Update(1.0f);
            _ballsModel.Update(1.0f);

            Assert.That(_ballsModel.GetAllBalls().Count, Is.EqualTo(0));
        }

        [Test]
        public void BallBouncesUpWhenItHitsThePlayer()
        {
            var firstBall = _ballsModel.GetFirstBall();
            firstBall.Position = new Vector2(400f, 520f);
            firstBall.Velocity = new Vector2(0f, 5f);

            _ballsModel.Update(1.0f);
            _ballsModel.Update(1.0f);

            Assert.That(firstBall.Position.Y, Is.EqualTo(520f));
        }

        [Test]
        public void BallXVelocityChangesALotToTheLeftWhenItHitsLeftEndOfPlayer()
        {
            var firstBall = _ballsModel.GetFirstBall();
            firstBall.Position = new Vector2(400f, 520f);
            firstBall.Velocity = new Vector2(0f, -5f);

            _ballsModel.Update(1.0f);
            _ballsModel.Update(1.0f);

            Debug.WriteLine(_world.GetPlayerModel().GetShip().Left);
            Debug.WriteLine(_world.GetPlayerModel().GetShip().Right);

            Assert.That(firstBall.Velocity.X, Is.EqualTo(-3.5f));
            Assert.That(firstBall.Position.Y, Is.LessThan(525f));
        }

        [Test]
        public void BallXVelocityChangesALotToTheRightWhenItHitsRightEndOfPlayer()
        {
            var firstBall = _ballsModel.GetFirstBall();
            firstBall.Position = new Vector2(515f, 520f);
            firstBall.Velocity = new Vector2(0f, -5f);

            _ballsModel.Update(1.0f);
            _ballsModel.Update(1.0f);

            Assert.That(firstBall.Velocity.X, Is.EqualTo(3.5f));
            Assert.That(firstBall.Position.Y, Is.LessThan(525f));
        }

        [Test]
        public void BallXVelocityChangesSomewhatToTheLeftWhenItHitsFarLeftZoneOfPlayer()
        {
            var firstBall = _ballsModel.GetFirstBall();
            firstBall.Position = new Vector2(425f, 520f);
            firstBall.Velocity = new Vector2(0f, -5f);

            _ballsModel.Update(1.0f);
            _ballsModel.Update(1.0f);

            Assert.That(firstBall.Velocity.X, Is.EqualTo(-2.0f));
            Assert.That(firstBall.Position.Y, Is.LessThan(525f));
        }

        [Test]
        public void BallXVelocityChangesSomewhatToTheRightWhenItHitsFarRightZoneOfPlayer()
        {
            var firstBall = _ballsModel.GetFirstBall();
            firstBall.Position = new Vector2(498f, 520f);
            firstBall.Velocity = new Vector2(0f, -5f);

            _ballsModel.Update(1.0f);
            _ballsModel.Update(1.0f);

            Assert.That(firstBall.Velocity.X, Is.EqualTo(2.0f));
            Assert.That(firstBall.Position.Y, Is.LessThan(525f));
        }

        [Test]
        public void BallXVelocityChangesABitToTheLeftWhenItHitsMiddleLeftZoneOfPlayer()
        {
            var firstBall = _ballsModel.GetFirstBall();
            firstBall.Position = new Vector2(440f, 520f);
            firstBall.Velocity = new Vector2(0f, -5f);

            _ballsModel.Update(1.0f);
            _ballsModel.Update(1.0f);

            Assert.That(firstBall.Velocity.X, Is.EqualTo(-1.0f));
            Assert.That(firstBall.Position.Y, Is.LessThan(525f));
        }

        [Test]
        public void BallXVelocityChangesABitToTheRightWhenItHitsMiddleRightZoneOfPlayer()
        {
            var firstBall = _ballsModel.GetFirstBall();
            firstBall.Position = new Vector2(480f, 520f);
            firstBall.Velocity = new Vector2(0f, -5f);

            _ballsModel.Update(1.0f);
            _ballsModel.Update(1.0f);

            Assert.That(firstBall.Velocity.X, Is.EqualTo(1.0f));
            Assert.That(firstBall.Position.Y, Is.LessThan(525f));
        }

        [Test]
        public void BallXVelocityChangesABitToTheRightWhenItHitsCentreRightZoneOfPlayer()
        {
            var firstBall = _ballsModel.GetFirstBall();
            firstBall.Position = new Vector2(465f, 520f);
            firstBall.Velocity = new Vector2(0f, -5f);

            _ballsModel.Update(1.0f);
            _ballsModel.Update(1.0f);

            Assert.That(firstBall.Velocity.X, Is.EqualTo(0.5f));
            Assert.That(firstBall.Position.Y, Is.LessThan(525f));
        }

        [Test]
        public void BallXVelocityIsUnchangedWhenItHitsCentreLeftZoneOfPlayer()
        {
            var firstBall = _ballsModel.GetFirstBall();
            firstBall.Position = new Vector2(455f, 520f);
            firstBall.Velocity = new Vector2(0f, -5f);

            _ballsModel.Update(1.0f);
            _ballsModel.Update(1.0f);

            Assert.That(firstBall.Velocity.X, Is.EqualTo(0.0f));
            Assert.That(firstBall.Position.Y, Is.LessThan(525f));
        }
    }
}