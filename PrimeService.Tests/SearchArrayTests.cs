namespace PrimeService.Tests;

public class SearchArrayTests
{
    private ILinearSearchArray _sut;
    [SetUp]
    public void Setup()
    {
        _sut = new LinearSearchArray();
    }

    [Test]
    public void WhenValueIsFound_ReturnTrue()
    {
        // arrange
        int [] input = {1, 2, 3, 4, 5, 6, 10};

        // act
        var result = _sut.Search(input, 4);

        // assert
        Assert.That(result, Is.True);
    }

    [Test]

    public void WhenValueIsNotFound_ReturnFalse()
    {
        // arrange
        int [] input = {1, 2, 3, 4, 5, 6, 10};

        // act
        var result = _sut.Search(input, 7);

        // assert
        Assert.That(result, Is.False);
    }
}