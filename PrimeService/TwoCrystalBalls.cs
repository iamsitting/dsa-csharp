namespace PrimeService;

public interface ITwoCrystalBalls
{
    public int FindBreakingPoint(bool[] breaks);
}

public class TwoCrystalBalls : ITwoCrystalBalls
{
    public int FindBreakingPoint(bool[] breaks)
    {
        var jumpAmount = (int) Math.Floor(Math.Sqrt(breaks.Length));
        Console.WriteLine($"Jump Amount: {jumpAmount}");
        var i = jumpAmount;

        // jump until a break is found
        for(; i < breaks.Length; i += jumpAmount)
        {
            if(breaks[i]) break;
        }

        Console.WriteLine($"First ball broke at: {i}");

        // go back one jump, i.e., the last jump with a non-break
        i -= jumpAmount;
        Console.WriteLine($"Second crystal ball should start at: {i}");

        // scan the jump to find the first break
        for(var j = 0; j <= jumpAmount && i < breaks.Length; j++, i++)
        {
            if(breaks[i]) return i;
        }

        return -1;
    }
}
