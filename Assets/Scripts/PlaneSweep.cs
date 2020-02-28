using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlaneSweep
{
    private static readonly IComparer<Segment> comparer = Comparer<Segment>.Create((s1, s2) => {
        var p1 = s1.upperEndpoint;
        var p2 = s2.upperEndpoint;
        int cmp = p2.y.CompareTo(p2.y);
        if (cmp != 0)
        {
            return cmp;
        }

        return p1.x.CompareTo(p2.x);
    });

    public readonly IEnumerable<Intersection> intersections;

    public PlaneSweep(IEnumerable<Segment> segments)
    {
        var eventPoints = new List<EventPoint>();
        foreach (var s in segments)
        {
            eventPoints.Add(EventPoint.Start(s));
            eventPoints.Add(EventPoint.End(s));
        }
        PriorityQueue<EventPoint> eventQueue = new PriorityQueue<EventPoint>(eventPoints);
        intersections = GetIntersections(eventQueue);
    }

    private static IEnumerable<Intersection> GetIntersections(PriorityQueue<EventPoint> eventQueue)
    {
        var status = new Status();

        List<Intersection> intersections = new List<Intersection>();
        while (eventQueue.Count > 0)
        {
            var eventPoint = eventQueue.Poll();
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

    public Vector3 upperEndpoint
    {
        get { return a.y > b.y ? a : b; }
    }

    public Vector3 lowerEndpoint
    {
        get { return a.y < b.y ? a : b; }
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

/// <summary>
/// Ordered sequence (from left to right) of segments intersecting the sweep line.
/// </summary>
class Status
{
    private readonly SortedSet<Segment> segments = new SortedSet<Segment>();
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

class EventQueue
{
    /// <summary>
    /// IComparer implementation for the priority queue.
    /// Segments are sorted ascendingly by y-coordinate and descendingly by x-coordinate.
    /// </summary>
    private static readonly IComparer<Segment> comparer = Comparer<Segment>.Create((s1, s2) =>
    {
        Vector3 p1 = s1.upperEndpoint;
        Vector3 p2 = s2.upperEndpoint;

        // desc by y-coordinate
        int cmp = p2.y.CompareTo(p1.y);
        if (cmp != 0)
        {
            return cmp;
        }

        // asc by x-coordinate
        return p1.x.CompareTo(p2.x);
    });

    private readonly SortedSet<Segment> queue;

    public EventQueue(IEnumerable<Segment> segments)
    {
        queue = new SortedSet<Segment>(segments, comparer);
    }

    public bool HasNext()
    {
        return queue.Count > 0;
    }

    public Segment Next()
    {
        Segment segment = queue.Min;
        queue.Remove(segment);
        return segment;
    }
}