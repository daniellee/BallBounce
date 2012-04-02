using System.Collections.Generic;
using BallBounceMVC.Entities;
using Microsoft.Xna.Framework;

namespace BallBounceMVC.Models
{
    public class BallsModel : Model
    {
        private readonly int _width;
        private readonly int _height;
        private readonly Vector2 _startPosition;
        private readonly Vector2 _startDirection;
        private readonly IList<Ball> _balls;
        private readonly World _world;

        public BallsModel(World world, int width, int height, Vector2 startPosition, Vector2 startDirection)
            : base(world)
        {
            _world = world;
            _width = width;
            _height = height;
            _startPosition = startPosition;
            _startDirection = startDirection;
            _balls = new List<Ball>();
            Add(new Ball(_width, _height, _startPosition, _startDirection));
        }

        public override void Update(float elapsedSeconds)
        {
            for (int i = _balls.Count - 1; i >= 0; i--)
            {
                var ball = _balls[i];
                ball.Position += ball.Velocity * (World.GameSpeed);
                if (IsBallDead(ball))
                {
                    HandleBallDeath(ball);
                }
                else
                {
                    ball.HandleCollisionWithAnyGameObject(_world);
                }
            }
        }

        private void HandleBallDeath(Ball ball)
        {
            Remove(ball);
            if (_balls.Count == 0)
                _world.HandleLostLife();
        }

        private void Remove(Ball ball)
        {
            _balls.Remove(ball);
        }

        private bool IsBallDead(Ball ball)
        {
            Rectangle viewport = _world.GetViewport();

            return !viewport.Contains(new Point(
                            (int)ball.Position.X,
                            (int)ball.Position.Y));
        }

        public IList<Ball> GetAllBalls()
        {
            return _balls;
        }

        public Ball GetBall(int index)
        {
            return _balls[index];
        }

        public Ball GetFirstBall()
        {
            if (_balls.Count == 0)
                return null;

            return _balls[0];
        }

        public void Add(Ball ball)
        {
            _balls.Add(ball);
        }
    }
}