namespace NonOrientedGraphGeneric;

public class Edge<T>
{
    public Node<T> FirstNode { get; set; }
    
    public Node<T> SecondNode { get; set; }
    
    public int Power  { get; set; }

    public Edge(T firstNode, T secondNode)
    {
        FirstNode = new Node<T>(firstNode);
        SecondNode = new Node<T>(secondNode);
    }

    public Edge(Node<T> firstNode, Node<T> secondNode)
    {
        FirstNode = firstNode;
        SecondNode = secondNode;
    }

    public override string ToString()
    {
        return $"{FirstNode} = {SecondNode}";
    }

    public override bool Equals(object? obj)
    {
        if (obj == null) return false;
        if (obj is not Edge<T> edge) return false;
        return FirstNode.Equals(edge.FirstNode) && SecondNode.Equals(edge.SecondNode);
    }

    public static bool operator ==(Edge<T> edge1, Edge<T> edge2)
    {
        return edge1.Equals(edge2);
    }

    public static bool operator !=(Edge<T> edge1, Edge<T> edge2)
    {
        return !(edge1 == edge2);
    }
}