using System.Linq;

namespace ProjectEuler
{
    public class QuickMultiplesOf3And5Answerer : IChallengeAnswerer
    {
        public bool CanAnswer(Challenge challenge)
        {
            return challenge.Name == ChallengeNames.MultiplesOf3And5;
        }

        public int Answer(int inputs)
        {
            //1, 2, 3, 4, 5, 6, 7, 8, 9,  10, 11, 12, 13, 14, 15
            //0, 0, 3, 3, 3, 9, 9, 9, 18, 18, 18, 30, 30, 30, 45
            //0, 0, 1, 1, 1, 3, 3, 3, 6,  6,  6,  10, 10, 10, 15
            //0, 0, 0, 0, 5, 5, 5, 5, 5,  15, 15, 15, 15, 15, 30
            //0, 0, 0, 0, 1, 1, 1, 1, 1,  3,  3,  3,  3,  3,  6
            //Triangle numbers * 3 or 5

            var multipleOf3Result = CalculateMultipleOf(inputs, 3);
            var multipleOf5Result = CalculateMultipleOf(inputs, 5);
            var multipleOf3And5Result = CalculateMultipleOf(inputs, 15);
            var result = multipleOf3Result + multipleOf5Result - multipleOf3And5Result;
            return result;
        }

        private static int CalculateMultipleOf(int inputs, int divisor)
        {
            var n = (inputs - 1) / divisor;
            var nTriangleNumber = n * (n + 1) / 2;
            var multipleOfDivisorResult = nTriangleNumber * divisor;
            return multipleOfDivisorResult;
        }
    }
}
