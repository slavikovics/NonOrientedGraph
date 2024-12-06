using NonOrientedGraphGeneric;

namespace NonOrientedGraphTests;

[TestClass]
public sealed class GraphMethodsTests
{
    [TestMethod]
    public void CopyConstructorTest()
    {
        NonOrientedGraph<int> graph = new NonOrientedGraph<int>();
        graph.AddEdge(0, 1);
        graph.AddEdge(0, 2);
        graph.AddEdge(1, 3);
        
        NonOrientedGraph<int> newGraph = new NonOrientedGraph<int>(graph);
        Assert.IsTrue(graph == newGraph);
    }

    [TestMethod]
    public void HasNodeTest()
    {
        NonOrientedGraph<int> graph = new NonOrientedGraph<int>();
        graph.AddEdge(0, 1);
        graph.AddEdge(0, 2);
        graph.AddEdge(1, 3);
        
        Assert.IsTrue(graph.HasNode(0));
        Assert.IsTrue(graph.HasNode(1));
        Assert.IsTrue(graph.HasNode(2));
        Assert.IsTrue(graph.HasNode(3));
        Assert.IsFalse(graph.HasNode(4));
    }

    [TestMethod]
    public void HasEdgeTest()
    {
        NonOrientedGraph<int> graph = new NonOrientedGraph<int>();
        Node<int> node1 = new Node<int>(1);
        Node<int> node2 = new Node<int>(2);
        graph.AddNode(1);
        graph.AddNode(2);
        graph.AddNode(2);
        
        graph.AddEdge(0, 1);
        graph.AddEdge(0, 2);
        graph.AddEdge(0, 2);
        graph.AddEdge(1, 3);
        
        Assert.IsFalse(graph.HasEdge(0, 0));
        Assert.IsTrue(graph.HasEdge(0, 1));
        Assert.IsTrue(graph.HasEdge(0, 2));
        Assert.IsTrue(graph.HasEdge(1, 3));
        Assert.IsFalse(graph.HasEdge(1, 4));
    }

    [TestMethod]
    public void FindNodeTest()
    {
        NonOrientedGraph<int> graph = new NonOrientedGraph<int>();
        
        graph.AddEdge(0, 1);
        graph.AddEdge(0, 2);
        graph.AddEdge(1, 3);

        Assert.AreEqual(graph.FindNode(0).Value, 0);
        Assert.AreEqual(graph.FindNode(1).Value, 1);

        try
        {
            Assert.AreEqual(graph.FindNode(5).Value, 5);
        }
        catch (ArgumentException e)
        {
            Assert.AreEqual(e.Message, "Node not found");
        }
    }
    
    [TestMethod]
    public void FindEdgeTest()
    {
        NonOrientedGraph<int> graph = new NonOrientedGraph<int>();
        
        graph.AddEdge(0, 1);
        graph.AddEdge(2, 0);
        graph.AddEdge(1, 3);

        Assert.IsTrue(graph.FindEdge(0, 1) == new Edge<int>(0, 1));
        Assert.IsTrue(graph.FindEdge(0, 2) == new Edge<int>(0, 2));

        try
        {
            Assert.AreEqual(graph.FindEdge(0, 4), new Edge<int>(0, 4));
        }
        catch (ArgumentException e)
        {
            Assert.AreEqual(e.Message, "Edge not found");
        }
    }

    [TestMethod]
    public void GetNodesCountTest()
    {
        NonOrientedGraph<int> graph = new NonOrientedGraph<int>();
        
        graph.AddEdge(0, 1);
        graph.AddEdge(2, 0);
        graph.AddEdge(1, 3);
        
        Assert.AreEqual(graph.GetNodesCount(), 4);
    }

    [TestMethod]
    public void GetNodePowerTest()
    {
        NonOrientedGraph<int> graph = new NonOrientedGraph<int>();
        
        graph.AddEdge(0, 1);
        graph.AddEdge(2, 0);
        graph.AddEdge(1, 3);
        
        Assert.AreEqual(graph.GetNodePower(0), 2);
        Assert.AreEqual(graph.GetNodePower(2), 1);
        Assert.AreEqual(graph.GetNodePower(3), 1);
        
        try
        {
            Assert.AreEqual(graph.GetNodePower(4), 1);
        }
        catch (ArgumentException e)
        {
            Assert.AreEqual(e.Message, "Node is not present in graph");
        }
    }

    [TestMethod]
    public void GetEdgePowerTest()
    {
        NonOrientedGraph<int> graph = new NonOrientedGraph<int>();
        
        graph.AddEdge(0, 1);
        graph.AddEdge(2, 0);
        graph.AddEdge(1, 3);
        
        Assert.AreEqual(graph.GetEdgePower(0, 1), graph.GetNodePower(0) + graph.GetNodePower(1));
        Assert.AreEqual(graph.GetEdgePower(2, 0), graph.GetNodePower(2) + graph.GetNodePower(0));
        
        try
        {
            Assert.AreEqual(graph.GetEdgePower(4, 0), -1);
        }
        catch (ArgumentException e)
        {
            Assert.AreEqual(e.Message, "Node is not present in graph");
        }
    }

    [TestMethod]
    public void RemoveEdgeTest()
    {
        NonOrientedGraph<int> graph = new NonOrientedGraph<int>();
        
        graph.AddEdge(0, 1);
        graph.AddEdge(2, 0);
        graph.AddEdge(1, 3);
        
        graph.RemoveEdge(0, 1);
        graph.RemoveEdge(0, 2);
        graph.RemoveEdge(0, 4);
        
        Assert.IsFalse(graph.HasEdge(0, 1));
        Assert.IsFalse(graph.HasEdge(0, 2));
        
    }

    [TestMethod]
    public void RemoveNodeTest()
    {
        NonOrientedGraph<int> graph = new NonOrientedGraph<int>();
        
        graph.AddEdge(0, 1);
        graph.AddEdge(2, 0);
        graph.AddEdge(1, 3);
        
        graph.RemoveNode(1);
        Assert.IsFalse(graph.HasNode(1));
        Assert.IsFalse(graph.HasEdge(0, 1));
        Assert.IsFalse(graph.HasEdge(1, 3));
    }

    [TestMethod]
    public void GraphEmptyTest()
    {
        NonOrientedGraph<int> graph = new NonOrientedGraph<int>();
        
        graph.AddEdge(0, 1);
        graph.AddEdge(2, 0);
        graph.AddEdge(1, 3);
        
        Assert.IsFalse(graph.IsEmpty());
        
        graph.Clear();

        Assert.IsTrue(graph.IsEmpty());
    }

    [TestMethod]
    public void FindAdjacentNodesTest()
    {
        NonOrientedGraph<int> graph = new NonOrientedGraph<int>();
        
        graph.AddEdge(0, 1);
        graph.AddEdge(2, 0);
        graph.AddEdge(1, 3);

        List<Node<int>> nodes = graph.FindAdjacentNodes(0);
        Assert.AreEqual(nodes.Count, 2);
        Assert.IsTrue(nodes.Contains(n => n.Value == 1));
    }
}