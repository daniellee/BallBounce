using Microsoft.Xna.Framework;

namespace BallBounceMVC.Entities
{
    public class Brick
    {
        public Brick()
        {
            Boundary = new Rectangle(400, 300, 40, 30);
        }
        public Rectangle Boundary { get; set; }
    }
}