namespace Acceptance;

using NUnit.Framework;
using TestFramework;

[TestFixture]
public partial class BeautyContestShould: Specification
{
    [Test]
    public void LetChishiyaWinAgainstTheKingOfDiamondsMasterKuzuryu()
    {
        Given(a_beauty_contest_with_Chishiya_Daimon_Yashige_Asuma_and_Kuzuryu);
        When(() => playing_the_game(32,40,30,33,29));
        Then(() => the_points_are(-1,-1,-1,-1,0));        
        When(() => playing_the_game(17,21,16,15,14));
        Then(() => the_points_are(-2,-2,-2,-2,0));        
        When(() => playing_the_game(7,11,3,7,5));
        Then(() => the_points_are(-3,-3,-3,-3,0));        
        When(() => playing_the_game(2,4,0,0,1));
        Then(() => the_points_are(-4,-4,-4,-4,0));        
        When(() => playing_the_game(100,1,0,0,0));
        Then(() => the_points_are(-5,-4,-5,-5,-1));        
        When(() => playing_the_game(25,100,0,5,17));
        Then(() => the_points_are(-5,-5,-6,-6,-2));        
        When(() => playing_the_game(100,30,0,4,10));
        Then(() => the_points_are(-6,-5,-7,-7,-3));        
        When(() => playing_the_game(20,10,36,34,20));
        Then(() => the_points_are(-6,-6,-8,-8,-3));        
        When(() => playing_the_game(6,8,2,20,10));
        Then(() => the_points_are(-7,-6,-9,-9,-4));        
        When(() => playing_the_game(1,7,0,0,2));
        Then(() => the_points_are(-8,-7,-10,-10,-4));
        And(Yashige_and_Asuma_die);
        When(() => playing_the_game(1,1,1));
        Then(() => the_points_are(-9,-8,-10,-10,-5));        
        When(() => playing_the_game(23,62,1));
        Then(() => the_points_are(-9,-10,-10,-10,-7));
        And(Daimon_dies);
        When(() => playing_the_game(100,0));
        Then(() => the_points_are(-9,-10,-10,-10,-8));        
        When(() => playing_the_game(100,0));
        Then(() => the_points_are(-9,-10,-10,-10,-9));        
        When(() => playing_the_game(100,0));
        Then(() => the_points_are(-9,-10,-10,-10,-10));
        And(king_of_diamonds_master_Kuzuryu_dies);
        And(Chishiya_lives);
    }
}