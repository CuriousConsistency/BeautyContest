namespace Unit.Application.RuleSet;

using BeautyContest.Application.RuleSets;
using BeautyContest.Domain;
using FluentAssertions;

public partial class SecondRuleSetShould
{
    private void a_game_with_four_players_and_rule_set_two()
    {
        Players = [];
        for (var i = 0; i < 4; i++)
        {
            Players.Add(new Player());
        }

        RuleSet = new SecondRuleSet();
    }
    
    private void players_with_matching_numbers_lose_a_point()
    {
        Players[0].Points.Should().Be(-1);
        Players[1].Points.Should().Be(-1);
        Players[2].Points.Should().Be(0);
        Players[3].Points.Should().Be(-1);
    }
    
    private void winning_player_points_should_be_zero()
    {
        Players[0].Points.Should().Be(0);
    }
    
    private void player_one_loses_no_points_and_other_players_lose_points()
    {
        Players[0].Points.Should().Be(0);
        Players[1].Points.Should().Be(-1);
        Players[2].Points.Should().Be(-1);
        Players[3].Points.Should().Be(-1);
    }
    
    private void losing_player_loses_two_points()
    {
        Players[0].Points.Should().Be(-2);
        Players[1].Points.Should().Be(0);
        Players[2].Points.Should().Be(-2);
        Players[3].Points.Should().Be(-2);
    }  
}