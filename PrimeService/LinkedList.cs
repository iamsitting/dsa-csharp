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
        var current = Tail;
        for (var i = 0; i < Length; ++i)
        {
            if (current.Value.Equals(item))
            {
                break;
            }
            current = current.Next;
        }
        if (current == null)
        {
            return default;
        }

        --Length;

        if (Length == 0)
        {
            Head = default;
            Tail = default;
            return default;
        }

        if (current.Previous != null)
        {
            current.Previous = current.Next;
        }

        if (current.Next != null)
        {
            current.Next = current.Previous;
        }

        if (current == Head)
        {
            Head = current.Next;
        }
        if (current == Tail)
        {
            Tail = current.Previous;
        }

        current.Previous = default;
        current.Next = default;
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
            throw new Exception("Bad data structure");
        }

        if (index == 0)
        {
            ++Length;
            Prepend(item);
            return;
        }

        if (index == Length - 1)
        {
            ++Length;
            Append(item);
            return;
        }

        var currentNode = Head;

        for (var i = 1; i < index; i++)
        {
            currentNode = currentNode.Next;
        }

        var newNode = new Node<T>(item);
        newNode.Next = currentNode;
        newNode.Previous = currentNode.Previous;
        currentNode.Previous = currentNode;

        if (newNode.Previous != null)
        {
            currentNode.Previous.Next = currentNode;
        }
        ++Length;

        return;
    }
}
