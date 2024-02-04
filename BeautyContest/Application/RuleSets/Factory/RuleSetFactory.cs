namespace BeautyContest.Application.RuleSets.Factory;

using RuleSets;

public class RuleSetFactory : IAmARuleSetFactory
{
    private IAmARuleSet? firstRuleSet;
    private IAmARuleSet? secondRuleSet;
    private IAmARuleSet? threeRuleSet;
    private IAmARuleSet? fourthRuleSet;
    
    public IAmARuleSet GetRule(RuleSet ruleSet)
    {
        return ruleSet switch
        {
            RuleSet.One => firstRuleSet ??= new FirstRuleSet(),
            RuleSet.Two => secondRuleSet ??= new SecondRuleSet(),
            RuleSet.Three => threeRuleSet ??= new ThirdRuleSet(),
            RuleSet.Four => fourthRuleSet ??= new FourthRuleSet(),
            _ => throw new ArgumentException()
        };
    }
}