using System.Collections.Generic;

namespace ProjectEuler
{
    class Program
    {
        static void Main(string[] args)
        {
            var challengeRunner = new ChallengeRunner(new ChallengeAnswererProvider(), new ChallengeExecutor(), new Outputter());
                
            challengeRunner.Run(
                new List<Challenge>
                {
                    new Challenge { Name = ChallengeNames.MultiplesOf3And5, Inputs = 10, ExpectedOutput = 23 },
                    new Challenge { Name = ChallengeNames.MultiplesOf3And5, Inputs = 15, ExpectedOutput = 45 },
                    new Challenge { Name = ChallengeNames.MultiplesOf3And5, Inputs = 16, ExpectedOutput = 60 },
                    new Challenge { Name = ChallengeNames.MultiplesOf3And5, Inputs = 100, ExpectedOutput = 2318 },
                });
        }
    }
}
