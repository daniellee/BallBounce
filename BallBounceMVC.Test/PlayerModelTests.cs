using BallBounceMVC.Models;
using NUnit.Framework;

namespace BallBounceMVC.Test
{
	[TestFixture]
	public class PlayerModelTests
	{
		private World _world;
		private PlayerModel _playerModel;

		[SetUp]
		public void Setup()
		{
			_world = new World(800, 600) { GameSpeed = 1f };

			_playerModel = new PlayerModel(_world);
		}

		[Test]
		public void PlayerShouldNotGoFurtherLeftThanTheLeftSideOfTheFrame()
		{
			_playerModel.Update(-10000000);

			var expected = _world.GetFrameModel().GetLeftWallRectangle().Right;

			Assert.That(_playerModel.GetShip().X, Is.EqualTo(expected));
		}

		[Test]
		public void PlayerShouldNotGoFurtherRightThanTheRightSideOfTheFrame()
		{
			_playerModel.Update(10000000);

			var expected = _world.GetFrameModel().GetRightWallRectangle().Left - _playerModel.GetShip().Width;

			Assert.That(_playerModel.GetShip().X, Is.EqualTo(expected));
		}

	}
}