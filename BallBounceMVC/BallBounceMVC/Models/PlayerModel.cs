using System;
using BallBounceMVC.Entities;
using Microsoft.Xna.Framework;

namespace BallBounceMVC.Models
{
    public class PlayerModel : Model
    {
        private Rectangle _ship;
        private readonly int _width;
        private readonly int _height;
        private readonly World _world;
        private ShipZones _zones;

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

        public void CenterShip()
        {
            _ship.X = _world.GetViewport().Center.X;
        }

        public bool IntersectsWith(Rectangle ballRectangle)
        {
            return _ship.Intersects(ballRectangle);
        }

        public void SetBallVelocityAfterCollision(Ball ball)
        {
            ChangeVelocityToUp(ball);
            _zones = new ShipZones(_ship);

            if(_zones.HitFarthestLeftZone(ball))
            {
                ball.Velocity.X = -3.5f;
            }
            else if(_zones.HitFarthestRightZone(ball))
            {
                ball.Velocity.X = 3.5f;
            }
            else if (_zones.HitFarLeftZone(ball))
            {
                ball.Velocity.X = -2.0f;
            }
            else if (_zones.HitFarRightZone(ball))
            {
                ball.Velocity.X = 2.0f;
            }
            else if (_zones.HitMiddleLeftZone(ball))
            {
                ball.Velocity.X = -1.0f;
            }
            else if (_zones.HitMiddleRightZone(ball))
            {
                ball.Velocity.X = 1.0f;
            }
            else if(_zones.HitCentreRightZone(ball))
            {
                ball.Velocity.X = 0.5f;
            }

        }

        private static void ChangeVelocityToUp(Ball ball)
        {
            if (Math.Sign(ball.Velocity.Y) >= 0)
                ball.Velocity.Y = -(ball.Velocity.Y);
        }
    }
}