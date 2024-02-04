namespace Unit.RuleSet;

using NUnit.Framework;

public partial class FourthRuleSetShould : RuleSetSpecification
{
    [Test]
    public void DeclareWinnerForPlayerWhoPicksOneHundredWhenAnotherPlayerPicksZero()
    {
        Given(a_game_with_two_players_and_rule_set_four);
        When(() => playing_the_game(100,0));
        Then(one_player_loses);
    }

    [Test]
    public void PlayThirdRuleSetIfNobodyChoosesZero()
    {
        Given(a_game_with_two_players_and_rule_set_four);
        When(() => playing_the_game(1,2));
        Then(player_two_loses_double_points);
    }    
    
    [Test]
    public void PlayThirdRuleSetIfAPlayerChoosesZeroButNobodyChoosesOneHundred()
    {
        Given(a_game_with_two_players_and_rule_set_four);
        When(() => playing_the_game(0,99));
        Then(player_two_loses_one_point);
    }
}