using System.Collections;

namespace NonOrientedGraphGeneric;

public class BidirectionalEnumerator<T> : IEnumerator<T>
{
    public List<T> Items { get; set; }

    public BidirectionalEnumerator(List<T> items)
    {
        Items = items;
    }
    
    public T Current => Items[_currentIndex];

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