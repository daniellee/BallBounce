namespace BallBounce.Levels
{
    public interface ILevelDeserialize
    {
        LevelData LoadFromFile(int levelNumber);
    }
}