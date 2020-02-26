using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Face
{
    /// <summary>
    /// Some half-edge on the outer boundary (or null if unbounded).
    /// </summary>
    public HalfEdge outerComponent;
    /// <summary>
    /// Half-edge for each hole in the face.
    /// </summary>
    public readonly List<HalfEdge> innerComponents = new List<HalfEdge>();
}
