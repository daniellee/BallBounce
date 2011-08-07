using System;
using BallBounceMVC.Models;

namespace BallBounceMVC.Controllers
{
	public class PlayerController : ModelController
	{
		private readonly PlayerModel _playerModel;

		public PlayerController(PlayerModel playerModel)
		{
			_playerModel = playerModel;
		}

		public override void Control(float elapsedSeconds)
		{
			throw new NotImplementedException();
		}
	}
}