namespace Unit.RuleSet;

using BeautyContest.Application.RuleSets;
using BeautyContest.Domain;
using FluentAssertions;

public partial class SecondRuleSetShould
{
    private void a_game_with_four_players_and_rule_set_two()
    {
        players = new List<Player>();
        for (int i = 0; i < 4; i++)
        {
            players.Add(new Player());
        }

        ruleSet = new SecondRuleSet();
    }
    
    private void players_with_matching_numbers_lose_a_point()
    {
        players[0].Points.Should().Be(-1);
        players[1].Points.Should().Be(-1);
        players[2].Points.Should().Be(0);
        players[3].Points.Should().Be(-1);
    }
    
    private void winning_player_points_should_be_zero()
    {
        players[0].Points.Should().Be(0);
    }
    
    private void player_one_loses_no_points_and_other_players_lose_points()
    {
        players[0].Points.Should().Be(0);
        players[1].Points.Should().Be(-1);
        players[2].Points.Should().Be(-1);
        players[3].Points.Should().Be(-1);
    }
    
    private void losing_player_loses_two_points()
    {
        players[0].Points.Should().Be(-2);
        players[1].Points.Should().Be(0);
        players[2].Points.Should().Be(-2);
        players[3].Points.Should().Be(-2);
    }  
}