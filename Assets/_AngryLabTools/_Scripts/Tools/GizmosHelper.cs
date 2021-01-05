using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GizmosHelper : MonoBehaviour {

    public Color color;

    public GizmoType gizmoType;
    public GizmoType GType { get { return gizmoType; } set { gizmoType = value; } }

    public bool GetParentSize;

    public Vector3 CubeSize;

    public int SphereRadius;

    public bool DisplaySidePlacement;

    public float divideBy = 2;

    public enum GizmoType
    {
        WireCube,
        WireSphere
    };

    void OnValidate()
    {
        GType = gizmoType;
    }

    void OnDrawGizmos()
    {
        color.a = 1;
        Gizmos.color = color;
        if (GType == GizmoType.WireSphere)
        {
            Gizmos.DrawWireSphere(transform.position, SphereRadius);
        }
        else if (GType == GizmoType.WireCube)
        {
            if (GetParentSize)
            {
                CubeSize = transform.localScale;
            }

            Gizmos.DrawWireCube(transform.position, CubeSize);
        }

        if (DisplaySidePlacement)
        {
            var minPos = transform.TransformPoint(Vector3.left / divideBy);
            var maxPos = transform.TransformPoint(Vector3.right / divideBy);

            var zOut = transform.TransformPoint(Vector3.forward / divideBy);
            var zIn = transform.TransformPoint(-Vector3.forward / divideBy);

            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(minPos, 1);
            Gizmos.DrawWireSphere(zOut, 1);
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(maxPos, 1);
            Gizmos.DrawWireSphere(zIn, 1);
        }

    }
}
