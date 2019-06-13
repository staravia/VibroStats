using System;

namespace vibromark.VibroStats
{
    public struct TapResults
    {
        public DateTime Date;
        
        public float AverageBpm;

        public int Score;

        public float Accuracy;

        public float AverageUnstableRate;

        public float HandPreference;
        
        public float GeneralUnstabilityL;

        public float GeneralUnstabilityR;
        
        public float StaminaBpmL;

        public float StaminaBpmR;

        public float DrainBpmL;

        public float DraimBpmR;

        public float MedianBpmL;

        public float MedianBpmR;

        public float PeakBpmL;

        public float PeakBpmR;

        public float BpmUnstabilityL;

        public float BpmUnstabilityR;
    }
}