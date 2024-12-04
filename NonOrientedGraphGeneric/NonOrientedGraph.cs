using System.Collections;

namespace NonOrientedGraphGeneric;

public class NonOrientedGraph<T> : IEnumerable<T> where T : IEquatable<T>, IComparable<T>
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

    public Edge<T> FindEdge(T firstNode, T secondNode)
    {
        foreach (Edge<T> edge in _edges)
        {
            if (edge.FirstNode.Value.Equals(firstNode) && edge.SecondNode.Value.Equals(secondNode) ||
                edge.SecondNode.Value.Equals(firstNode) && edge.FirstNode.Value.Equals(secondNode)) return edge;
        }
        
        throw new ArgumentException("Edge not found");
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
    
    public int GetNodePower(T node)
    {
        if (!HasNode(node)) throw new ArgumentException("Node is not present in graph");
        return CalculateNodePower(FindNode(node));
    }

    private int CalculateEdgePower(Edge<T> edge)
    {
        edge.Power = CalculateNodePower(edge.FirstNode) + CalculateNodePower(edge.SecondNode);
        return edge.Power;
    }

    public int GetEdgePower(T firstNode, T secondNode)
    {
        if (!HasEdge(firstNode, secondNode)) return -1;
        return CalculateEdgePower(FindEdge(firstNode, secondNode));
    }
    
    public bool AddNode(T node)
    {
        if (HasNode(node)) return false;

        Node<T> newNode = new Node<T>(node);
        _nodes.Add(newNode);
        return true;
    }
    
    public bool AddEdge(T firstNode, T secondNode)
    {
        Node<T> edgeNodeFirst;
        Node<T> edgeNodeSecond;

        if (HasNode(firstNode)) edgeNodeFirst = FindNode(firstNode);
        else edgeNodeFirst = new Node<T>(firstNode);
        
        if (HasNode(secondNode)) edgeNodeSecond = FindNode(secondNode);
        else edgeNodeSecond = new Node<T>(secondNode);
        
        if (HasEdge(firstNode, secondNode)) return false;
        
        _edges.Add(new Edge<T>(edgeNodeFirst, edgeNodeSecond));
        return true;
    }

    public void RemoveEdge(T firstNode, T secondNode)
    {
        if (!HasEdge(firstNode, secondNode)) return;
        _edges.Remove(FindEdge(firstNode, secondNode));
    }

    public void RemoveEdgesForNode(T node)
    {
        for (int i = 0; i < _edges.Count; i++)
        {
            if (_edges[i].FirstNode.Value.Equals(node) || _edges[i].SecondNode.Value.Equals(node))
            {
                _edges.RemoveAt(i);
                i--;
            }
        }
    }

    public void RemoveNode(T node)
    {
        RemoveNode(node);
        RemoveEdgesForNode(node);
    }

    public IEnumerator<T> GetEnumerator()
    {
        return new BidirectionalEnumerator(_edges);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}