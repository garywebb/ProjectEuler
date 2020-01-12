namespace ProjectEuler
{
    public interface IChallengeAnswerer
    {
        bool CanAnswer(Challenge challenge);
        int Answer(int inputs);
    }
}