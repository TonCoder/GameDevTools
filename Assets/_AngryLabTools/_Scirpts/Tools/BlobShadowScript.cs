using UnityEngine;
using System.Collections;

namespace AngryLab
{
    public class BlobShadowScript : MonoBehaviour
    {
        [Header("Settings")]
        public Transform blobShadowParent; // Parent GameObject with child (child is square mesh with shadow texture)
        public Vector3 blobShadowParentOffset = new Vector3(0f, 0.01f, 0f);
        public LayerMask layerMask;

        void Update()
        {
            Ray ray = new Ray(transform.position, -Vector3.up);
            RaycastHit hitInfo;

            if (Physics.Raycast(ray, out hitInfo, 100f, layerMask))
            {
                blobShadowParent.position = hitInfo.point + blobShadowParentOffset;
                blobShadowParent.up = hitInfo.normal;
            }
            else
            {
                blobShadowParent.position = hitInfo.point + new Vector3(0f, 1000f, 0f);
            }
        }
    }
}