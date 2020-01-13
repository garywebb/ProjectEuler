using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectEuler
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var challengeRunner = new ChallengeRunner(new ChallengeAnswererProvider(), new ChallengeExecutor(), new Outputter());
                
            await challengeRunner.RunAsync(
                new List<Challenge>
                {
                    new Challenge { Name = ChallengeNames.MultiplesOf3And5, Inputs = 1, ExpectedOutput = 0 },
                    new Challenge { Name = ChallengeNames.MultiplesOf3And5, Inputs = 10, ExpectedOutput = 23 },
                    new Challenge { Name = ChallengeNames.MultiplesOf3And5, Inputs = 15, ExpectedOutput = 45 },
                    new Challenge { Name = ChallengeNames.MultiplesOf3And5, Inputs = 16, ExpectedOutput = 60 },
                    new Challenge { Name = ChallengeNames.MultiplesOf3And5, Inputs = 100, ExpectedOutput = 2318 },
                    new Challenge { Name = ChallengeNames.MultiplesOf3And5, Inputs = Int32.MaxValue, ExpectedOutput = 1076060070465310994 },
                    new Challenge { Name = ChallengeNames.MultiplesOf3And5, Inputs = 1000000000, ExpectedOutput = 233333333166666668 },
                });
        }
    }
}
