using Moq;
using ProjectEuler;
using System;
using System.Collections.Generic;
using Xunit;
using static ProjectEulerTests.Helpers.DataBuilders.DataBuilderFactory;

namespace ProjectEulerTests
{
    public class ChallengeRunnerTests
    {
        [Fact]
        public void When_a_challenge_is_failed_Then_the_failure_is_recorded()
        {
            var mockChallengeAndAnswererProvider = new Mock<IChallengeAndAnswererProvider>();
            var mockChallengeExecutor = new Mock<IChallengeExecutor>();
            var mockChallengeAnswerer = new Mock<IChallengeAnswerer>();
            var mockOutputter = new Mock<IOutputter>();

            var aChallenge = AChallenge().Build();
            var challengeAndAnswerer = new ChallengeAndAnswerer
            {
                Challenge = aChallenge,
                Answerer = mockChallengeAnswerer.Object,
                AnswererName = "An Answerer",
            };
            var challenges = new List<Challenge> { aChallenge };
            var failureResult = AFailureResult().Build();

            mockChallengeAndAnswererProvider
                .Setup(x => x.GetAnswerers(challenges))
                .Returns(new List<ChallengeAndAnswerer> { challengeAndAnswerer });
            mockChallengeExecutor
                .Setup(x => x.Execute(challengeAndAnswerer.Challenge, challengeAndAnswerer.Answerer))
                .Returns(failureResult);

            var challengeRunner = GetChallengeRunner(
                mockChallengeAndAnswererProvider.Object,
                mockChallengeExecutor.Object,
                mockOutputter.Object);
            challengeRunner.Run(challenges);

            mockOutputter.Verify(x => x.Record($"Test: \"{challengeAndAnswerer.Challenge.Name}\", Answerer: \"{challengeAndAnswerer.AnswererName}\" with inputs: {challengeAndAnswerer.Challenge.Inputs} and expected output: {challengeAndAnswerer.Challenge.ExpectedOutput} failed with actual output: {failureResult.ActualOutput}, taking {failureResult.ElapsedTime.TotalMilliseconds} milliseconds."));
        }

        [Fact]
        public void When_a_challenge_is_successful_Then_the_success_is_recorded()
        {
            var mockChallengeAndAnswererProvider = new Mock<IChallengeAndAnswererProvider>();
            var mockChallengeExecutor = new Mock<IChallengeExecutor>();
            var mockChallengeAnswerer = new Mock<IChallengeAnswerer>();
            var mockOutputter = new Mock<IOutputter>();

            var aChallenge = AChallenge().Build();
            var challengeAndAnswerer = new ChallengeAndAnswerer
            {
                Challenge = aChallenge,
                Answerer = mockChallengeAnswerer.Object,
                AnswererName = "An Answerer",
            };
            var challenges = new List<Challenge> { aChallenge };

            var successResult = ASuccessResult().Build();
            mockChallengeAndAnswererProvider
                .Setup(x => x.GetAnswerers(challenges))
                .Returns(new List<ChallengeAndAnswerer> { challengeAndAnswerer });
            mockChallengeExecutor
                .Setup(x => x.Execute(challengeAndAnswerer.Challenge, challengeAndAnswerer.Answerer))
                .Returns(successResult);

            var challengeRunner = GetChallengeRunner(
                mockChallengeAndAnswererProvider.Object,
                mockChallengeExecutor.Object,
                mockOutputter.Object);
            challengeRunner.Run(challenges);

            mockOutputter.Verify(x => x.Record($"Test: \"{challengeAndAnswerer.Challenge.Name}\", Answerer: \"{challengeAndAnswerer.AnswererName}\" with inputs: {challengeAndAnswerer.Challenge.Inputs} and expected output: {challengeAndAnswerer.Challenge.ExpectedOutput} succeeded, taking {successResult.ElapsedTime.TotalMilliseconds} milliseconds."));
        }

        private ChallengeRunner GetChallengeRunner(
            IChallengeAndAnswererProvider challengeAndAnswererProvider = null,
            IChallengeExecutor challengeExecutor = null,
            IOutputter outputter = null)
        {
            challengeAndAnswererProvider = challengeAndAnswererProvider ?? new Mock<IChallengeAndAnswererProvider>().Object;
            challengeExecutor = challengeExecutor ?? new Mock<IChallengeExecutor>().Object;
            outputter = outputter ?? new Mock<IOutputter>().Object;

            var challengeRunner = new ChallengeRunner(challengeAndAnswererProvider, challengeExecutor, outputter);
            return challengeRunner;
        }
    }
}
