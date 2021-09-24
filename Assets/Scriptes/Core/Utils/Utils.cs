using UnityEngine;

public class Utils
{
    public static Vector2 Rotate(Vector2 v, float degrees) {
        float sin = Mathf.Sin(degrees * Mathf.Deg2Rad);
        float cos = Mathf.Cos(degrees * Mathf.Deg2Rad);

        float tx = v.x;
        float ty = v.y;
        v.x = (cos * tx) - (sin * ty);
        v.y = (sin * tx) + (cos * ty);
        return v;
    }

    public static float Angle(Vector2 v1, Vector2 v2) {
        // angle in [0,180]
        float angle = Vector2.Angle(v1, v2);

        Vector3 n = Vector3.zero; n.z = 1;

        float sign = Mathf.Sign(Vector3.Dot(n, Vector3.Cross(v1, v2)));

        // angle in [-179,180]
        float signed_angle = angle * sign;

        // angle in [0,360] (not used but included here for completeness)
        //float angle360 =  (signed_angle + 180) % 360;

        return signed_angle;
    }
}
