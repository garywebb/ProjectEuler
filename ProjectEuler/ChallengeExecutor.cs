using System;
using System.Diagnostics;

namespace ProjectEuler
{
    public class ChallengeExecutor : IChallengeExecutor
    {
        public Result Execute(Challenge challenge, IChallengeAnswerer challengeAnswerer)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var actualOutput = challengeAnswerer.Answer(challenge.Inputs);
            stopwatch.Stop();
            var resultState = challenge.ExpectedOutput == actualOutput
                ? ResultState.Success
                : ResultState.Failure;
            var result = new Result
            {
                ActualOutput = actualOutput,
                ResultState = resultState,
                ElapsedTime = stopwatch.Elapsed,
            };
            return result;
        }
    }
}
