namespace BeautyContest.Application.RuleSets;

using Domain;

public class FourthRuleSet : ThirdRuleSet
{
    public override void Play(int[] scores, List<Player> players)
    {
        SetScores(scores,players);
        if (players.Any(p => p.Score == 0))
        {
            foreach (var player in players.Where(p => p.Score != 100))
            {
                player.DeductPoint();
            }

            return;
        }
        base.Play(scores, players);
    }
}