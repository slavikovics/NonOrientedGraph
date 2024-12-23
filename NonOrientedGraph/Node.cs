namespace NonOrientedGraphGeneric;

public class Node<T>
{
    public T Value { get; set; }
    
    public int Power  { get; set; }

    public Node(T value)
    {
        Value = value;
    }
    
    public override bool Equals(object? obj)
    {
        if (obj == null) return false;
        if (obj is not Node<T> node) return false;
        return node.Value.Equals(Value);
    }

    public static bool operator ==(Node<T> a, Node<T> b)
    {
        return a.Equals(b);
    }

    public static bool operator !=(Node<T> a, Node<T> b)
    {
        return !(a == b);
    }
}