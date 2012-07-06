using System;
using Microsoft.Xna.Framework;

namespace BallBounceMVC.Models
{
    public class FrameModel : Model
    {
        private readonly Rectangle _topWall, _leftWall, _rightWall;
        private const int WallWidth = 10;

        public FrameModel(World world)
            : base(world)
        {
            Rectangle viewport = world.GetViewport();
            _topWall = new Rectangle(viewport.Left + WallWidth, viewport.Top, viewport.Width - (WallWidth * 2), WallWidth);
            _leftWall = new Rectangle(viewport.Left, viewport.Top, WallWidth, viewport.Height);
            _rightWall = new Rectangle(viewport.Right - WallWidth, viewport.Top, WallWidth, viewport.Height);
        }

        public override void Update(float elapsedSeconds)
        {
            throw new NotImplementedException();
        }

        public bool IntersectsWithTopWall(Rectangle ballRectangle)
        {
            if (ballRectangle.Intersects(_topWall))
                return true;

            return false;
        }

        public Rectangle GetTopWallRectangle()
        {
            return _topWall;
        }

        public Rectangle GetLeftWallRectangle()
        {
            return _leftWall;
        }

        public Rectangle GetRightWallRectangle()
        {
            return _rightWall;
        }

        public int GetInsideFrameLeft()
        {
            return _leftWall.Right;
        }

        public int GetInsideFrameRight()
        {
            return _rightWall.Left;
        }

        public int GetInsideFrameTop()
        {
            return _topWall.Bottom;
        }

        public bool IntersectsWithLeftWall(Rectangle ballRectangle)
        {
            if (ballRectangle.Intersects(_leftWall))
                return true;

            return false;
        }

        public bool IntersectsWithRightWall(Rectangle ballRectangle)
        {
            if (ballRectangle.Intersects(_rightWall))
                return true;

            return false;
        }
    }
}