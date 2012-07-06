using BallBounceMVC.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BallBounceMVC.Views
{
    public class LevelViewer : Viewer
    {
        private readonly World _world;
        private readonly Texture2D _yellowSquareTexture;

        public LevelViewer(World world, Texture2D yellowSquareTexture)
        {
            _world = world;
            _yellowSquareTexture = yellowSquareTexture;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            var bricks = _world.CurrentLevel.GetBricks();
            foreach (var brick in bricks)
            {
                spriteBatch.Draw(_yellowSquareTexture, brick.Boundary, Color.White);
            }
            
        }
    }
}