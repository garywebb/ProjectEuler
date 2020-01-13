using System;
using System.Linq;
using System.Threading;

namespace ProjectEuler
{
    public class LinqMultiplesOf3And5Answerer : IChallengeAnswerer<int, long>
    {
        public bool CanAnswer(Challenge challenge)
        {
            return challenge.Name == ChallengeNames.MultiplesOf3And5;
        }

        public long Answer(int inputs, CancellationToken cancellationToken)
        {
            if (inputs == 0)
            {
                return 0;
            }

            var inputSign = Math.Sign(inputs);
            var start = inputSign > 0 ? 1 : inputs + 1;
            var numbers = Enumerable.Range(start, (inputs - inputSign) * inputSign);
            var multiplesOf3And5 = numbers
                .AsParallel()
                .WithCancellation(cancellationToken)
                .Where(number => number % 3 == 0 || number % 5 == 0);
            var result = multiplesOf3And5.Sum(number => (long)number);
            return result;
        }
    }
}
