using System.Collections;

namespace NonOrientedGraphGeneric;

public class EdgesBidirectionalEnumerator<T> : IEnumerator<Edge<T>>
{
    public List<Edge<T>> Items { get; set; }

    public EdgesBidirectionalEnumerator(List<Edge<T>> items)
    {
        Items = items;
    }
    
    public Edge<T> Current => Items[_currentIndex];

    private int _currentIndex = -1;

    object? IEnumerator.Current => Current;   
    
    public void Dispose()
    {
    }
    
    public bool MoveNext()
    {
        _currentIndex++;
        return _currentIndex < Items.Count;
    }

    public bool MovePrevious()
    {
        _currentIndex--;
        return _currentIndex >= 0;
    }
    
    public void Reset()
    {
        _currentIndex = -1;
    }
}