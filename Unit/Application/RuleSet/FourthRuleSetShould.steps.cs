namespace Unit.Application.RuleSet;

using BeautyContest.Application.RuleSets;
using BeautyContest.Domain;
using FluentAssertions;

public partial class FourthRuleSetShould
{
    private void a_game_with_two_players_and_rule_set_four()
    {
        Players = [];
        for (var i = 0; i < 2; i++)
        {
            Players.Add(new Player());
        }

        RuleSet = new FourthRuleSet();
    }
    
    private void one_player_loses()
    {
        Players[0].Points.Should().Be(0);
        Players[1].Points.Should().Be(-1);
    }

    private void player_two_loses_double_points()
    {
        Players[0].Points.Should().Be(0);
        Players[1].Points.Should().Be(-2);
    }    
    
    private void player_two_loses_one_point()
    {
        Players[0].Points.Should().Be(0);
        Players[1].Points.Should().Be(-1);
    }
}