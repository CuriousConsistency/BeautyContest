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
    private readonly List<Player> players = [];

    public GameEngine(IAmARuleSetFactory ruleSetFactory)
    {
        this.ruleSetFactory = ruleSetFactory;
        for (int i = 0; i < NumberOfPlayers; i++)
        {
            players.Add(new Player());
        }
    }

    public void Play(int[] scores)
    {
        var numberOfPlayersAlive = players.Count(p => p.IsAlive);
        if (scores.Length != numberOfPlayersAlive) throw new IncorrectNumberOfScoresException();
        
        ruleSetFactory.GetRule((RuleSet)(NumberOfPlayers - numberOfPlayersAlive + 1)).Play(scores, players.Where(p => p.IsAlive).ToList());
    }
    
    public List<Player> GetPlayers()
    {
        return players;
    }
}