using System;
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
		public List<Ball> Balls;

		public BallsModel(World world, int width, int height, Vector2 startPosition, Vector2 startDirection) : base(world)
		{
			_width = width;
			_height = height;
			_startPosition = startPosition;
			_startDirection = startDirection;
			Balls = new List<Ball>();
			Balls.Add(new Ball(_width, _height, _startPosition, _startDirection));
		}

		public override void Update(float elapsedSeconds)
		{
			foreach (var ball in Balls)
			{
				ball.Position += ball.Velocity * World.GameSpeed;
			}
			
		}
	}
}