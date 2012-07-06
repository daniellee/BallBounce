namespace BallBounceMVC.Models
{
    public abstract class Model
    {
        protected Model(World world)
        {
            World = world;
        }

        public abstract void Update(float elapsedSeconds);

        protected World World;
    }
}