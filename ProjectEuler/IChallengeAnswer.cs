using System.Threading;

namespace ProjectEuler
{
    public interface IChallengeAnswerer
    {
        bool CanAnswer(Challenge challenge);
        object Answer(object inputs, CancellationToken cancellationToken);
    }
}