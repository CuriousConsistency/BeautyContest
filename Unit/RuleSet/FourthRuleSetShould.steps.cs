namespace Unit.RuleSet;

using BeautyContest.Application.RuleSets;
using BeautyContest.Domain;
using FluentAssertions;

public partial class FourthRuleSetShould
{
    private void a_game_with_two_players_and_rule_set_four()
    {
        players = new List<Player>();
        for (int i = 0; i < 2; i++)
        {
            players.Add(new Player());
        }

        ruleSet = new FourthRuleSet();
    }
    
    private void one_player_loses()
    {
        players[0].Points.Should().Be(0);
        players[1].Points.Should().Be(-1);
    }
}