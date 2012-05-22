using Microsoft.Xna.Framework;

namespace BallBounceMVC.Entities
{
    public class Brick
    {
        public Brick(int x, int y)
        {
            Boundary = new Rectangle(x, y, 40, 30);
        }
        public Rectangle Boundary { get; set; }
    }
}