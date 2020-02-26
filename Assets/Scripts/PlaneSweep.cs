using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneSweep
{
}

class Status
{
    private readonly SortedSet<Segment> segments = new SortedSet<Segment>();
}

class Segment
{
    public Vector3 a;
    public Vector3 b;
}

struct EventPoint
{
    public const int EP_START = 0;
    public const int EP_END = 1;

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

    public static EventPoint End(Segment segment)
    {
        return new EventPoint(EP_END, segment);
    }
}