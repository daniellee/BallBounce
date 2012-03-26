using System.Collections.Generic;
using BallBounceMVC.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BallBounceMVC.Views
{
    public class BallsViewer : Viewer
    {
        private readonly IList<Ball> _balls;
        private readonly Texture2D _texture;

        public BallsViewer(IList<Ball> balls, Texture2D texture)
        {
            _balls = balls;
            _texture = texture;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            foreach (var ball in _balls)
            {
                var ballRect = new Rectangle((int)ball.Position.X, (int)ball.Position.Y, ball.Width, ball.Height);
                spriteBatch.Draw(_texture, ballRect, Color.White);
            }
        }
    }
}