using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateArmWithMouse : MonoBehaviour
{
    public float RotationSpeed;
    private bool draggable = true;
    public float ZaxisRotation;
    private float rotationFinal;

    private void OnMouseDrag()
    {
        if (draggable)
        {
            Vector2 mousePosition = Input.mousePosition;
            float directionX = transform.position.x - Camera.main.ScreenToWorldPoint(mousePosition).x;
            float directionY = transform.position.y - Camera.main.ScreenToWorldPoint(mousePosition).y;
            ZaxisRotation = Input.GetAxis("Mouse Y") * RotationSpeed * Mathf.Sign(directionX) -
                                  Input.GetAxis("Mouse X") * RotationSpeed * Mathf.Sign(directionY);
            Debug.Log(ZaxisRotation);

            // Round the rotation angle to the nearest multiple of 5
            rotationFinal += Mathf.Round(ZaxisRotation / 5f) * 5f;
            
            //transform.Rotate(Vector3.forward, ZaxisRotation);
            transform.rotation= Quaternion.Euler(0,0, rotationFinal);
            //draggable = false;
        }

        // if (Input.GetMouseButtonUp(0))
        // {
        //     draggable = true;
        // }
    }
}