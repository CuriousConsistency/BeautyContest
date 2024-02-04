namespace Unit;

using BeautyContest.Application.RuleSets;
using BeautyContest.Application.RuleSets.Factory;
using BeautyContest.Domain;
using NSubstitute;

    internal class FakeRuleSetFactory : IAmARuleSetFactory
    {
        public readonly IAmARuleSet FirstRuleSet;
        public readonly IAmARuleSet SecondRuleSet;
        public readonly IAmARuleSet ThirdRuleSet;
        public readonly IAmARuleSet FourthRuleSet;
        public List<Player> Players = null!;

        public FakeRuleSetFactory()
        {
            FirstRuleSet = Substitute.For<IAmARuleSet>();
            SecondRuleSet = Substitute.For<IAmARuleSet>();
            ThirdRuleSet = Substitute.For<IAmARuleSet>();
            FourthRuleSet = Substitute.For<IAmARuleSet>();
            SetupRuleSet(FirstRuleSet);
            SetupRuleSet(SecondRuleSet);
            SetupRuleSet(ThirdRuleSet);
            SetupRuleSet(FourthRuleSet);
        }

        public void Reset()
        {
            FirstRuleSet.ClearReceivedCalls();
            SecondRuleSet.ClearReceivedCalls();
            ThirdRuleSet.ClearReceivedCalls();
            FourthRuleSet.ClearReceivedCalls();
        }
        
        private void SetupRuleSet(IAmARuleSet ruleSet)
        {
            ruleSet.When(r => r.Play(Arg.Any<int[]>(), Arg.Any<List<Player>>())).Do(x =>
            {
                var player = ((List<Player>)x.Args()[1])[0];
                Players = ((List<Player>)x.Args()[1]);
                for(int i = 0; i < 10; i++) player.DeductPoint();
            });
        }

        public IAmARuleSet GetRule(BeautyContest.Application.RuleSets.RuleSet ruleSet)
        {
            return ruleSet switch
            {
                BeautyContest.Application.RuleSets.RuleSet.One => FirstRuleSet,
                BeautyContest.Application.RuleSets.RuleSet.Two => SecondRuleSet,
                BeautyContest.Application.RuleSets.RuleSet.Three => ThirdRuleSet,
                BeautyContest.Application.RuleSets.RuleSet.Four => FourthRuleSet,
                _ => throw new ArgumentException()
            };
        }
    }