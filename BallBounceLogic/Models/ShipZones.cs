using BallBounceLogic.Entities;
using Microsoft.Xna.Framework;

namespace BallBounceLogic.Models
{
    public class ShipZones
    {
        private readonly Rectangle _ship;
        private readonly int _shipSection;

        public ShipZones(Rectangle ship)
        {
            _ship = ship;
            _shipSection = _ship.Width / 7;
        }

        public bool HitFarthestLeftZone(Ball ball)
        {
            return ball.Position.X < (_ship.Left + _shipSection);
        }

        public bool HitFarthestRightZone(Ball ball)
        {
            return ball.Position.X > (_ship.Right - _shipSection);
        }

        public bool HitFarLeftZone(Ball ball)
        {
            return ball.Position.X < (_ship.Left + _shipSection * 2);
        }

        public bool HitFarRightZone(Ball ball)
        {
            return ball.Position.X > (_ship.Right - _shipSection * 2);
        }

        public bool HitMiddleLeftZone(Ball ball)
        {
            return ball.Position.X < (_ship.Left + _shipSection * 3);
        }

        public bool HitMiddleRightZone(Ball ball)
        {
            return ball.Position.X > (_ship.Right - _shipSection * 3);
        }

        public bool HitCentreRightZone(Ball ball)
        {
            return ball.Position.X > (_ship.Center.X);
        }

    }
}