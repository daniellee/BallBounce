using System;
using BallBounceLogic.Models;
using Microsoft.Xna.Framework;

namespace BallBounceLogic.Entities
{
    public class Ball : GameObject
    {
        private readonly BallAndBrickCollisionHandler _brickCollisionHandler;
        public int Width { get; set; }
        public int Height { get; set; }

        public Ball(int width, int height, Vector2 startPosition, Vector2 startDirection)
        {
            Width = width;
            Height = height;
            Position = startPosition;
            Velocity = startDirection;
            _brickCollisionHandler = new BallAndBrickCollisionHandler(this);
        }

        public void HandleCollisionWithAnyGameObject(World world)
        {
            var ballRectangle = new Rectangle((int)Position.X, (int)Position.Y, Width, Height);
            var frame = world.GetFrameModel();
            HandleFrameAndBallCollision(ballRectangle, frame);

            var player = world.GetPlayerModel();
            HandlePlayerAndBallCollision(ballRectangle, player);

            _brickCollisionHandler.HandleBrickAndBallCollisions(ballRectangle, world.CurrentLevel.GetBricks());
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

        public void ToggleVerticalVelocity()
        {
            Velocity.Y = -(Velocity.Y);
        }

        public void ToggleHorizontalVelocity()
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