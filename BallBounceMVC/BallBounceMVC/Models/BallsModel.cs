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
		private World _world;

		public BallsModel(World world, int width, int height, Vector2 startPosition, Vector2 startDirection): base(world)
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
			foreach (var ball in GetAllBalls())
			{
				ball.Position += ball.Velocity * (World.GameSpeed * elapsedSeconds);
				ball.HandleCollisionWithAnyGameObject(_world);
			}		
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