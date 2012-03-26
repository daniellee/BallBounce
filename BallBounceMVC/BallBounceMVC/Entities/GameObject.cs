using Microsoft.Xna.Framework;

namespace BallBounceMVC.Entities
{
    public abstract class GameObject
    {
        public Vector2 Position { get; set; }
        public Vector2 Velocity;
    }
}