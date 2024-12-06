using NonOrientedGraphGeneric;

namespace NonOrientedGraphTests;

[TestClass]
public sealed class GraphOperatorsTests
{
    [TestMethod]
    public void GraphEdgesOperatorsTest()
    {
        Node<int> node1 = new Node<int>(1);
        Node<int> node2 = new Node<int>(2);
        Edge<int> edge1 = new Edge<int>(node1, node2);
        Edge<int> edge2 = new Edge<int>(node1, node2);
        Assert.AreEqual(edge1, edge2);
        Assert.IsTrue(edge1.Equals(edge2));
        Assert.IsTrue(edge1 == edge2);
        Assert.IsFalse(edge1 != edge2);
    }

    [TestMethod]
    public void GraphNodesOperatorsTest()
    {
        Node<int> node1 = new Node<int>(1);
        Node<int> node2 = new Node<int>(1);
        Assert.AreEqual(node1, node2);
        Assert.IsTrue(node1.Equals(node2));
        Assert.IsTrue(node1 == node2);
        Assert.IsFalse(node1 != node2);
    }

    [TestMethod]
    public void CopyConstructorTest()
    {
        Node<int> node1 = new Node<int>(1);
        Node<int> node2 = new Node<int>(2);
        Edge<int> edge1 = new Edge<int>(node1, node2);
        Edge<int> edge2 = edge1;
    }

    [TestMethod]
    public void IComparableTest()
    {
        NonOrientedGraph<int> graph1 = new NonOrientedGraph<int>();
        graph1.AddEdge(0, 1);
        graph1.AddEdge(0, 2);
        graph1.AddEdge(1, 3);
        
        NonOrientedGraph<int> graph2 = new NonOrientedGraph<int>();
        graph2.AddEdge(0, 1);
        
        Assert.IsTrue(graph1 >= graph2);
        Assert.IsTrue(graph1 > graph2);
        Assert.IsFalse(graph1 <= graph2);
        Assert.IsFalse(graph1 < graph2);
        Assert.IsTrue(graph2 != graph1);
        Assert.IsFalse(graph2 == graph1);
        
        List<NonOrientedGraph<int>> graphs = new List<NonOrientedGraph<int>>();
        graphs.Add(graph1);
        graphs.Add(graph2);
        
        graphs.Sort();
        
        Assert.AreEqual(graph2, graphs[0]);
        Assert.AreEqual(graph1, graphs[1]);
    }
}