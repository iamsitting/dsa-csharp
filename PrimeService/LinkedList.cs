namespace PrimeService;

public interface ILinkedList<T>
{
    int Length { get; }
    void InsertAt(T item, int index);
    T? Remove(T item);
    T? RemoveAt(int index);
    void Append(T item);
    void Prepend(T item);
    T? GetItem(int index);
}

public class Node<T>
{
    public T? Value { get; set; }
    public Node<T>? Next { get; set; }
    public Node<T>? Previous { get; set; }

    public Node(T value)
    {
        Value = value;
        Next = null;
        Previous = null;
    }
}

public class LinkedList<T> : ILinkedList<T>
{
    public int Length { get; private set; }
    private Node<T>? Head { get; set; }
    private Node<T>? Tail { get; set; }

    public LinkedList()
    {
        Length = 0;
        Head = default;
        Tail = default;
    }

    public void Append(T item)
    {
        var node = new Node<T>(item);
        if (Length == 0)
        {
            Tail = node;
            Head = Tail;
        }
        else
        {
            Tail!.Next = node;
            node.Previous = Tail;
            Tail = node;
        }
        ++Length;
    }

    public void Prepend(T item)
    {
        var node = new Node<T>(item);
        if (Length == 0)
        {
            Head = node;
            Tail = Head;
        }
        else
        {
            Head!.Previous = node;
            node.Next = Head;
            Head = node;
        }
        ++Length;
    }

    public T? GetItem(int index)
    {
        if (Head == null)
            return default;
        if (index >= Length)
            return default;

        var node = Head;
        if (Length == 1)
        {
            return node.Value;
        }

        for (var i = 0; i < index; i++)
        {
            if (node.Next == null)
                return default;

            node = node.Next;
        }
        return node.Value;
    }

    public T? Remove(T item)
    {
        if (Head == null)
            return default;

        var node = Head;

        if (Length == 1)
        {
            if (node.Value!.Equals(item))
            {
                Head = null;
                Tail = null;
                Length = 0;
                return node.Value;
            }
        }

        for (var i = 0; i < Length; i++)
        {
            if (node.Next == null)
            {
                // TODO: handle tail condition
            }

            if (node.Previous == null)
            {
                // TODO: handle head condition
            }

            if (node.Next!.Equals(item))
            {
                var toRemove = node.Next;
                node.Next = toRemove.Next;
                node.Next!.Previous = node;
                --Length;
                return toRemove.Value;
            }
            node = node.Next;
        }

        return default;
    }

    public T? RemoveAt(int index)
    {
        if (index >= Length)
        {
            return default;
        }

        if (Head == null)
        {
            return default;
        }

        var node = Head;

        if (Length == 1)
        {
            Head = null;
            Tail = null;
            Length = 0;
            return node.Value;
        }

        for (var i = 0; i < index; i++)
        {
            node = node.Next;
        }
        if (node.Next == null)
        {
            // TODO: handle Tail condition
        }
        if (node.Previous == null)
        {
            // TODO: handle head condition
        }
        var temp = node;
        node.Next = node.Next.Next;
        node.Next.Previous = node;
        return temp.Value;
    }

    public void InsertAt(T item, int index)
    {
        if (index > Length)
        {
            throw new IndexOutOfRangeException();
        }

        if (index == 0)
        {
            Prepend(item);
            return;
        }

        if (index == Length - 1)
        {
            Append(item);
            return;
        }

        var node = Head;

        for (var i = 1; i < index; i++)
        {
            if (node.Next == null)
            {
                // TODO: handle tail condition
            }

            if (node.Previous == null)
            {
                // TOOD: hanlde head condition
            }

            node = node.Next;
        }

        var temp = node;
        // TODO: work in progress
        return;
    }
}
