using System.Threading;

namespace ProjectEuler
{
    public interface IChallengeAnswerer
    {
        bool CanAnswer(Challenge challenge);
        long Answer(long inputs, CancellationToken cancellationToken);
    }
}