using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ProjectEuler.Answerers
{
    public class EvenFibonacciAnswerer : IChallengeAnswerer
    {
        public bool CanAnswer(Challenge challenge)
        {
            return challenge.Name == ChallengeNames.EvenFibonacci;
        }

        public long Answer(long inputs, CancellationToken cancellationToken)
        {
            if (inputs <= 2)
            {
                return 0L;
            }
            //1, 2, 3, 5,  8, 13, 21, 34, 55, 89, 144, 233, 377, 610, 987, 1597, 2584, 4181, 6765, 10946
            //1, 2, 3, 4,  5,  6,  7,  8,  9, 10,  11,  12,  13,  14,  15,   16,   17,   18,   19,    20,
            //0, 2, 2, 2, 10, 10, 10, 44, 44, 44, 188, 188, 188, 798, 798,  798, 3382, 3382, 3382, 14328
            //   2,       10,         44,         188,           798,            3382,             
            //   2,       4 * 2+0+2 , 4 * 10+2+2, 4 * 44+10+2,   4 * 188+44+2  , 4 * 798+188+2   , 4 * 3382+798+2   
            //   4 * f(1) + f(0) + 2

            long f1 = 2;
            long f0 = 0;
            long totalSum = 0;
            while (f1 < inputs)
            {
                if (cancellationToken.IsCancellationRequested)
                {
                    break;
                }

                totalSum += f1;

                long f = 4 * f1 + f0;
                f0 = f1;
                f1 = f;
            };

            return totalSum;
        }
    }
}
