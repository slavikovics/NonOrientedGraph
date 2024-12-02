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
}