namespace BeautyContest.Application.RuleSets;

using Domain;

public abstract class BaseRuleSet : IAmARuleSet
{
    protected static int Goal;
    protected int Penalty = 1;
    private static bool scoresAreSet;
    private static bool playersAreRanked;
    private static bool differencesAreSet;

    public virtual void Play(int[] scores, List<Player> players)
    {
        ResetChecks();
    }

    protected static void ResetChecks()
    {
        scoresAreSet = false;
        playersAreRanked = false;
        differencesAreSet = false;
    }

    protected static void SetScores(int[] scores, List<Player> players)
    {
        if (scoresAreSet) return;
        
        var playerCounter = 0;
        foreach (var score in scores)
        {
            players[playerCounter].Score = score;
            playerCounter++;
        }

        scoresAreSet = true;
    }
    
    protected void DeductPoints(List<Player> rankedPlayers)
    {
        for (int i = 0; i < Penalty; i++ )
        {
            foreach (var player in rankedPlayers.Where(p => p.Rank != 0))
            {
                player.DeductPoint();
            }  
        }
    }

    protected static void RankPlayers(List<Player> players)
    {
        if (playersAreRanked) return;
        players = players.OrderBy(p => p.Difference).ThenByDescending(p => p.Score).ToList();
        var rank = 0;
        var playerCounter = 0;
        
        foreach (var player in players)
        {
            player.Rank = rank;
            if (players.Count > playerCounter + 1 && (players[playerCounter].Difference < players[playerCounter + 1].Difference 
                || (players[playerCounter].Difference == players[playerCounter + 1].Difference && players[playerCounter].Score > players[playerCounter + 1].Score)))
            {
                rank++;
            }
            
            playerCounter++;
        }

        playersAreRanked = true;
    }

    protected static void SetDifferences(int[] scores, List<Player> players)
    {
        if (differencesAreSet) return;
        Goal =  (int)Math.Round(scores.Sum() / (double)scores.Length * 0.8);

        foreach (var player in players)
        {
            player.SetDifference(Goal); 
        }

        differencesAreSet = true;
    }
}