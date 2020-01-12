using System.Collections;
using System.Collections.Generic;

namespace ProjectEuler
{
    public class ChallengeRunner
    {
        private readonly IChallengeAndAnswererProvider _challengeAndAnswererProvider;
        private readonly IChallengeExecutor _executor;
        private readonly IOutputter _outputter;

        public ChallengeRunner(IChallengeAndAnswererProvider challengeAndAnswererProvider, IChallengeExecutor executor, IOutputter outputter)
        {
            _challengeAndAnswererProvider = challengeAndAnswererProvider;
            _executor = executor;
            _outputter = outputter;
        }

        public void Run(IEnumerable<Challenge> challenges)
        {
            foreach (var challengeAndAnswerer in _challengeAndAnswererProvider.GetAnswerers(challenges))
            {
                var result = _executor.Execute(challengeAndAnswerer.Challenge, challengeAndAnswerer.Answerer);
                switch (result.ResultState)
                {
                    case ResultState.Failure:
                        _outputter.Record($"Test: \"{challengeAndAnswerer.Challenge.Name}\", Answerer: \"{challengeAndAnswerer.AnswererName}\" with inputs: {challengeAndAnswerer.Challenge.Inputs} and expected output: {challengeAndAnswerer.Challenge.ExpectedOutput} failed with actual output: {result.ActualOutput}, taking {result.ElapsedTime.TotalMilliseconds} milliseconds.");
                        break;
                    case ResultState.Success:
                        _outputter.Record($"Test: \"{challengeAndAnswerer.Challenge.Name}\", Answerer: \"{challengeAndAnswerer.AnswererName}\" with inputs: {challengeAndAnswerer.Challenge.Inputs} and expected output: {challengeAndAnswerer.Challenge.ExpectedOutput} succeeded, taking {result.ElapsedTime.TotalMilliseconds} milliseconds.");
                        break;
                    default:
                        _outputter.Record($"Test: \"{challengeAndAnswerer.Challenge.Name}\", Answerer: \"{challengeAndAnswerer.AnswererName}\" with inputs: {challengeAndAnswerer.Challenge.Inputs} and expected output: {challengeAndAnswerer.Challenge.ExpectedOutput} and actual output: {result.ActualOutput} produced an unknown Result type: {result}, taking {result.ElapsedTime.TotalMilliseconds} milliseconds.");
                        break;
                }
            }
        }
    }
}
