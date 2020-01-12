using System;

namespace ProjectEuler
{
    public class Result
    {
        public ResultState ResultState { get; set; }
        public int ActualOutput { get; set; }
        public TimeSpan ElapsedTime { get; set; }
    }
}
