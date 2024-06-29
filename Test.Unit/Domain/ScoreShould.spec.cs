namespace Unit.Domain;

using NUnit.Framework;
using TestFramework;

public partial class ScoreShould : Specification
{
    [Test]
    [TestCase(-1, true)]
    [TestCase(0, false)]
    [TestCase(100, false)]
    [TestCase(101, true)]
    public void ThrowExceptionForOutOfBoundsScores(int score, bool exceptionShouldBeThrown)
    {
        When(creating_a_score_with_value(score));
        Then(it_throws_an_exception(exceptionShouldBeThrown));
    }
}