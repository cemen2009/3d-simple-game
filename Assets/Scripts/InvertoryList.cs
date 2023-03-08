using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvertoryList<T> where T : class
{
    private T _item;
    public T item
    {
        get { return _item; }
    }
    public InvertoryList()
    {
        Debug.Log("Generic list initialized...");
    }

    public void SetItem(T newItem)
    {
        _item = newItem;
        Debug.Log("New item added...");
    }
}
