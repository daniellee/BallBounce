using Microsoft.Xna.Framework;

namespace BallBounceMVC.Models
{
	public class World
	{
		public float GameSpeed = 2.0f;
		private const int BoxLength = 18;
		private readonly BallsModel _ballsModel;
		private readonly Vector2 _startDirectionForNewBall = new Vector2(0.5f, -4.0f);
		private readonly Rectangle _viewportRect;
		private readonly FrameModel _frameModel;
		private readonly PlayerModel _playerModel;
		private int _lives = 3;

		public World(int viewportWidth, int viewportHeight)
		{
			_viewportRect = new Rectangle(0, 0,
				viewportWidth,
				viewportHeight);
			_ballsModel = new BallsModel(this, BoxLength, BoxLength, new Vector2(400f, 400f), _startDirectionForNewBall);
			_frameModel = new FrameModel(this);
			_playerModel = new PlayerModel(this);
		}

		public int Lives
		{
			get { return _lives; }
			set { _lives = value; }
		}

		public BallsModel GetBallsModel()
		{
			return _ballsModel;
		}

		public FrameModel GetFrameModel()
		{
			return _frameModel;
		}

		public Rectangle GetViewport()
		{
			return _viewportRect;
		}

		public PlayerModel GetPlayerModel()
		{
			return _playerModel;
		}

		public void Update(float elapsedSeconds)
		{
			_ballsModel.Update(elapsedSeconds);
		}
	}
}