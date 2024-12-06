using System.Collections;

namespace NonOrientedGraphGeneric;

public class NonOrientedGraph<T> : IComparable<NonOrientedGraph<T>> where T : IEquatable<T>, IComparable<T>
{
    public List<Node<T>> Nodes { get; set; }

    public List<Edge<T>> Edges { get; set; }

    public NonOrientedGraph()
    {
        Nodes = new List<Node<T>>();
        Edges = new List<Edge<T>>();
    }

    public NonOrientedGraph(NonOrientedGraph<T> graph)
    {
        Nodes = graph.Nodes;
        Edges = graph.Edges;
    }

    public bool HasNode(T node)
    {
        foreach (Node<T> n in Nodes)
        {
            if (n.Value.Equals(node)) return true;
        }
        
        return false;
    }

    public Node<T> FindNode(T node)
    {
        foreach (Node<T> n in Nodes)
        {
            if (n.Value.Equals(node)) return n;
        }
        
        throw  new ArgumentException("Node not found");
    }

    public bool HasEdge(T firstNode, T secondNode)
    {
        foreach (Edge<T> edge in Edges)
        {
            if (edge.FirstNode.Value.Equals(firstNode) && edge.SecondNode.Value.Equals(secondNode) ||
                edge.SecondNode.Value.Equals(firstNode) && edge.FirstNode.Value.Equals(secondNode)) return true;    
        }

        return false;
    }

    public Edge<T> FindEdge(T firstNode, T secondNode)
    {
        foreach (Edge<T> edge in Edges)
        {
            if (edge.FirstNode.Value.Equals(firstNode) && edge.SecondNode.Value.Equals(secondNode) ||
                edge.SecondNode.Value.Equals(firstNode) && edge.FirstNode.Value.Equals(secondNode)) return edge;
        }
        
        throw new ArgumentException("Edge not found");
    }

    public int GetNodesCount()
    {
        return Nodes.Count;
    }

    private int CalculateNodePower(Node<T> node)
    {
        node.Power = 0;
        
        foreach (Edge<T> edge in Edges)
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
        edge.Power = 0;
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
        Nodes.Add(newNode);
        return true;
    }
    
    public bool AddEdge(T firstNode, T secondNode)
    {
        Node<T> edgeNodeFirst;
        Node<T> edgeNodeSecond;

        if (HasNode(firstNode)) edgeNodeFirst = FindNode(firstNode);
        else
        {
            edgeNodeFirst = new Node<T>(firstNode);
            Nodes.Add(edgeNodeFirst);
        }
        
        if (HasNode(secondNode)) edgeNodeSecond = FindNode(secondNode);
        else
        {
            edgeNodeSecond = new Node<T>(secondNode);
            Nodes.Add(edgeNodeSecond);
        }
        
        if (HasEdge(firstNode, secondNode)) return false;
        
        Edges.Add(new Edge<T>(edgeNodeFirst, edgeNodeSecond));
        
        return true;
    }

    public void RemoveEdge(T firstNode, T secondNode)
    {
        if (!HasEdge(firstNode, secondNode)) return;
        Edges.Remove(FindEdge(firstNode, secondNode));
    }

    public void RemoveEdgesForNode(T node)
    {
        for (int i = 0; i < Edges.Count; i++)
        {
            if (Edges[i].FirstNode.Value.Equals(node) || Edges[i].SecondNode.Value.Equals(node))
            {
                Edges.RemoveAt(i);
                i--;
            }
        }
    }

    public void RemoveNode(T node)
    {
        Nodes.Remove(FindNode(node));
        RemoveEdgesForNode(node);
    }

    public bool IsEmpty()
    {
        return Nodes.Count == 0;
    }

    public void Clear()
    {
        Nodes.Clear();
        Edges.Clear();
    }

    public List<Node<T>> FindAdjacentNodes(T nodeValue)
    {
        Node<T> node = FindNode(nodeValue);
        List<Node<T>> adjacentNodes = new List<Node<T>>();
        
        foreach (Edge<T> edge in Edges)
        {
            if (edge.FirstNode.Value.Equals(node.Value)) adjacentNodes.Add(edge.SecondNode);
            else if (edge.SecondNode.Value.Equals(node.Value)) adjacentNodes.Add(edge.FirstNode);
        }
        
        return adjacentNodes;
    }

    public List<Edge<T>> FindIncidentEdges(T nodeValue)
    {
        Node<T> node = FindNode(nodeValue);
        List<Edge<T>> incidentEdges = new List<Edge<T>>();

        foreach (Edge<T> edge in Edges)
        {
            if (edge.FirstNode.Value.Equals(node.Value)) incidentEdges.Add(edge);
            else if (edge.SecondNode.Value.Equals(node.Value)) incidentEdges.Add(edge);
        }
        
        return incidentEdges;
    }

    public IEnumerator<Edge<T>> GetEnumerator()
    {
        return new EdgesBidirectionalEnumerator<T>(Edges);
    }

    public EdgesBidirectionalEnumerator<T> GetEdgesEnumerator()
    {
        return new EdgesBidirectionalEnumerator<T>(Edges);
    }

    public NodesBidirectionalEnumerator<T> GetNodesEnumerator()
    {
        return new NodesBidirectionalEnumerator<T>(Nodes);
    }

    public NodesBidirectionalEnumerator<T> GetAdjacentNodesEnumerator(T node)
    {
        List<Node<T>> nodes = FindAdjacentNodes(node);
        return new NodesBidirectionalEnumerator<T>(nodes);
    }

    public EdgesBidirectionalEnumerator<T> GetIncidentEdgesEnumerator(T node)
    {
        List<Edge<T>> incidentEdges = FindIncidentEdges(node);
        return new EdgesBidirectionalEnumerator<T>(incidentEdges);
    }

    public static bool operator ==(NonOrientedGraph<T> firstGraph, NonOrientedGraph<T> secondGraph)
    {
        if (firstGraph.Nodes.SequenceEqual(secondGraph.Nodes) && firstGraph.Edges.SequenceEqual(secondGraph.Edges)) return true;
        return false;
    }

    public static bool operator !=(NonOrientedGraph<T> firstGraph, NonOrientedGraph<T> secondGraph)
    {
        return !(firstGraph == secondGraph);
    }

    public static bool operator <(NonOrientedGraph<T> firstGraph, NonOrientedGraph<T> secondGraph)
    {
        return firstGraph.GetNodesCount() < secondGraph.GetNodesCount();
    }
    
    public static bool operator >(NonOrientedGraph<T> firstGraph, NonOrientedGraph<T> secondGraph)
    {
        return !(firstGraph < secondGraph);
    }

    public static bool operator <=(NonOrientedGraph<T> firstGraph, NonOrientedGraph<T> secondGraph)
    {
        return firstGraph.GetNodesCount() <= secondGraph.GetNodesCount();
    }

    public static bool operator >=(NonOrientedGraph<T> firstGraph, NonOrientedGraph<T> secondGraph)
    {
        return firstGraph.GetNodesCount() >= secondGraph.GetNodesCount();
    }

    public int CompareTo(NonOrientedGraph<T>? other)
    {
        if (Nodes.Count > other.Nodes.Count) return 1;
        if (Nodes.Count < other.Nodes.Count) return -1;
        return 0;
    }

    public override string ToString()
    {
        string result = "";
        foreach (Edge<T> edge in Edges)
        {
            result += edge.ToString() + ", ";
        }

        return result;
    }
}