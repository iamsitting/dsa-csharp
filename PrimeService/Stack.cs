namespace PrimeService;

public interface IStack<T>
{
    int Length { get; }
    void Push(T item);
    T? Pop();
    T? Peek();
}

public class SNode<T>
{
    public T Value { get; set; }
    public SNode<T>? Previous { get; set; }

    public SNode(T item)
    {
        Value = T;
        Previous = default;
    }
}

public class Stack<T> : IStack<T>
{
    public int Length { get; private set; }
    private SNode<T>? Head { get; set; }

    public T? Peek() => Head == null ? default : Head.Value;

    public void Push(T item)
    {
        var node = new SNode<T>(item);
        ++Length;
        if (Head == null)
        {
            Head = node;
            return;
        }

        node.Previous = Head;
        Head = node;
    }

    public T? Pop()
    {
        Length = Length > 0 ? Length - 1 : 0;
        if (Length == 0)
        {
            var temp1 = Head;
            Head = default;
            return temp1 == null ? default : temp1.Value;
        }

        var temp = Head;
        Head = Head.Previous;
        return temp.Value;
    }
}
