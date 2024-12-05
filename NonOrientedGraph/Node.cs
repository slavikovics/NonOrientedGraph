namespace NonOrientedGraphGeneric;

public class Node<T>
{
    public T Value { get; set; }
    
    public int Power  { get; set; }

    public Node(T value)
    {
        Value = value;
    }
}