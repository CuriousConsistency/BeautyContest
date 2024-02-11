namespace Unit.Application.RuleSet;

using BeautyContest.Application.RuleSets;
using BeautyContest.Domain;
using TestFramework;

public class RuleSetSpecification : Specification
{
    protected List<Player> Players = null!;
    protected IAmARuleSet RuleSet = null!;
    
    protected Action playing_the_game(params int[] scores)
    {
        return () =>
        {
            RuleSet.Play(scores, Players);
        };
    }
}