using System.Threading.Tasks;

namespace ProjectEuler
{
    public interface IChallengeExecutor
    {
        Task<Result> ExecuteAsync(Challenge challenge, IChallengeAnswerer answer);
    }
}