using System.Collections.Generic;
using BallBounceMVC.Entities;

namespace BallBounceMVC.Models
{
    public class LevelModel
    {
        IList<Brick> _bricks;

        public LevelModel()
        {
            _bricks = new List<Brick>();
            _bricks.Add(new Brick());
        }

        public IList<Brick> GetBricks()
        {
            return _bricks;
        }
    }
}