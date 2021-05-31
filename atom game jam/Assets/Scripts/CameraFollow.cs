using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float xMin, yMin, xMax, yMax;
    public Vector3 offset;
    private Vector3 targetPos;

    private void Update()
    {
        targetPos = player.position + offset;
        targetPos.x = Mathf.Clamp(targetPos.x, xMin, xMax);
        targetPos.y = Mathf.Clamp(targetPos.y, yMin, yMax);
        transform.position = targetPos;
    }
}
