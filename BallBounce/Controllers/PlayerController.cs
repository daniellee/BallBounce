using BallBounce.Models;
using Microsoft.Xna.Framework.Input;

namespace BallBounce.Controllers
{
    public class PlayerController : ModelController
    {
        private readonly PlayerModel _playerModel;
        private MouseState _previousMouseState;

        public PlayerController(PlayerModel playerModel)
        {
            _playerModel = playerModel;
            _previousMouseState = Mouse.GetState();
        }

        public override void Control(float elapsedSeconds)
        {
            MouseState currentMouseState = Mouse.GetState();
            if (currentMouseState != _previousMouseState)
            {
                float xDifference = currentMouseState.X - _previousMouseState.X;
                _playerModel.Update(xDifference);
            }

            _previousMouseState = currentMouseState;
        }
    }
}