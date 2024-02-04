namespace Unit;

using NUnit.Framework;
using TestFramework;

public partial class GameEngineShould : Specification
{
    [Test]
    public void ThrowExceptionForIncorrectNumberOfScores()
    {
        Given(a_game_with_five_alive_players);
        When(playing_incorrectly_with_four_scores);
        Then(exception_thrown_for_incorrect_number_of_scores);
    }

    [Test]
    [TestCase(-1,5,6,7,10)]
    [TestCase(1,5,6,7,101)]
    public void ThrowExceptionForOutOfBoundsScores(params int[] scores)
    {
        Given(a_game_with_five_alive_players);
        When(() => playing_with_out_of_bounds_scores(scores));
        Then(exception_thrown_for_out_of_bounds_scores);
    }

    [Test]
    public void ReturnFivePlayers()
    {
        Given(a_game_with_five_alive_players);
        When(playing_with_five_scores);
        Then(five_players_are_returned);
    }

    [Test]
    public void PlayFirstRuleSetWhenNoPlayersHaveLost()
    {
        Given(a_game_with_five_alive_players);
        When(playing_with_five_scores);
        Then(ruleset_one_is_played);
    }
    
    [Test]
    public void KillPlayerWhenTenPointsAreLost()
    {
        Given(a_game_with_five_alive_players);
        When(a_player_loses_minus_ten_points);
        Then(a_player_loses_the_game);
    }
    
    [Test]
    public void NotRequireScoreForDeadPlayer()
    {
        Given(a_game_with_four_alive_players);
        When(playing_incorrectly_with_five_scores);
        Then(exception_thrown_for_incorrect_number_of_scores);
    }
    
    [Test]
    public void PlaySecondRuleSetWhenOnePlayerHasLost()
    {
        Given(a_game_with_four_alive_players);
        When(playing_with_four_scores);
        Then(ruleset_two_is_played);
    }    
    
    [Test]
    public void PlayThirdRuleSetWhenTwoPlayersHaveLost()
    {
        Given(a_game_with_three_alive_players);
        When(playing_with_three_scores);
        Then(ruleset_three_is_played);
    }    
    
    [Test]
    public void PlayFourthRuleSetWhenThreePlayersHaveLost()
    {
        Given(a_game_with_two_alive_players);
        When(playing_with_two_scores);
        Then(ruleset_four_is_played);
    }
}