using BallBounceLogic.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BallBounce.Views
{
    public class PlayerViewer : Viewer
    {
        private readonly PlayerModel _playerModel;
        private readonly Texture2D _playerTexture;

        public PlayerViewer(PlayerModel playerModel, Texture2D playerTexture)
        {
            _playerModel = playerModel;
            _playerTexture = playerTexture;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_playerTexture, _playerModel.GetShip(), Color.White);
        }
    }
}