using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HalfEdge
{
    /// <summary>
    /// An origin vertex.
    /// </summary>
    public Vertex origin;
    /// <summary>
    /// Twin half-edge.
    /// </summary>
    public HalfEdge twin;
    /// <summary>
    /// Face that the edge bounds.
    /// </summary>
    public Face incidentFace;

    /// <summary>
    /// Next edge on the boundary of the indicent face.
    /// </summary>
    public HalfEdge next;
    /// <summary>
    /// Prev edge on the boundary of the indicent face.
    /// </summary>
    public HalfEdge prev;
}
