namespace Unit.RuleSet;

using NUnit.Framework;

public partial class SecondRuleSetShould : RuleSetSpecification
{
    [Test]
    public void RemovePointsForPlayersWhoPickMatchingNumbers()
    {
        Given(a_game_with_four_players_and_rule_set_two);
        When(() => playing_the_game(80,80,90,80));
        Then(players_with_matching_numbers_lose_a_point);
    }
    
    [Test]
    public void NotRemovePointForWinningPlayer()
    {
        Given(a_game_with_four_players_and_rule_set_two);
        When(() => playing_the_game(80,100,100,100));
        Then(winning_player_points_should_be_zero);
    }
    
    [Test]
    public void RemoveOnePointForLosingPlayers()
    {
        Given(a_game_with_four_players_and_rule_set_two);
        When(() => playing_the_game(80,96,97,98));
        Then(player_one_loses_no_points_and_other_players_lose_points);
    }
    
    [Test]
    public void RemoveTwoPointsForSameLosingPlayersInTwoPlays()
    {
        Given(a_game_with_four_players_and_rule_set_two);
        When(() => playing_the_game(100,81,82,83));
        When(() => playing_the_game(100,81,82,83));
        Then(losing_player_loses_two_points);
    }
}