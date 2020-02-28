using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlaneSweep
{
    public readonly IEnumerable<Intersection> intersections;

    public PlaneSweep(IEnumerable<Segment> segments)
    {
        var eventQueue = new EventQueue(segments);
        intersections = GetIntersections(eventQueue);
    }

    private static IEnumerable<Intersection> GetIntersections(IEventQueue eventQueue)
    {
        var status = new Status();

        List<Intersection> intersections = new List<Intersection>();
        while (eventQueue.Count > 0)
        {
            var eventPoint = eventQueue.Pop();
            switch (eventPoint.type)
            {
                case EventPoint.EP_START:
                    break;
                case EventPoint.EP_INTERSECT:
                    break;
                case EventPoint.EP_END:
                    break;
                default:
                    throw new Exception("Unexpected event point type: " + eventPoint.type);
            }
        }
        return intersections;
    }
}

/// <summary>
/// Undirected line segment
/// </summary>
public class Segment
{
    public Vector3 a;
    public Vector3 b;

    public Segment(Vector3 a, Vector3 b)
    {
        this.a = a;
        this.b = b;
    }

    public float minX
    {
        get { return Mathf.Min(a.x, b.x); }
    }

    public float maxX
    {
        get { return Mathf.Max(a.x, b.x); }
    }

    public float minY
    {
        get { return Mathf.Min(a.y, b.y); }
    }

    public float maxY
    {
        get { return Mathf.Max(a.y, b.y); }
    }
}

public class Intersection
{
    public readonly Vector3 coordinates;
    public readonly IEnumerable<Segment> segments;

    public Intersection(Vector3 coordinates, IEnumerable<Segment> segments)
    {
        this.coordinates = coordinates;
        this.segments = new List<Segment>(segments);
    }
}

struct EventPoint
{
    public const int EP_START = 0;
    public const int EP_INTERSECT = 1;
    public const int EP_END = 2;

    public readonly int type;
    public readonly Segment segment;

    private EventPoint(int type, Segment segment)
    {
        this.type = type;
        this.segment = segment;
    }

    public static EventPoint Start(Segment segment)
    {
        return new EventPoint(EP_START, segment);
    }

    public static EventPoint Intersect(Segment segment)
    {
        return new EventPoint(EP_INTERSECT, segment);
    }

    public static EventPoint End(Segment segment)
    {
        return new EventPoint(EP_END, segment);
    }
}

interface IEventQueue
{
    void Push(EventPoint point);
    EventPoint Pop();
    int Count { get; }    
}

class EventQueue : IEventQueue
{
    private static readonly IComparer<EventPoint> comparer = Comparer<EventPoint>.Create((p1, p2) =>
    {
        var s1 = p1.segment;
        var s2 = p2.segment;

        // asc by x-coordinate
        var cmp = s1.minX.CompareTo(s2.minX);
        if (cmp != 0)
        {
            return cmp;
        }

        // asc by y-coordinate
        return s1.minY.CompareTo(s2.minY);
    });

    private readonly SortedSet<EventPoint> queue;

    public EventQueue(IEnumerable<Segment> segments)
    {
        var points = CreateEventPoints(segments);
        queue = new SortedSet<EventPoint>(points, comparer);
    }

    public void Push(EventPoint point)
    {
        queue.Add(point);
    }

    public EventPoint Pop()
    {
        var point = queue.Min;
        queue.Remove(point);
        return point;
    }

    public int Count { get { return queue.Count; } }

    private IEnumerable<EventPoint> CreateEventPoints(IEnumerable<Segment> segments)
    {
        List<EventPoint> points = new List<EventPoint>();
        foreach (var s in segments)
        {
            points.Add(EventPoint.Start(s));
            points.Add(EventPoint.End(s));
        }

        return points;
    }
}

/// <summary>
/// Ordered sequence (from bottom to top) of segments intersecting the sweep line.
/// </summary>

interface IStatus
{

}

class Status : IStatus
{

}