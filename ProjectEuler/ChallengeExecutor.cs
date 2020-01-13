using ProjectEuler.Lib;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectEuler
{
    public class ChallengeExecutor : IChallengeExecutor
    {
        private readonly TimeSpan _timeout;

        public ChallengeExecutor(TimeSpan? timeout = null)
        {
            if (timeout == null)
            {
                timeout = new TimeSpan(0, 0, 10);
            }
            _timeout = timeout.Value;
        }

        public async Task<Result> ExecuteAsync(Challenge challenge, IChallengeAnswerer challengeAnswerer)
        {
            object actualOutput = default;
            ResultState resultState = ResultState.None;

            var stopwatch = new Stopwatch();
            stopwatch.Start();
            try
            {
                using (var cancellationTokenSource = new CancellationTokenSource())
                {
                    var answerTask = Task.Run(() => challengeAnswerer.Answer(challenge.Inputs, cancellationTokenSource.Token));
                    actualOutput = await answerTask.TimeoutAfterAsync(_timeout, cancellationTokenSource);
                    resultState = Object.Equals(challenge.ExpectedOutput, actualOutput)
                        ? ResultState.Success
                        : ResultState.Failure;
                }
            }
            catch
            {
                resultState = ResultState.TimedOut;
            }
            finally
            {
                stopwatch.Stop();
            }

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
