using Microsoft.Xna.Framework;

namespace BallBounceLogic.Entities
{
    public abstract class GameObject
    {
        public Vector2 Position { get; set; }
        public Vector2 Velocity;
    }
}