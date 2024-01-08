using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PointInPolygon
{
    public static bool inside(Vector2 a, List<Vector2> polygon, float tolerance)
    {
        int intersections = 0;
        Vector2 b = a + new Vector2(10000, 0);

        for(int i = 0; i < polygon.Count; i++)
        {
            Vector2 c = polygon[i];
            Vector2 d = polygon[(i + 1) % polygon.Count];

            if(Vector2.Distance(c, a) + Vector2.Distance(d, a) <= Vector2.Distance(c, d) + tolerance)
            {
                return true;
            }

            if(LineIntersector.doIntersect(a, b, c, d))
            {
                intersections++;
            }
        }

        if(intersections % 2 == 0)
        {
            return false;
        }

        return true;
    }
}
