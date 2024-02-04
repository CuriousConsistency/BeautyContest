namespace Unit.RuleSet;

using BeautyContest.Application.RuleSets;
using BeautyContest.Domain;
using FluentAssertions;

public partial class ThirdRuleSetShould
{
    private void a_game_with_three_players_and_rule_set_three()
    {
        players = new List<Player>();
        for (int i = 0; i < 3; i++)
        {
            players.Add(new Player());
        }

        ruleSet = new ThirdRuleSet();
    }
    
    private void players_without_exact_correct_number_lose_two_points()
    {
        players[0].Points.Should().Be(0);
        players[1].Points.Should().Be(-2);
        players[2].Points.Should().Be(-2);
    }    
    
    private void penalty_returns_to_one()
    {
        players[0].Points.Should().Be(-1);
        players[1].Points.Should().Be(-3);
        players[2].Points.Should().Be(-2);
    }
}