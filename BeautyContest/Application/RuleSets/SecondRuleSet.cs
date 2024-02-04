namespace BeautyContest.Application.RuleSets;

using Domain;

public class SecondRuleSet : FirstRuleSet
{
    public override void Play(int[] scores, List<Player> players)
    {
        SetScores(scores, players);
        var matchingPlayerGroups = players.GroupBy(p => p.Score).Where(g => g.Count() > 1).ToList();
        if (matchingPlayerGroups.Count > 0)
        {
            foreach (var matchingPlayers in matchingPlayerGroups)
            {
                foreach (var matchingPlayer in matchingPlayers)
                {
                    matchingPlayer.DeductPoint();
                }
            }

            return;
        }
        base.Play(scores,players);
    }
}