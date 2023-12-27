using Dumpify;

namespace PrimeService;

public interface IBubbleSort
{
    int[] Sort(int[] array);
}

public class BubbleSort : IBubbleSort
{
    public int[] Sort(int[] array)
    {
        for (var i = 0; i < array.Length; i++)
        {
            for (var j = 0; j < array.Length - 1 - i; j++)
            {
                if (array[j] > array[j + 1])
                {
                    var temp = array[j];
                    array[j] = array[j + 1];
                    array[j + 1] = temp;
                }
                Console.WriteLine(string.Join(",", array));
            }
        }
        return array;
    }
}
