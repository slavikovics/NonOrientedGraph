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
        Assert.IsFalse(edge1 == edge2);
    }

    [TestMethod]
    public void GraphNodesOperatorsTest()
    {
        Node<int> node1 = new Node<int>(1);
        Node<int> node2 = new Node<int>(1);
        Assert.AreEqual(node1, node2);
        Assert.IsTrue(node1.Equals(node2));
        Assert.IsFalse(node1 == node2);
    }

    [TestMethod]
    public void CopyConstructorTest()
    {
        Node<int> node1 = new Node<int>(1);
        Node<int> node2 = new Node<int>(2);
        Edge<int> edge1 = new Edge<int>(node1, node2);
        Edge<int> edge2 = edge1;
    }
}