namespace BeautyContest.Domain;

public class Player
{
    public int Points { get; private set; }
    internal uint Difference { get; private set; }
    internal Score Score { get; set; }
    internal int Rank { get; set; }

    internal void SetDifference(int goal)
    {
        Difference = (uint)Math.Abs(Score - goal);
    }

    public void DeductPoint()
    {
        Points--;
    }

    public bool IsAlive => Points > -10;
}