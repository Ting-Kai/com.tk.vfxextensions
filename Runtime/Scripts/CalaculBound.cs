using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ExecuteAlways]
[RequireComponent(typeof(Camera))]
public class CalaculBound : MonoBehaviour
{
    public float depth = 10.0f;
    public Vector2 rez = Vector2.zero;

    private Camera cam;

    private Vector3 bottomLeft;
    private Vector3 bottomRight;
    private Vector3 topRight;
    private Vector3 topLeft;

    private void Update()
    {
        if (!cam)
        {
            cam = GetComponent<Camera>();
        }

        bottomLeft = cam.ScreenToWorldPoint(new Vector3(0, 0, depth));
        bottomRight = cam.ScreenToWorldPoint(new Vector3(cam.pixelWidth, 0, depth));
        topRight = cam.ScreenToWorldPoint(new Vector3(cam.pixelWidth, cam.pixelHeight, depth));
        topLeft = cam.ScreenToWorldPoint(new Vector3(0, cam.pixelHeight, depth));

        rez.x = topRight.x - bottomLeft.x;
        rez.y = topRight.y - bottomLeft.y;
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(bottomLeft, bottomRight);
        Gizmos.DrawLine(bottomRight, topRight);
        Gizmos.DrawLine(topRight, topLeft);
        Gizmos.DrawLine(topLeft, bottomLeft);
    }
#endif
}
