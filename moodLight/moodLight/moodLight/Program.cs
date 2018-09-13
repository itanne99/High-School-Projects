using System;

namespace moodLight
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (moodLight game = new moodLight())
            {
                game.Run();
            }
        }
    }
#endif
}

