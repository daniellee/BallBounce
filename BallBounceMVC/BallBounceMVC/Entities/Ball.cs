using Microsoft.Xna.Framework;

namespace BallBounceMVC.Entities
{
	public class Ball : GameObject
	{
		public int Width { get; set; }
		public int Height { get; set; }

		public Ball(int width, int height, Vector2 startPosition, Vector2 startDirection)
		{
			Width = width;
			Height = height;
			Position = startPosition;
			Velocity = startDirection;
		}
	}
}