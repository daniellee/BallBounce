using BallBounceLogic.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BallBounce.Views
{
    public class FrameViewer : Viewer
    {
        private readonly FrameModel _frameModel;
        private readonly Texture2D _frameTexture;

        public FrameViewer(FrameModel frameModel, Texture2D frameTexture)
        {
            _frameModel = frameModel;
            _frameTexture = frameTexture;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_frameTexture, _frameModel.GetTopWallRectangle(), Color.White);
            spriteBatch.Draw(_frameTexture, _frameModel.GetLeftWallRectangle(), Color.White);
            spriteBatch.Draw(_frameTexture, _frameModel.GetRightWallRectangle(), Color.White);
        }
    }
}