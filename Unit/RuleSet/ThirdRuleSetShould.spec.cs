namespace Unit.RuleSet;

using NUnit.Framework;
using TestFramework;

public partial class ThirdRuleSetShould : RuleSetSpecification
{
    [TestCase]
    public void DoubleLoserPenaltyIfPlayerPicksExactCorrectNumber()
    {
        Given(a_game_with_three_players_and_rule_set_three);
        When(() => playing_the_game(1,0,2));
        Then(players_without_exact_correct_number_lose_two_points);
    }
    
    [TestCase]
    public void ResetLoserPenaltyOnNextTurn()
    {
        Given(a_game_with_three_players_and_rule_set_three);
        When(() => playing_the_game(1,0,2));
        When(() => playing_the_game(4,0,3));
        Then(penalty_returns_to_one);
    }
}