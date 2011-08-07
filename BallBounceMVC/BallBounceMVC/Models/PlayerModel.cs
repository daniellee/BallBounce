using System;
using Microsoft.Xna.Framework;

namespace BallBounceMVC.Models
{
	public class PlayerModel : Model
	{
		private Rectangle _ship;
		private int _width;
		private int _height;

		public PlayerModel(World world) : base(world)
		{
			_width = 120;
			_height = 20;
			var viewport = world.GetViewport();
			_ship = new Rectangle(viewport.Center.X,
					(viewport.Bottom - viewport.Height / 8),
					_width, _height);
		}

		public override void Update(float elapsedSeconds)
		{
			throw new NotImplementedException();
		}

		public Rectangle GetShip()
		{
			return _ship;
		}
	}
}