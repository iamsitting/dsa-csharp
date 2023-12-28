namespace PrimeService;

public interface IQueue<T>
{
    int Length { get; }
    void Enqueue(T item);
    T? Deque();
    T? Peek();
}

public class QNode<T>
{
    public T Value { get; set; }
    public QNode<T>? Next { get; set; }

    public QNode(T item)
    {
        Value = item;
        Next = default;
    }
}

public class Queue<T> : IQueue<T>
{
    public int Length { get; private set; }
    private QNode<T>? Head { get; set; }
    private QNode<T>? Tail { get; set; }

    public Queue()
    {
        Length = 0;
    }

    public T? Peek() => Head == null ? default : Head.Value;

    public T? Deque()
    {
        if (Head == null)
        {
            return default;
        }

        --Length;
        var temp = Head;
        Head = Head.Next;
        return temp.Value;
    }

    public void Enqueue(T item)
    {
        ++Length;
        var node = new QNode<T>(item);
        if (Tail == null)
        {
            Tail = node;
            Head = node;
            return;
        }
        Tail.Next = node;
        Tail = node;
    }
}
