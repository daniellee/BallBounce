using BallBounceMVC.Entities;
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
        private LevelModel _currentLevel;
        private int _lives = 3;
        private readonly Vector2 _startPositionForNewBall = new Vector2(400f, 400f);
        public GameState CurrentState = GameState.LevelTransitionOn;

        public World(int viewportWidth, int viewportHeight)
        {
            _viewportRect = new Rectangle(0, 0,
                viewportWidth,
                viewportHeight);
            _ballsModel = new BallsModel(this, BoxLength, BoxLength, _startPositionForNewBall, _startDirectionForNewBall);
            _frameModel = new FrameModel(this);
            _playerModel = new PlayerModel(this);
            _currentLevel = LoadLevel(1);
            CurrentState = GameState.Normal;
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
            switch (CurrentState)
            {
                case GameState.Normal:
                    _ballsModel.Update(elapsedSeconds);
                    break;
                case GameState.LevelTransitionOn:
                    RestartLevel();
                    break;
                case GameState.LevelTransitionOff:
                    CurrentState = GameState.Normal;
                    break;
                case GameState.GameOver:
                    break;
            }
        }

        public LevelModel LoadLevel(int levelNumber)
        {
            return new LevelModel();
        }

        public void HandleLostLife()
        {
            Lives--;

            if(Lives > 0)
            {
                CurrentState = GameState.LevelTransitionOn;
            }
            else
            {
                CurrentState = GameState.GameOver;
            }
        }

        private void RestartLevel()
        {
            _ballsModel.Add(new Ball(BoxLength, BoxLength, _startPositionForNewBall, _startDirectionForNewBall));
            _playerModel.CenterShip(); 
            CurrentState = GameState.LevelTransitionOff;
        }
    }
}