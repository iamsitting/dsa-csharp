namespace PrimeService;

public interface ILinearSearchArray
{
    public bool Search(int[] array, int val);
}

public class LinearSearchArray : ILinearSearchArray
{
    public bool Search(int[] array, int val)
    {
        for(var i = 0; i < array.Length; i++)
        {
            if(val == array[i]) return true;
        }
        return false;
    }
}
