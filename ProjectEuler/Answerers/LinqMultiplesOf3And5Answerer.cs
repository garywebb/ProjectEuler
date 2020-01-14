using System;
using System.Linq;
using System.Threading;

namespace ProjectEuler
{
    public class LinqMultiplesOf3And5Answerer : IChallengeAnswerer
    {
        public bool CanAnswer(Challenge challenge)
        {
            return challenge.Name == ChallengeNames.MultiplesOf3And5;
        }

        public long Answer(long inputs, CancellationToken cancellationToken)
        {
            var intInputs = (int)inputs;

            if (intInputs == 0)
            {
                return 0;
            }

            var inputSign = Math.Sign(intInputs);
            var start = inputSign > 0 ? 1 : intInputs + 1;
            var numbers = Enumerable.Range(start, (intInputs - inputSign) * inputSign);
            var multiplesOf3And5 = numbers
                .AsParallel()
                .WithCancellation(cancellationToken)
                .Where(number => number % 3 == 0 || number % 5 == 0);
            var result = multiplesOf3And5.Sum(number => (long)number);
            return result;
        }
    }
}
