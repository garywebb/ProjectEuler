using System;
using System.Linq;
using System.Threading;

namespace ProjectEuler
{
    public class QuickMultiplesOf3And5Answerer : IChallengeAnswerer
    {
        public bool CanAnswer(Challenge challenge)
        {
            return challenge.Name == ChallengeNames.MultiplesOf3And5;
        }

        /// <summary>
        /// Calculate the sum of all 3s and 5s up to the input number
        /// </summary>
        /// <returns>A long - rather than an int as a result of the calculation may end up bigger than an int</returns>
        public long Answer(long inputs, CancellationToken cancellationToken)
        {
            //-6, -5, -4, -3, -2, -1, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9,  10, 11, 12, 13, 14, 15
            //-9, -3, -3, -3,  0,  0, 0, 0, 0, 3, 3, 3, 9, 9, 9, 18, 18, 18, 30, 30, 30, 45
            //-3, -1, -1, -1,  0,  0, 0, 0, 0, 1, 1, 1, 3, 3, 3, 6,  6,  6,  10, 10, 10, 15
            //-5, -5,  0,  0,  0,  0, 0, 0, 0, 0, 0, 5, 5, 5, 5, 5,  15, 15, 15, 15, 15, 30
            //-1, -1,  0,  0,  0,  0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1,  3,  3,  3,  3,  3,  6
            //Triangle numbers * 3 or 5
            var intInputs = (int)inputs;

            var multipleOf3Result = CalculateMultipleOf(intInputs, 3);
            var multipleOf5Result = CalculateMultipleOf(intInputs, 5);
            var multipleOf3And5Result = CalculateMultipleOf(intInputs, 15);
            var result = multipleOf3Result + multipleOf5Result - multipleOf3And5Result;
            return result;
        }

        /// <summary>
        /// Find the max triangle number and multiply by the divisor.
        /// </summary>
        /// <returns>A long - rather than an int as a result of the calculation may end up bigger than an int</returns>
        private static long CalculateMultipleOf(int inputs, int divisor)
        {
            long n = (inputs - 1) / divisor;
            //This calculation may end up bigger than an int when a very large int is inputted
            var nTriangleNumber = n * (n + 1) / 2;
            var multipleOfDivisorResult = nTriangleNumber * divisor;
            return multipleOfDivisorResult;
        }
    }
}
