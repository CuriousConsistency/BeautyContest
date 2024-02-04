namespace BeautyContest.Application.RuleSets.Factory;

using RuleSets;

public interface IAmARuleSetFactory
{
    public IAmARuleSet GetRule(RuleSet ruleSet);
}