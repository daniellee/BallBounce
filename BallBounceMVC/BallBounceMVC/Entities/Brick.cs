using Microsoft.Xna.Framework;

namespace BallBounceMVC.Entities
{
    public class Brick
    {
        private const int BrickWidth = 60;
        private const int BrickHeight = 30;
        public int ColumnNumber { get; set; }
        public int RowNumber { get; set; }
        
        public Brick(int x, int y)
        {
            Boundary = new Rectangle(x, y, BrickWidth, BrickHeight);
        }
        public Rectangle Boundary { get; set; }
    }
}