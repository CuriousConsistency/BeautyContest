namespace BeautyContest.Application.RuleSets.Factory;

using RuleSets;

public interface IAmARuleSetFactory
{
    public IAmARuleSet GetRuleSet(RuleSet ruleSet);
}