using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid
{
    public static float size = 1f;

    public static Vector3 GetClosestPointOnGrid(Vector3 position)
    {
        float gx = Mathf.Round(position.x / size);
        float gy = Mathf.Round(position.y / size);
        float gz = Mathf.Round(position.z / size);

        Vector3 returnVector = new Vector3(gx, gy, gz) * size;
        return returnVector;
    }

    public static Vector3 GetClosestPointOnGrid(Vector3 position, float gridSize)
    {
        float gx = Mathf.Round(position.x / gridSize);
        float gy = Mathf.Round(position.y / gridSize);
        float gz = Mathf.Round(position.z / gridSize);

        Vector3 returnVector = new Vector3(gx, gy, gz) * gridSize;
        return returnVector;
    }
}
