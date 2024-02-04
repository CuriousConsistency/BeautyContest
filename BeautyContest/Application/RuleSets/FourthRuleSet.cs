namespace BeautyContest.Application.RuleSets;

using Domain;

public class FourthRuleSet : ThirdRuleSet
{
    public override void Play(int[] scores, List<Player> players)
    {
        SetScores(scores,players);
        if (OnePlayerChoseZeroAndAnotherChoseOneHundred(players)) return;
        base.Play(scores, players);
    }

    private static bool OnePlayerChoseZeroAndAnotherChoseOneHundred(List<Player> players)
    {
        if (players.Any(p => p.Score == 0) && players.Any(p => p.Score == 100))
        {
            foreach (var player in players.Where(p => p.Score != 100))
            {
                player.DeductPoint();
            }
            
            ResetChecks();
            return true;
        }

        return false;
    }
}