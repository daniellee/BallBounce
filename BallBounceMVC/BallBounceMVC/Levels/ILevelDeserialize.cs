namespace BallBounceMVC.Levels
{
    public interface ILevelDeserialize
    {
        LevelData LoadFromFile(int levelNumber);
    }
}