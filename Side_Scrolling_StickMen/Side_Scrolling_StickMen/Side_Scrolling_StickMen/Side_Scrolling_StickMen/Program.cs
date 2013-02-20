using System;

namespace Side_Scrolling_StickMen
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (MetaGame game = new MetaGame())
            {
                game.Run();
            }
        }
    }
#endif
}

