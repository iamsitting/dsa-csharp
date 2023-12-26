namespace PrimeService.Tests;

public class TwoCrystalBallsTests
{
    private ITwoCrystalBalls _sut;
    [SetUp]
    public void Setup()
    {
        _sut = new TwoCrystalBalls();
    }

    [Test]
    public void WhenBreakpointIs20_Return20()
    {
        // arrange
        int[] raw = {
            0,0,0,0,0,
            0,0,0,0,0,
            0,0,0,0,0,
            0,0,0,0,0,
            1,1,1,1,1};
        bool[] input = raw.Select(x => x == 1).ToArray();

        // act
        var result = _sut.FindBreakingPoint(input);

        // assert
        Assert.That(result, Is.EqualTo(20));
    }

    [Test]
    public void WhenBreakpointIs5_Return5()
    {
        // arrange
        int[] raw = {
            0,0,0,0,0,
            1,1,1,1,1,
            1,1,1,1,1,
            1,1,1,1,1,
            1,1,1,1,1,
            1,1,1,1,1};
        bool[] input = raw.Select(x => x == 1).ToArray();

        // act
        var result = _sut.FindBreakingPoint(input);

        // assert
        Assert.That(result, Is.EqualTo(5));
    }
}