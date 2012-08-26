using BallBounceLogic.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BallBounce.Views
{
    public class WorldViewer : Viewer
    {
        private readonly World _world;
        private readonly SpriteFont _infoFont;

        public WorldViewer(World world, SpriteFont infoFont)
        {
            _world = world;
            _infoFont = infoFont;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            var livesPos = new Vector2(_world.GetViewport().Left + 20, _world.GetViewport().Bottom - 30);
            spriteBatch.DrawString(_infoFont, string.Format("Lives: {0}", _world.Lives), livesPos, Color.Yellow);

            var scorePos = new Vector2(_world.GetViewport().Right - 150, _world.GetViewport().Bottom - 30);
            spriteBatch.DrawString(_infoFont, string.Format("Score: {0}", 0), scorePos, Color.Yellow);
        }

        public void Draw(SpriteBatch spriteBatch, bool isRunningSlowly)
        {
            spriteBatch.DrawString(_infoFont, string.Format("IsRunningSlowly: {0}", isRunningSlowly.ToString()), new Vector2(_world.GetViewport().Left + 40, _world.GetViewport().Bottom - 30), Color.Yellow);
            Draw(spriteBatch);
        }
    }
}