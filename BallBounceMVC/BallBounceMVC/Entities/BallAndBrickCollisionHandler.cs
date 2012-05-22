using System;
using System.Collections.Generic;
using BallBounceMVC.Models;
using Microsoft.Xna.Framework;

namespace BallBounceMVC.Entities
{
    public class BallAndBrickCollisionHandler
    {
        private readonly Ball ball;

        public BallAndBrickCollisionHandler(Ball ball)
        {
            this.ball = ball;
        }

        public void HandleBrickAndBallCollisions(Rectangle ballRectangle, IEnumerable<Brick> allBricks)
        {
            foreach (var brick in allBricks)
            {
                var brickRect = brick.Boundary;
                if (brickRect.Intersects(ballRectangle))
                {
                    var intersection = Rectangle.Intersect(brickRect, ballRectangle);

                    int halfBallWidth = ball.Width/2;
                    if(intersection.Height >= halfBallWidth || intersection.Width >= halfBallWidth)
                    {
                        if (intersection.Height > intersection.Width)
                        {
                            ball.ToggleHorizontalVelocity();
                        }
                        else
                        {
                            ball.ToggleVerticalVelocity();
                        }
                    }
                    else
                    {
                        var previousPosition = ball.Position - (ball.Velocity);
                        var previousRect = new Rectangle((int)previousPosition.X, (int)previousPosition.Y, ball.Width, ball.Height);
                        if(previousRect.Top < brickRect.Bottom && previousRect.Bottom > brickRect.Top )
                            ball.ToggleHorizontalVelocity();
                        else
                            ball.ToggleVerticalVelocity();
                    }
                }
            }
        }
    }
}