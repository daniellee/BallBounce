using System.IO;
using Microsoft.Xna.Framework;
using ServiceStack.Text;

namespace BallBounceMVC.Levels
{
    public class LevelSerializer : ILevelDeserialize
    {
        public LevelData LoadFromFile(int levelNumber)
        {
            var levelData = new LevelData(levelNumber);
            try
            {
                Stream stream = TitleContainer.OpenStream("Content/Levels/" + levelNumber + ".json");
                var sreader = new StreamReader(stream);

                levelData = DeserializeFromReader(sreader);

                stream.Close();
            }
            catch (FileNotFoundException)
            {
                // this will be thrown by OpenStream if gamedata.txt
                // doesn't exist in the title storage location
            }

            return levelData;
        }

        public LevelData DeserializeFromReader(StreamReader sreader)
        {
            return JsonSerializer.DeserializeFromReader<LevelData>(sreader);
        }

        public void SaveToFile(LevelData levelData)
        {
            TextWriter tw = new StreamWriter(levelData.LevelNumber + ".json");
            JsonSerializer.SerializeToWriter(levelData, tw);
            tw.Close();
        }
    }
}