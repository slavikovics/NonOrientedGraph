namespace NonOrientedGraphGeneric;

public class NonOrientedGraph<T> where T : IEquatable<T>, IComparable<T>
{
    private List<Node<T>> _nodes;
    
    private List<Edge<T>> _edges;

    public NonOrientedGraph()
    {
        _nodes = new List<Node<T>>();
        _edges = new List<Edge<T>>();
    }

    public bool HasNode(T node)
    {
        foreach (Node<T> n in _nodes)
        {
            if (n.Value.Equals(node)) return true;
        }
        
        return false;
    }

    private Node<T> FindNode(T node)
    {
        foreach (Node<T> n in _nodes)
        {
            if (n.Value.Equals(node)) return n;
        }
        
        throw  new ArgumentException("Node not found");
    }

    public bool HasEdge(T firstNode, T secondNode)
    {
        foreach (Edge<T> edge in _edges)
        {
            if (edge.FirstNode.Value.Equals(firstNode) && edge.SecondNode.Value.Equals(secondNode) ||
                edge.SecondNode.Value.Equals(firstNode) && edge.FirstNode.Value.Equals(secondNode)) return true;    
        }

        return false;
    }

    public int GetNodesCount()
    {
        return _nodes.Count;
    }

    private int CalculateNodePower(Node<T> node)
    {
        foreach (Edge<T> edge in _edges)
        {
            if (edge.FirstNode == node || edge.SecondNode == node)
            {
                node.Power++;
            }
        }

        return node.Power;
    }

    /// <summary>
    /// Finds node by value, calculates it's power and returns power.
    /// </summary>
    /// <param name="node"></param>
    /// <returns>Node's power</returns>
    /// <exception cref="ArgumentException"></exception>
    public int GetNodePower(T node)
    {
        if (!HasNode(node)) throw new ArgumentException("Node is not present in graph");
        return CalculateNodePower(FindNode(node));
    }

    /// <summary>
    /// Adds new node to the graph.
    /// </summary>
    /// <param name="node"></param>
    /// <returns>
    /// True if node was added
    /// False if node can not be added
    /// </returns>
    public bool AddNode(T node)
    {
        if (HasNode(node)) return false;

        Node<T> newNode = new Node<T>(node);
        _nodes.Add(newNode);
        return true;
    }

    /// <summary>
    /// Adds new nodes or node if they do not exist.
    /// </summary>
    /// <param name="firstNode"></param>
    /// <param name="secondNode"></param>
    /// <returns>
    /// True if edge was created.
    /// False if edge can not be created.
    /// </returns>
    public bool AddEdge(T firstNode, T secondNode)
    {
        Node<T> edgeNodeFirst;
        Node<T> edgeNodeSecond;
        
        
    }
}