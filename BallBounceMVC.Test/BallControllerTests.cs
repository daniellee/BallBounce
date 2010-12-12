using BallBounceMVC.Controllers;
using BallBounceMVC.Models;
using Microsoft.Xna.Framework;
using NUnit.Framework;
namespace BallBounceMVC.Test
{
	[TestFixture]
	public class BallControllerTests
	{
		private BallController _ballController;
		private World _world;
		private BallsModel _ballsModel;

		[SetUp]
		public void Setup()
		{
			_world = new World {GameSpeed = 1f};
			_ballsModel = new BallsModel(_world, 18, 18, new Vector2(0f, 0f), new Vector2(0f, 0f));
			_ballController = new BallController(_ballsModel);
		}

		[Test]
		public void BallMovesTheCorrectDistanceInRightDirection()
		{
			_ballsModel.Balls[0].Position = new Vector2(0f,0f);
			_ballsModel.Balls[0].Velocity = new Vector2(1f, 1f);

			_ballController.Control(1.0f);

			Assert.That(_ballsModel.Balls[0].Position.X, Is.EqualTo(1f));
			Assert.That(_ballsModel.Balls[0].Position.Y, Is.EqualTo(1f));
		}
		
	}
}