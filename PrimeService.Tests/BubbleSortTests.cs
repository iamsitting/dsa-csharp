namespace PrimeService.Tests;

[TestFixture]
public class BubbleSortTests
{
    private IBubbleSort _sut;

    [SetUp]
    public void Setup()
    {
        _sut = new BubbleSort();
    }

    [Test]
    public void ShouldSort()
    {
        // arrange
        int[] input = { 5, 6, 3, 9, 10, 233, 5, 434, 2331, 9, 3, 1 };

        // act
        var result = _sut.Sort(input);
        Assert.Multiple(() =>
        {
            // assert
            Assert.That(result[0], Is.EqualTo(1));
            Assert.That(result[^1], Is.EqualTo(2331));
        });
    }
}
