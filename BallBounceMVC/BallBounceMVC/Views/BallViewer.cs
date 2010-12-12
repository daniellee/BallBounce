using BallBounceMVC.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BallBounceMVC.Views
{
	public class BallViewer: Viewer
	{
		private readonly Ball _ball;
		private readonly Texture2D _texture;

		public BallViewer(Ball ball, Texture2D texture)
		{
			_ball = ball;
			_texture = texture;
		}

		public override void Draw(SpriteBatch spriteBatch)
		{
			var ballRect = new Rectangle((int)_ball.Position.X, (int)_ball.Position.Y, _ball.Width, _ball.Height);
			spriteBatch.Draw(_texture, ballRect, Color.White);
		}
	}
}