using System.Linq;

namespace ProjectEuler
{
    public class LinqMultiplesOf3And5Answerer : IChallengeAnswerer
    {
        public bool CanAnswer(Challenge challenge)
        {
            return challenge.Name == ChallengeNames.MultiplesOf3And5;
        }

        public int Answer(int inputs)
        {
            var numbers = Enumerable.Range(1, inputs - 1);
            var multiplesOf3And5 = numbers.Where(number => number % 3 == 0 || number % 5 == 0);
            var result = multiplesOf3And5.Sum();
            return result;
        }
    }
}
