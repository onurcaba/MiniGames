using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionAngleObject : MonoBehaviour
{
    private Transform targetObject;
    private Transform tempObject;
    public float duration = 3f;

    public GameObject correct;
    public GameObject wrong;


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
                //CheckShape();
                //Invoke("CheckShape", 1f);
                Invoke("ReturnToInitialPosition", duration);
                tempObject = targetObject;
            }

            targetObject = null;
        }
    }

    public void CheckShape()
    {
        if (tempObject.GetComponent<AngleItem>().angleType.angleType == (int)RotateArm.rotation)
        {
            Debug.Log("Correct");
            correct.SetActive(true);
        }
        else
        {
            Debug.Log("Missed");
            wrong.SetActive(true);
        }
    }

    private void ReturnToInitialPosition()
    {
        tempObject.position = tempObject.GetComponent<AngleItem>().initialPosition;
        tempObject = null;
        correct.SetActive(false);
        wrong.SetActive(false);
    }
}