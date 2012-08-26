namespace BallBounceLogic.Levels
{
    public interface ILevelDeserialize
    {
        LevelData LoadFromFile(int levelNumber);
    }
}