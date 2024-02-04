namespace BeautyContest.Application;

using Domain;
using Domain.Exceptions;
using System.Linq;
using RuleSets;
using RuleSets.Factory;

public class GameEngine
{
    private readonly IAmARuleSetFactory ruleSetFactory;
    private const int NumberOfPlayers = 5;
    private const int LowerBound = 0;
    private const int UpperBound = 100;
    private readonly List<Player> players = [];

    public GameEngine(IAmARuleSetFactory ruleSetFactory)
    {
        this.ruleSetFactory = ruleSetFactory;
        CreatePlayers();
    }

    private void CreatePlayers()
    {
        for (int i = 0; i < NumberOfPlayers; i++)
        {
            players.Add(new Player());
        }
    }

    public void Play(int[] scores)
    {
        var numberOfPlayersAlive = players.Count(p => p.IsAlive);
        ValidateScores(scores, numberOfPlayersAlive);

        ruleSetFactory.GetRule((RuleSet)(NumberOfPlayers - numberOfPlayersAlive + 1)).Play(scores, players.Where(p => p.IsAlive).ToList());
    }

    private static void ValidateScores(int[] scores, int numberOfPlayersAlive)
    {
        if (scores.Length != numberOfPlayersAlive) throw new IncorrectNumberOfScoresException();
        if (scores.Any(s => s is < LowerBound or > UpperBound)) throw new ScoreOutOfBoundsException();
    }

    public List<Player> GetPlayers()
    {
        return players;
    }
}