using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace BallBounceMVC.Entities
{
    public class BallAndBrickCollisionHandler
    {
        private readonly Ball _ball;

        public BallAndBrickCollisionHandler(Ball ball)
        {
            _ball = ball;
        }

        public void HandleBrickAndBallCollisions(Rectangle ballRectangle, IEnumerable<Brick> allBricks)
        {
            foreach (var brick in allBricks)
            {
                var brickRect = brick.Boundary;
                if (brickRect.Intersects(ballRectangle))
                {
                    var intersection = Rectangle.Intersect(brickRect, ballRectangle);

                    int halfBallWidth = _ball.Width/2;
                    if(intersection.Height >= halfBallWidth || intersection.Width >= halfBallWidth)
                    {
                        if (intersection.Height > intersection.Width)
                        {
                            _ball.ToggleHorizontalVelocity();
                        }
                        else
                        {
                            _ball.ToggleVerticalVelocity();
                        }
                    }
                    else
                    {
                        HandleCornerHit(brickRect);
                    }

                    CheckIsCorrect(brickRect);
                    return;
                }
            }
        }

        private void CheckIsCorrect(Rectangle brickRect)
        {
            var nextPosition = _ball.Position + (_ball.Velocity);
            var nextRect = new Rectangle((int) nextPosition.X, (int) nextPosition.Y,
                                             _ball.Width, _ball.Height);
            if(brickRect.Intersects(nextRect))
            {
                _ball.ToggleHorizontalVelocity();
                _ball.ToggleVerticalVelocity();
            }
        }

        private void HandleCornerHit(Rectangle brickRect)
        {
            var previousPosition = _ball.Position - (_ball.Velocity);
            var previousRect = new Rectangle((int) previousPosition.X, (int) previousPosition.Y,
                                             _ball.Width, _ball.Height);
            if (previousRect.Top < brickRect.Bottom && previousRect.Bottom > brickRect.Top)
                _ball.ToggleHorizontalVelocity();
            else
                _ball.ToggleVerticalVelocity();
        }
    }
}