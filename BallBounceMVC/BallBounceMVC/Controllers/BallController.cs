using BallBounceMVC.Models;

namespace BallBounceMVC.Controllers
{
	public class BallController : ModelController
	{
		private readonly BallsModel _ballsModel;

		public BallController(BallsModel ballsModel)
		{
			_ballsModel = ballsModel;
		}

		public override void Control(float elapsedSeconds)
		{
			_ballsModel.Update(elapsedSeconds);
		}
	}
}