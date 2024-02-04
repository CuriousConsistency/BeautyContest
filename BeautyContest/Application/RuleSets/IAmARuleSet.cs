namespace BeautyContest.Application.RuleSets;

using Domain;

public interface IAmARuleSet
{
    public void Play(int[] scores, List<Player> players);
}