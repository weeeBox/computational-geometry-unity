using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Geometry
{
    public static class VectorUtils
    {
        public static void MinMax(float a, float b, out float min, out float max)
        {
            min = Mathf.Min(a, b);
            max = Mathf.Max(a, b);
        }

        public static float Area2(Vector2 a, Vector2 b, Vector2 c)
        {
            var v1 = b - a;
            var v2 = c - a;
            return v1.x * v2.y - v1.y * v2.x;
        }

        public static bool IsLeft(Vector2 a, Vector2 b, Vector2 c)
        {
            return Area2(a, b, c) > 0;
        }

        public static bool IsLeftOn(Vector2 a, Vector2 b, Vector2 c)
        {
            return Area2(a, b, c) >= 0;
        }

        public static bool IsCollinear(Vector2 a, Vector2 b, Vector2 c)
        {
            return Area2(a, b, c) == 0;
        }

        public static bool IsBetween(Vector2 a, Vector2 b, Vector2 p)
        {
            float minX, maxX, minY, maxY;
            MinMax(a.x, b.x, out minX, out maxX);
            MinMax(a.y, b.y, out minY, out maxY);
            return p.x >= minX && p.x <= maxX && p.y >= minY && p.y <= maxY;
        }

        public static bool Intersect(Vector2 a, Vector2 b, Vector2 c, Vector2 d)
        {
            if (IsCollinear(a, b, c))
            {
                return IsBetween(a, b, c);
            }

            return (IsLeft(a, b, c) != IsLeft(a, b, d)) && (IsLeft(c, d, a) != IsLeft(c, d, b));
        }
    }
}