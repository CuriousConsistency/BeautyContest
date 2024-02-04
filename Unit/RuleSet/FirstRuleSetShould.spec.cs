namespace Unit.RuleSet;

using NUnit.Framework;

public partial class FirstRuleSetShould : RuleSetSpecification
{
    [Test]
    public void NotRemovePointForWinningPlayer()
    {
        Given(a_game_with_five_players_and_rule_set_one);
        When(() => playing_the_game(80,100,100,100,100));
        Then(winning_player_points_should_be_zero);
    }

    [Test]
    public void RemoveOnePointForLosingPlayers()
    {
        Given(a_game_with_five_players_and_rule_set_one);
        When(() => playing_the_game(80,100,100,100,100));
        Then(player_one_loses_no_points_and_other_players_lose_points);
    }    
    
    [Test]
    public void NotRemovePointsWhenAllPlayersDraw()
    {
        Given(a_game_with_five_players_and_rule_set_one);
        When(() => playing_the_game(100,100,100,100,100));
        Then(no_player_loses_points);
    }    
    
    [Test]
    public void RemoveTwoPointsForSameLosingPlayerInTwoPlays()
    {
        Given(a_game_with_five_players_and_rule_set_one);
        When(() => playing_the_game(100,80,80,80,80));
        When(() => playing_the_game(100,80,80,80,80));
        Then(one_player_loses_two_points);
    }

    [Test]
    public void RankHigherScoringPlayerFirstIfTwoPlayersHaveTheSameDifference()
    {
        Given(a_game_with_five_players_and_rule_set_one);
        When(() => playing_the_game(6,8,2,20,10));
        Then(player_two_does_not_lose_a_point);
    }
}