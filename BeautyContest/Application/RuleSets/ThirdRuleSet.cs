namespace BeautyContest.Application.RuleSets;

using Domain;

public class ThirdRuleSet : SecondRuleSet
{
    public override void Play(int[] scores, List<Player> players)
    {
        Penalty = 1;
        SetScores(scores,players);
        SetDifferences(scores, players);
        RankPlayers(players);
        DoublePenaltyIfOnePlayerScoredExactGoal(players);
        base.Play(scores,players);
    }

    private void DoublePenaltyIfOnePlayerScoredExactGoal(List<Player> players)
    {
        if (players.Any(p => p.Score == Goal))
        {
            Penalty = 2;
        }
    }
}