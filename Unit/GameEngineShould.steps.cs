namespace Unit;

using BeautyContest.Application;
using BeautyContest.Domain;
using BeautyContest.Domain.Exceptions;
using FluentAssertions;
using NSubstitute;

public partial class GameEngineShould
{
    private GameEngine gameEngine = null!;
    private Action comparison = null!;
    private FakeRuleSetFactory fakeRuleSetFactory = new();

    private void create_game()
    {
        fakeRuleSetFactory.Reset();
        gameEngine = new GameEngine(fakeRuleSetFactory);
    }
    private void a_game_with_five_alive_players()
    {
        create_game();
    }
    
    private void a_game_with_four_alive_players()
    {
        create_game();
        playing_the_game([100, 80, 80, 80, 80]);
    }

    private void a_game_with_three_alive_players()
    {
        create_game();
        playing_the_game([100, 80, 80, 80, 80]);
        playing_the_game([100, 80, 80, 80]);
    }

    private void a_game_with_two_alive_players()
    {
        create_game();
        playing_the_game([100, 80, 80, 80, 80]);
        playing_the_game([100, 80, 80, 80]);
        playing_the_game([100, 80, 80]);
    }

    private void playing_the_game(params int[] scores)
    {
        gameEngine.Play(scores);
    }

    private void playing_with_five_scores()
    {
        playing_the_game([100, 80, 80, 80, 80]);
    }
    
    private void playing_incorrectly_with_five_scores()
    {
        comparison = () => { gameEngine.Play([80,80,80,80,80]); };
    }  
    
    private void playing_incorrectly_with_four_scores()
    {
        comparison = () => { gameEngine.Play([80,80,80,80]); };
    }     
    
    private void playing_with_four_scores()
    {
        gameEngine.Play([80, 80, 80, 80]);
    }      
    
    private void playing_with_three_scores()
    {
        gameEngine.Play([80, 80, 80]);
    }     
    
    private void playing_with_two_scores()
    {
        gameEngine.Play([80, 80]);
    }         
    
    private void exception_thrown_for_incorrect_number_of_scores()
    {
        comparison.Should().Throw<IncorrectNumberOfScoresException>();
    }

    private void five_players_are_returned()
    {
        gameEngine.GetPlayers().Count.Should().Be(5);
    }

    private void ruleset_one_is_played()
    {
        fakeRuleSetFactory.FirstRuleSet.Received(1).Play(Arg.Any<int[]>(), Arg.Any<List<Player>>());
        fakeRuleSetFactory.SecondRuleSet.Received(0).Play(Arg.Any<int[]>(), Arg.Any<List<Player>>());
    }    
    
    private void ruleset_two_is_played()
    {
        fakeRuleSetFactory.FirstRuleSet.Received(1).Play(Arg.Any<int[]>(), Arg.Any<List<Player>>());
        fakeRuleSetFactory.SecondRuleSet.Received(1).Play(Arg.Any<int[]>(), Arg.Any<List<Player>>());
        fakeRuleSetFactory.ThirdRuleSet.Received(0).Play(Arg.Any<int[]>(), Arg.Any<List<Player>>());
    }    
    
    private void ruleset_three_is_played()
    {
        fakeRuleSetFactory.FirstRuleSet.Received(1).Play(Arg.Any<int[]>(), Arg.Any<List<Player>>());
        fakeRuleSetFactory.SecondRuleSet.Received(1).Play(Arg.Any<int[]>(), Arg.Any<List<Player>>());
        fakeRuleSetFactory.ThirdRuleSet.Received(1).Play(Arg.Any<int[]>(), Arg.Any<List<Player>>());
        fakeRuleSetFactory.FourthRuleSet.Received(0).Play(Arg.Any<int[]>(), Arg.Any<List<Player>>());
    }    
    
    private void ruleset_four_is_played()
    {
        fakeRuleSetFactory.FirstRuleSet.Received(1).Play(Arg.Any<int[]>(), Arg.Any<List<Player>>());
        fakeRuleSetFactory.SecondRuleSet.Received(1).Play(Arg.Any<int[]>(), Arg.Any<List<Player>>());
        fakeRuleSetFactory.ThirdRuleSet.Received(1).Play(Arg.Any<int[]>(), Arg.Any<List<Player>>());
        fakeRuleSetFactory.FourthRuleSet.Received(1).Play(Arg.Any<int[]>(), Arg.Any<List<Player>>());
    }
    
    private void a_player_loses_minus_ten_points()
    {
        playing_the_game([100, 80, 80, 80, 80]);
    }
    
    private void a_player_loses_the_game()
    {
        fakeRuleSetFactory.Players[0].IsAlive.Should().Be(false);
        fakeRuleSetFactory.Players[1].IsAlive.Should().Be(true);
        fakeRuleSetFactory.Players[2].IsAlive.Should().Be(true);
        fakeRuleSetFactory.Players[3].IsAlive.Should().Be(true);
        fakeRuleSetFactory.Players[4].IsAlive.Should().Be(true);
    }
}