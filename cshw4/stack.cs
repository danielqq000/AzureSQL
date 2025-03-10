using System;
using System.Collections.Generic;

public class MyStack<T>
{
    private List<T> stack = new List<T>();

    public int Count() => stack.Count;

    public void Push(T item) => stack.Add(item);

    public T Pop()
    {
        if (stack.Count == 0)
            throw new InvalidOperationException("Stack is empty.");
        
        T item = stack[_stack.Count - 1];
        stack.RemoveAt(_stack.Count - 1);
        return item;
    }
}

