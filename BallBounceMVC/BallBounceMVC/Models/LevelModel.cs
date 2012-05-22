using System.Collections.Generic;
using BallBounceMVC.Entities;

namespace BallBounceMVC.Models
{
    public class LevelModel
    {
        protected IList<Brick> _bricks;

        public LevelModel()
        {
            _bricks = new List<Brick>();
        }

        public IList<Brick> GetBricks()
        {
            return _bricks;
        }
    }
}