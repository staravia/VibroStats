using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms.VisualStyles;

namespace vibromark.VibroStats
{
    public class TapTracker
    {
        /// <summary>
        /// </summary>
        public List<TapData> Data { get; private set; } = new List<TapData>();

        /// <summary>
        /// </summary>
        private DateTime _startTime;

        /// <summary>
        /// </summary>
        public TapTracker() => SetStartTime();
        
        /// <summary>
        /// 
        /// </summary>
        public void SetStartTime() => _startTime = DateTime.Now;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public float GetGeneralBpm() => Delta > 0.1f ? Data.Count * 3.75f / Delta : 0;
        
        /// <summary>
        /// </summary>
        public float Delta => (float)(DateTime.Now - _startTime).TotalSeconds;

        /// <summary>
        /// 
        /// </summary>
        public TapResults GetResults()
        {
            return new TapResults();
        }
        
        /// <summary>
        /// This should get called whenever the user taps a lane key.
        /// </summary>
        /// <param name="lane"></param>
        public void Tap(KeyLane lane) => Data.Add(new TapData(Delta, lane));
    }
}