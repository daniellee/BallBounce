using System;
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

            var player = world.GetPlayerModel();
            if (player.IntersectsWith(ballRectangle))
            {
                if (Math.Sign(Velocity.Y) >= 0)
                    Velocity.Y = -(Velocity.Y);
            }
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