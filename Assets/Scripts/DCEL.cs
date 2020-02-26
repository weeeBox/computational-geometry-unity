using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Doubly-Connected Edge List
/// </summary>
public class DCEL
{
    public readonly List<Vertex> vertices = new List<Vertex>();
    public readonly List<Face> faces = new List<Face>();
    public readonly List<HalfEdge> edges = new List<HalfEdge>();
}
