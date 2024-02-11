namespace Unit.Application.RuleSet;

using BeautyContest.Application.RuleSets;
using BeautyContest.Domain;
using FluentAssertions;

public partial class ThirdRuleSetShould
{
    private void a_game_with_three_players_and_rule_set_three()
    {
        Players = [];
        for (var i = 0; i < 3; i++)
        {
            Players.Add(new Player());
        }

        RuleSet = new ThirdRuleSet();
    }
    
    private void players_without_exact_correct_number_lose_two_points()
    {
        Players[0].Points.Should().Be(0);
        Players[1].Points.Should().Be(-2);
        Players[2].Points.Should().Be(-2);
    }    
    
    private void penalty_returns_to_one()
    {
        Players[0].Points.Should().Be(-1);
        Players[1].Points.Should().Be(-3);
        Players[2].Points.Should().Be(-2);
    }
}