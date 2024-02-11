namespace BeautyContest.Domain;

using Exceptions;

public readonly record struct Score : IComparable<Score>
{
    private readonly int score;

    public Score(int score)
    {
        Validate(score);
        this.score = score;
    }

    public static implicit operator Score(int value)
    {
        return new Score(value);
    }    
    
    public static implicit operator int(Score value)
    {
        return value.score;
    }    
    
    private static void Validate(int value)
    {
        if (value is < 0 or > 100) throw new ScoreOutOfBoundsException();
    }

    public int CompareTo(Score other)
    {
        if (score > other.score)
            return 1;
        if (score < other.score)
            return -1;
        return 0;
    }
}