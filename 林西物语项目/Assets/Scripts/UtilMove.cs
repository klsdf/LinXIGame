using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 作者：闫辰祥
/// </summary>
public class UtilMove 
{
    public static Vector2[]  directions = new Vector2[] {
        Vector2.up,
        (Vector2.up + Vector2.right).normalized,
        Vector2.right,
        (Vector2.down + Vector2.right).normalized,
        Vector2.down,
        (Vector2.down + Vector2.left).normalized,
        Vector2.left,
        (Vector2.up + Vector2.left).normalized
    };

    public static Vector2 GetClosestDirection(Vector2 direction)
    {
        float smallestAngle = Mathf.Infinity;
        Vector2 closestDirection = Vector2.zero;

        foreach (Vector2 dir in directions)
        {
            float angle = Vector2.Angle(direction, dir);
            if (angle < smallestAngle)
            {
                smallestAngle = angle;
                closestDirection = dir;
            }
        }

        return closestDirection;
    }
   
}
