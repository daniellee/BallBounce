using Microsoft.Xna.Framework;

namespace BallBounceLogic.Entities
{
    public class Brick
    {
        private const int BrickWidth = 60;
        private const int BrickHeight = 30;
        public int ColumnNumber { get; set; }
        public int RowNumber { get; set; }
        
        public Brick(int x, int y, float scale)
        {
            Boundary = new Rectangle((int)(x * scale), (int)(y * scale), (int)(BrickWidth * scale), (int)(BrickHeight * scale));
        }
        public Rectangle Boundary { get; set; }
    }
}