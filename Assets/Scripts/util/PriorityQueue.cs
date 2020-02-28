using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// Min Priority Queue implementation.
/// </summary>
public class PriorityQueue<T>
{
    // TODO: better priority queue implementation
    private readonly SortedSet<T> elements;
    private readonly AllowDuplicatesComparer comparer;

    public PriorityQueue()
    {
        this.comparer = new AllowDuplicatesComparer();
        this.elements = new SortedSet<T>(comparer);
    }

    public PriorityQueue(IEnumerable<T> elements)
    {
        this.comparer = new AllowDuplicatesComparer();
        this.elements = new SortedSet<T>(elements, comparer);
    }

    public PriorityQueue(IComparer<T> comparer)
    {
        this.comparer = new AllowDuplicatesComparer(comparer);
        this.elements = new SortedSet<T>(this.comparer);
    }

    public PriorityQueue(IEnumerable<T> elements, IComparer<T> comparer)
    {
        this.comparer = new AllowDuplicatesComparer(comparer);
        this.elements = new SortedSet<T>(elements, this.comparer);
    }

    public int Count
    {
        get { return elements.Count; }
    }

    public void Offer(T element)
    {
        elements.Add(element);
    }

    public T Peek()
    {
        return elements.Min;
    }

    public T Poll()
    {
        T segment = elements.Min;
        comparer.allowDuplicates = false;
        elements.Remove(segment);
        comparer.allowDuplicates = true;
        return segment;
    }

    #region Comparer

    private class AllowDuplicatesComparer : IComparer<T>
    {
        private readonly IComparer<T> comparer;
        public bool allowDuplicates = true;

        public AllowDuplicatesComparer(IComparer<T> comparer = null)
        {
            this.comparer = comparer != null ? comparer : Comparer<T>.Default;
        }

        public int Compare(T x, T y)
        {
            int cmp = comparer.Compare(x, y);
            if (cmp == 0 && allowDuplicates)
            {
                return 1;
            }

            return cmp;
        }
    }

    #endregion
}
