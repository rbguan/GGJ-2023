using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtilityFunctionLibrary
{
    public static Vector2 GetVec3AsVec2(Vector3 Vec3)
    {
        return new Vector2(Vec3.x, Vec3.y);
    }

    // proj(a,b) = how much of a aligned to b
    public static Vector2 ProjectVec2(Vector2 a, Vector2 b)
    {
        return b.normalized * (Vector2.Dot(a, b) / a.magnitude);
    }

    public static bool RandomBool()
    {
        return (Random.value > 0.5f);
    }
}
