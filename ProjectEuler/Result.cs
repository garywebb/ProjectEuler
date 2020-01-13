using System;

namespace ProjectEuler
{
    public class Result
    {
        public ResultState ResultState { get; set; }
        public long ActualOutput { get; set; }
        public TimeSpan ElapsedTime { get; set; }
    }
}
