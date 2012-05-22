using System;
using System.Collections.Generic;
using BallBounceMVC.Models;
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

        public void HandleCollisionWithAnyGameObject(World world)
        {
            var ballRectangle = new Rectangle((int)Position.X, (int)Position.Y, Width, Height);
            var frame = world.GetFrameModel();
            HandleFrameAndBallCollision(ballRectangle, frame);

            var player = world.GetPlayerModel();
            HandlePlayerAndBallCollision(ballRectangle, player);

            HandleBrickAndBallCollisions(ballRectangle, world.CurrentLevel.GetBricks());
        }

        private void HandlePlayerAndBallCollision(Rectangle ballRectangle, PlayerModel player)
        {
            if (player.IntersectsWith(ballRectangle))
            {
                player.SetBallVelocityAfterCollision(this);
            }
        }

        private void HandleFrameAndBallCollision(Rectangle ballRectangle, FrameModel frame)
        {
            if (frame.IntersectsWithTopWall(ballRectangle))
            {
                ChangeVelocityToDown();
            }
            if (frame.IntersectsWithLeftWall(ballRectangle))
            {
                ChangeVelocityToRight();
            }

            if (frame.IntersectsWithRightWall(ballRectangle))
            {
                ChangeVelocityToLeft();
            }
        }

        private void HandleBrickAndBallCollisions(Rectangle ballRectangle, IEnumerable<Brick> allBricks)
        {
            foreach (var brick in allBricks)
            {
                var brickRect = brick.Boundary;
                if (brickRect.Intersects(ballRectangle))
                {
                    var intersection = Rectangle.Intersect(brickRect, ballRectangle);

                    if (intersection.Height > intersection.Width)
                    {
                        ToggleHorizontalVelocity();
                    }
                    else
                    {
                        ToggleVerticalVelocity();
                    }
                }
            }
        }

        private void ToggleVerticalVelocity()
        {
            Velocity.Y = -(Velocity.Y);
        }

        private void ToggleHorizontalVelocity()
        {
            Velocity.X = -(Velocity.X);
        }

        private void ChangeVelocityToLeft()
        {
            if (Math.Sign(Velocity.X) >= 0)
                Velocity.X = -(Velocity.X);
        }

        private void ChangeVelocityToRight()
        {
            if (Math.Sign(Velocity.X) <= 0)
                Velocity.X = -(Velocity.X);
        }

        private void ChangeVelocityToDown()
        {
            if (Math.Sign(Velocity.Y) <= 0)
                Velocity.Y = -(Velocity.Y);
        }
    }
}