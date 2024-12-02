namespace NonOrientedGraphGeneric;

public class Edge<T>
{
    public Node<T> FirstNode { get; set; }
    
    public Node<T> SecondNode { get; set; }

    public Edge(T firstNode, T secondNode)
    {
        FirstNode = new Node<T>(firstNode);
        SecondNode = new Node<T>(secondNode);
    }
}