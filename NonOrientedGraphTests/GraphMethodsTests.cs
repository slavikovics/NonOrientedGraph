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
}