using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vertex
{
    /// <summary>
    /// Coordinates of the vertex.
    /// </summary>
    public Vector3 coordinates;
    /// <summary>
    /// An arbitary half-edge that has this vertex as its origin.
    /// </summary>
    public readonly HalfEdge indicentEdge;
}
