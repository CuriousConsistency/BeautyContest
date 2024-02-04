namespace Acceptance;

using BeautyContest.Application;
using BeautyContest.Application.RuleSets.Factory;
using BeautyContest.Domain;
using FluentAssertions;

public partial class BeautyContestShould
{
    protected List<Player> players = null!;
    private GameEngine gameEngine = null!;

    private void a_beauty_contest_with_Chishiya_Daimon_Yashige_Asuma_and_Kuzuryu()
    {
        gameEngine = new GameEngine(new RuleSetFactory());
    }
    
    private void playing_the_game(params int[] scores)
    {
        gameEngine.Play(scores);
    }    
    
    private void the_points_are(params int[] points)
    {
        players = gameEngine.GetPlayers();
        players[0].Points.Should().Be(points[0]);
        players[1].Points.Should().Be(points[1]);
        players[2].Points.Should().Be(points[2]);
        players[3].Points.Should().Be(points[3]);
        players[4].Points.Should().Be(points[4]);
    }

    private void Yashige_and_Asuma_die()
    {
        players[0].IsAlive.Should().Be(true);
        players[1].IsAlive.Should().Be(true);
        players[2].IsAlive.Should().Be(false);
        players[3].IsAlive.Should().Be(false);
        players[4].IsAlive.Should().Be(true);
    }

    private void Daimon_dies()
    {
        players[0].IsAlive.Should().Be(true);
        players[1].IsAlive.Should().Be(false);
        players[2].IsAlive.Should().Be(false);
        players[3].IsAlive.Should().Be(false);
        players[4].IsAlive.Should().Be(true);
    }

    private void king_of_diamonds_master_Kuzuryu_dies()
    {
        players[0].IsAlive.Should().Be(true);
        players[1].IsAlive.Should().Be(false);
        players[2].IsAlive.Should().Be(false);
        players[3].IsAlive.Should().Be(false);
        players[4].IsAlive.Should().Be(false);
    }

    private void Chishiya_lives() {}
}