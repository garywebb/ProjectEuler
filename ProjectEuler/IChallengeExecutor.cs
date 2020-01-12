namespace ProjectEuler
{
    public interface IChallengeExecutor
    {
        Result Execute(Challenge challenge, IChallengeAnswerer answer);
    }
}