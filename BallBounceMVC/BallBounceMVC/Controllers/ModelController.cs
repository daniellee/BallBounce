namespace BallBounceMVC.Controllers
{
    public abstract class ModelController
    {
        public abstract void Control(float elapsedSeconds);
    }
}