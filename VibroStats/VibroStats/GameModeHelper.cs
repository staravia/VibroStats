using System.Collections.Generic;

namespace vibromark.VibroStats
{
    public class GameModeHelper
    {
        /// <summary>
        /// 
        /// </summary>
        private static Dictionary<GameMode, int> _gameModeToLength = new Dictionary<GameMode, int>()
        {
            {GameMode.Length10, 10},
            {GameMode.Length25, 25}
        };

        /// <summary>
        /// Get the length of a gamemode 
        /// </summary>
        /// <param name="mode"></param>
        public static int GetGameModeLength(GameMode mode) => _gameModeToLength[mode];
    }
}