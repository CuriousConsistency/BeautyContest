namespace Unit.Application.RuleSet;

using BeautyContest.Application.RuleSets;
using BeautyContest.Domain;
using FluentAssertions;

public partial class FirstRuleSetShould
{
    private void a_game_with_five_players_and_rule_set_one()
    {
        Players = [];
        for (var i = 0; i < 5; i++)
        {
            Players.Add(new Player());
        }

        RuleSet = new FirstRuleSet();
    }
    
    private void winning_player_points_should_be_zero()
    {
        Players[0].Points.Should().Be(0);
    }
    
    private void one_player_loses_two_points()
    {
        Players[0].Points.Should().Be(-2);
        Players[1].Points.Should().Be(0);
        Players[2].Points.Should().Be(0);
        Players[3].Points.Should().Be(0);
        Players[4].Points.Should().Be(0);
    }    
    
    private void no_player_loses_points()
    {
        Players[0].Points.Should().Be(0);
        Players[1].Points.Should().Be(0);
        Players[2].Points.Should().Be(0);
        Players[3].Points.Should().Be(0);
        Players[4].Points.Should().Be(0);
    }
    
    private void player_one_loses_no_points_and_other_players_lose_points()
    {
        Players[0].Points.Should().Be(0);
        Players[1].Points.Should().Be(-1);
        Players[2].Points.Should().Be(-1);
        Players[3].Points.Should().Be(-1);
        Players[4].Points.Should().Be(-1);
    }

    private void player_two_does_not_lose_a_point()
    {
        Players[0].Points.Should().Be(-1);
        Players[1].Points.Should().Be(0);
        Players[2].Points.Should().Be(-1);
        Players[3].Points.Should().Be(-1);
        Players[4].Points.Should().Be(-1);
    }
}