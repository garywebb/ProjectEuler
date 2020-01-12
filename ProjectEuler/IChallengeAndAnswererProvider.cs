using System.Collections.Generic;

namespace ProjectEuler
{
    public interface IChallengeAndAnswererProvider
    {
        IEnumerable<ChallengeAndAnswerer> GetAnswerers(IEnumerable<Challenge> challenges);
    }
}