using System;

namespace BallBounceMVC
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (var game = new BallBounceGame())
            {
                game.Run();
            }
        }
    }
#endif
}

