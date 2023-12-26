namespace PrimeService;

public interface IBinarySearchArray
{
    public bool Search(int[] array, int val, int min, int max);
}

public class BinarySearchArray : IBinarySearchArray
{
    public bool Search(int[] array, int val, int min, int max)
    {

        while (min < max)
        {
            int midIndex = min + (max - min) / 2;
            int midpoint = array[midIndex];

            if(val == midpoint)
            {
                return true;
            }
            else if(val > midpoint)
            {
                min = midIndex + 1;
            }
            else
            {
                max = midIndex;
            }
        }
        return false;
    }
}
