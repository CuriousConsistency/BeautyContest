namespace BeautyContest.Application.RuleSets.Factory;

using RuleSets;

public class RuleSetFactory : IAmARuleSetFactory
{
    private IAmARuleSet firstRuleSet = null!;
    private IAmARuleSet secondRuleSet = null!;
    private IAmARuleSet threeRuleSet = null!;
    private IAmARuleSet fourthRuleSet = null!;
    
    public IAmARuleSet GetRule(RuleSet ruleSet)
    {
        switch (ruleSet)
        {
            case RuleSet.One:
                if (firstRuleSet == null)
                {
                    firstRuleSet = new FirstRuleSet(); 
                }
                return firstRuleSet;            
            case RuleSet.Two:
                if (secondRuleSet is null)
                {
                    secondRuleSet = new SecondRuleSet(); 
                }
                return secondRuleSet;            
            case RuleSet.Three:
                if (threeRuleSet is null)
                {
                    threeRuleSet = new ThirdRuleSet(); 
                }
                return threeRuleSet;            
            case RuleSet.Four:
                if (fourthRuleSet is null)
                {
                    fourthRuleSet = new FourthRuleSet(); 
                }
                return fourthRuleSet;
            default:
                throw new ArgumentException();
        }
    }
}