using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaUnit : MonoBehaviour
{
    public bool isAreaEmpty = true;
    public int blockCount;

    private void OnTriggerEnter(Collider other)
    {
        blockCount++;

        if (blockCount > 0)
        {
            isAreaEmpty = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        blockCount--;
        if (blockCount == 0)
        {
            isAreaEmpty = true;
        }
    }
}