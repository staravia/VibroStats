namespace vibromark.VibroStats
{
    public struct TapData
    {
        /// <summary>
        /// Time of when a key was tapped.
        /// </summary>
        public double TimeMs { get; }
        
        /// <summary>
        /// Which Key got tapped.
        /// </summary>
        public KeyLane Key { get; }

        /// <summary>
        /// </summary>
        /// <param name="time"></param>
        /// <param name="key"></param>
        public TapData(double timeMs, KeyLane key)
        {
            TimeMs = timeMs;
            Key = key;
        }
    }
}