using System;
using BallBounceMVC.Models;
using Microsoft.Xna.Framework.Input;

#if WINDOWS_PHONE
using Microsoft.Xna.Framework.Input.Touch;
#endif

namespace BallBounceMVC.Controllers
{
    public class PlayerController : ModelController
    {
        private readonly PlayerModel _playerModel;
        private MouseState _previousMouseState;

        public PlayerController(PlayerModel playerModel)
        {
            _playerModel = playerModel;
#if WINDOWS_PHONE
            TouchPanel.EnabledGestures = GestureType.HorizontalDrag;
#else
            _previousMouseState = Mouse.GetState();
#endif
        }

        public override void Control(float elapsedSeconds)
        {
        #if WINDOWS_PHONE 
            if(TouchPanel.IsGestureAvailable) { 
            var gesture = TouchPanel.ReadGesture(); 
            var delta = gesture.Delta.X;
            _playerModel.Update(delta); 
            } 
        #else 
            MouseState currentMouseState = Mouse.GetState();
            if (currentMouseState != _previousMouseState)
            {
                float xDifference = currentMouseState.X - _previousMouseState.X;
                _playerModel.Update(xDifference);
            }
            _previousMouseState = currentMouseState;
        #endif
        }
    }
}