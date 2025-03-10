using System;
using System.Collections.Generic;

public class MyList<T>
{
    private List<T> items = new List<T>();

    public void Add(T element) => items.Add(element);

    public T Remove(int index)
    {
        if (index < 0 || index >= items.Count)
            throw new ArgumentOutOfRangeException("Invalid index.");

        T removedElement = items[index];
        items.RemoveAt(index);
        return removedElement;
    }

    public bool Contains(T element) => items.Contains(element);

    public void Clear() => items.Clear();

    public void InsertAt(T element, int index)
    {
        if (index < 0 || index > items.Count)
            throw new ArgumentOutOfRangeException("Invalid index.");

        items.Insert(index, element);
    }

    public void DeleteAt(int index)
    {
        if (index < 0 || index >= items.Count)
            throw new ArgumentOutOfRangeException("Invalid index.");

        items.RemoveAt(index);
    }

    public T Find(int index)
    {
        if (index < 0 || index >= items.Count)
            throw new ArgumentOutOfRangeException("Invalid index.");

        return items[index];
    }
}
