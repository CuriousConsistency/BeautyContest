namespace Unit.RuleSet;

using NUnit.Framework;
using TestFramework;

public partial class FourthRuleSetShould : RuleSetSpecification
{
    [TestCase]
    public void DeclareWinnerForPlayerWhoPicksOneHundredWhenAnotherPlayerPicksZero()
    {
        Given(a_game_with_two_players_and_rule_set_four);
        When(() => playing_the_game(100,0));
        Then(one_player_loses);
    }
}