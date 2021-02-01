using System;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KS.Utilities
{
    public static class GameObjectUtilities
    {
        public static Mesh GetBiggestMeshInObject(GameObject gameObject)
        {
            var childMeshes = gameObject.GetComponentsInChildren<MeshFilter>();
            float maxSize = 0f;
            Mesh returnMesh = null;
            foreach (var m in childMeshes)
            {
                Mesh mesh = m.sharedMesh;
                Bounds b = mesh.bounds;

                if (b.max.magnitude > maxSize)
                {
                    maxSize = b.max.magnitude;
                    returnMesh = mesh;
                }
            }

            return returnMesh;
        }

        public static Bounds GetCombinedBoundsInMeshes(GameObject gameObject)
        {
            var childMeshes = gameObject.GetComponentsInChildren<MeshFilter>();
            Bounds bounds = new Bounds(Vector3.zero, Vector3.zero);

            foreach(var m in childMeshes)
            {
                bounds.Encapsulate(m.sharedMesh.bounds);
            }
            return bounds;
        }
    }
}



