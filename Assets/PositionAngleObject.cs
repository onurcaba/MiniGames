using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionAngleObject : MonoBehaviour
{
    private Transform targetObject;

    private void OnTriggerEnter(Collider other)
    {
        targetObject = other.transform;
    }

    private void OnTriggerExit(Collider other)
    {
        targetObject = null;
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            if (targetObject)
            {
                targetObject.transform.position = transform.position;
            }

            targetObject = null;
        }
    }
}