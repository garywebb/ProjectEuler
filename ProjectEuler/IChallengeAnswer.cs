using System.Threading;

namespace ProjectEuler
{
    public interface IChallengeAnswerer<in TIn, out TOut>
    {
        bool CanAnswer(Challenge challenge);
        TOut Answer(TIn inputs, CancellationToken cancellationToken);
    }
}