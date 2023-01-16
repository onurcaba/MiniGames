using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockUnit : MonoBehaviour
{
    public bool collidingOtherBlock;
    public bool onAreaUnit;

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("AreaPositionar"))
        {
            onAreaUnit = true;
            if (other.transform.parent.GetComponent<AreaUnit>().isAreaEmpty)
            {
                collidingOtherBlock = false;
            }

            else
            {
                collidingOtherBlock = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("AreaPositionar"))
        {
            onAreaUnit = false;
        }
    }
}