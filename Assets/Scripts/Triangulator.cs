using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Geometry
{
    [RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
    public class Triangulator : MonoBehaviour
    {
        [SerializeField]
        Vector3[] m_vertices;

        public static bool Intersect(Vector2 a, Vector2 b, Vector2 c, Vector2 d) {
            throw new System.NotImplementedException();
        }

        void OnDrawGizmos()
        {
            if (m_vertices == null) {
                return;
            }

            Gizmos.color = Color.red;

            if (m_vertices.Length > 1) {
                var prev = m_vertices[m_vertices.Length - 1];
                foreach (var curr in m_vertices) 
                {
                    Gizmos.DrawLine(prev, curr);
                    prev = curr;
                }
            }
            
            foreach (var v in m_vertices) {
                Gizmos.DrawSphere(v, 0.1f);
            }
        }
    }
}