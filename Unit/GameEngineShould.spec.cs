namespace Unit;

using NUnit.Framework;
using TestFramework;

public partial class GameEngineShould : Specification
{
    [TestCase]
    public void ThrowExceptionForIncorrectNumberOfScores()
    {
        Given(a_game_with_five_alive_players);
        When(playing_incorrectly_with_four_scores);
        Then(exception_thrown_for_incorrect_number_of_scores);
    }

    [TestCase]
    public void ReturnFivePlayers()
    {
        Given(a_game_with_five_alive_players);
        When(playing_with_five_scores);
        Then(five_players_are_returned);
    }

    [TestCase]
    public void PlayFirstRuleSetWhenNoPlayersHaveLost()
    {
        Given(a_game_with_five_alive_players);
        When(playing_with_five_scores);
        Then(ruleset_one_is_played);
    }
    
    [TestCase]
    public void KillPlayerWhenTenPointsAreLost()
    {
        Given(a_game_with_five_alive_players);
        When(a_player_loses_minus_ten_points);
        Then(a_player_loses_the_game);
    }
    
    [TestCase]
    public void NotRequireScoreForDeadPlayer()
    {
        Given(a_game_with_four_alive_players);
        When(playing_incorrectly_with_five_scores);
        Then(exception_thrown_for_incorrect_number_of_scores);
    }
    
    [TestCase]
    public void PlaySecondRuleSetWhenOnePlayerHasLost()
    {
        Given(a_game_with_four_alive_players);
        When(playing_with_four_scores);
        Then(ruleset_two_is_played);
    }    
    
    [TestCase]
    public void PlayThirdRuleSetWhenTwoPlayersHaveLost()
    {
        Given(a_game_with_three_alive_players);
        When(playing_with_three_scores);
        Then(ruleset_three_is_played);
    }    
    
    [TestCase]
    public void PlayFourthRuleSetWhenThreePlayersHaveLost()
    {
        Given(a_game_with_two_alive_players);
        When(playing_with_two_scores);
        Then(ruleset_four_is_played);
    }
}