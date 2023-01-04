using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateArmWithMouse : MonoBehaviour
{
    public float RotationSpeed;

    private void OnMouseDrag()
    {
        Vector2 mousePosition = Input.mousePosition;
        float directionX = transform.position.x - Camera.main.ScreenToWorldPoint(mousePosition).x;
        float directionY = transform.position.y - Camera.main.ScreenToWorldPoint(mousePosition).y;
        float ZaxisRotation = Input.GetAxis("Mouse Y") * RotationSpeed * Mathf.Sign(directionX) -
                              Input.GetAxis("Mouse X") * RotationSpeed * Mathf.Sign(directionY);
        Debug.Log(ZaxisRotation);

        transform.RotateAround(Vector3.forward, ZaxisRotation);
    }
}