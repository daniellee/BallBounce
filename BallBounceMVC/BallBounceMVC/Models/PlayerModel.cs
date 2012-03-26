using System;
using Microsoft.Xna.Framework;

namespace BallBounceMVC.Models
{
    public class PlayerModel : Model
    {
        private Rectangle _ship;
        private int _width;
        private int _height;
        private World _world;

        public PlayerModel(World world)
            : base(world)
        {
            _world = world;
            _width = 120;
            _height = 20;
            var viewport = world.GetViewport();
            _ship = new Rectangle(viewport.Center.X,
                    (viewport.Bottom - viewport.Height / 8),
                    _width, _height);
        }

        public override void Update(float relativeDifference)
        {
            _ship.X += (int)relativeDifference;
            _ship.X = (int)MathHelper.Clamp(
                                    _ship.X,
                                    _world.GetFrameModel().GetLeftWallRectangle().Right,
                                    _world.GetFrameModel().GetRightWallRectangle().Left - _ship.Width);
        }

        public Rectangle GetShip()
        {
            return _ship;
        }

        public bool IntersectsWith(Rectangle ballRectangle)
        {
            return _ship.Intersects(ballRectangle);
        }
    }
}