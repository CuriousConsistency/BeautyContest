namespace Unit.RuleSet;

using BeautyContest.Application.RuleSets;
using BeautyContest.Domain;
using TestFramework;

public class RuleSetSpecification : Specification
{
    protected List<Player> players = null!;
    protected IAmARuleSet ruleSet = null!;
    
    protected void playing_the_game(params int[] scores)
    {
        ruleSet.Play(scores, players);
    }
}