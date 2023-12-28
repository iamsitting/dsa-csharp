namespace PrimeService;

public interface IQuickSort
{
    void Sort(ref int[] array);
}

public class QuickSort : IQuickSort
{
    private void _sort(ref int[] array, int low, int high)
    {
        if (low >= high)
        {
            return;
        }

        var pivotIndex = _partition(ref array, low, high);

        _sort(ref array, low, pivotIndex - 1);
        _sort(ref array, pivotIndex + 1, high);
    }

    private static int _partition(ref int[] array, int low, int high)
    {
        var pivot = array[high];

        var index = low - 1;

        for (var i = low; i < high; ++i)
        {
            if (array[i] <= pivot)
            {
                index++;
                var temp = array[i];
                array[i] = array[index];
                array[index] = temp;
            }
        }

        index++;
        array[high] = array[index];
        array[index] = pivot;

        return index;
    }

    public void Sort(ref int[] array)
    {
        _sort(ref array, 0, array.Length - 1);
    }
}
