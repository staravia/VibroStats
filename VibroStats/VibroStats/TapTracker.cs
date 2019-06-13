using System;
using System.Collections.Generic;
using System.Windows.Forms.VisualStyles;

namespace vibromark.VibroStats
{
    public class TapTracker
    {
        /// <summary>
        /// </summary>
        public List<TapData> Data { get; private set; }

        /// <summary>
        /// </summary>
        private DateTime _startTime;

        /// <summary>
        /// </summary>
        public TapTracker() => Initialize();

        /// <summary>
        /// Initialize the TapTracker class
        /// </summary>
        private void Initialize()
        {
            _startTime = DateTime.Now;
        }

        public void GetResults()
        {
            
        }
        
        /// <summary>
        /// This should get called whenever the user taps a lane key.
        /// </summary>
        /// <param name="lane"></param>
        public void Tap(KeyLane lane)
        {
            var delta = (DateTime.Now - _startTime).Milliseconds;
            Data.Add(new TapData(delta, lane));
        }
    }
}