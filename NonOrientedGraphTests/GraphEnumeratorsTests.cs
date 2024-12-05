using NonOrientedGraphGeneric;

namespace NonOrientedGraphTests;

[TestClass]
public sealed class GraphEnumeratorsTests
{
    [TestMethod]
    public void EdgesEnumeratorTest()
    {
        NonOrientedGraph<int> graph = new NonOrientedGraph<int>();
        graph.AddEdge(0, 1);
        graph.AddEdge(0, 2);
        graph.AddEdge(1, 3);


        EdgesBidirectionalEnumerator<int> enumerator = graph.GetEdgesEnumerator();
        List<Edge<int>> edges = new List<Edge<int>>();

        foreach (Edge<int> edge in graph)
        {
            enumerator.MoveNext();
            Edge<int> currentEdge = enumerator.Current;
            Assert.AreEqual(edge, currentEdge);
        }
        
        enumerator.Reset();
        while (enumerator.MoveNext())
        {
            Edge<int> currentEdge = enumerator.Current;
            edges.Add(currentEdge);
        }
        
        for (int i = edges.Count - 1; i >= 0; i--)
        {
            enumerator.MovePrevious();
            Assert.AreEqual(edges[i], enumerator.Current);
        }

        for (int i = 0; i < edges.Count; i++)
        {
            Assert.AreEqual(edges[i], graph.Edges[i]);
        }
    }
    
    [TestMethod]
    public void NodesEnumeratorTest()
    {
        NonOrientedGraph<int> graph = new NonOrientedGraph<int>();
        graph.AddEdge(0, 1);
        graph.AddEdge(0, 2);
        graph.AddEdge(1, 3);


        NodesBidirectionalEnumerator<int> enumerator = graph.GetNodesEnumerator();
        List<Node<int>> nodes = new List<Node<int>>();

        while (enumerator.MoveNext())
        {
            Node<int> currentNode = enumerator.Current;
            nodes.Add(currentNode);
        }
        
        for (int i = nodes.Count - 1; i >= 0; i--)
        {
            enumerator.MovePrevious();
            Assert.AreEqual(nodes[i], enumerator.Current);
        }

        for (int i = 0; i < nodes.Count; i++)
        {
            Assert.AreEqual(nodes[i], graph.Nodes[i]);
        }
    }
}