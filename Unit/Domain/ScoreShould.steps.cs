namespace Unit.Domain;

using BeautyContest.Domain;
using BeautyContest.Domain.Exceptions;
using FluentAssertions;

public partial class ScoreShould
{
   private Action create_score = null!;
   
   private Action creating_a_score_with_value(int score)
   {
      return () =>
      {
         create_score = () => { new Score(score); };
      };
   }

   private Action it_throws_an_exception(bool exceptionShouldBeThrown)
   {
      return () =>
      {
         if (exceptionShouldBeThrown) create_score.Should().Throw<ScoreOutOfBoundsException>();
         else create_score.Should().NotThrow<ScoreOutOfBoundsException>();
      };
   }
}