using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngleItem : MonoBehaviour
{
    public AngleTypesSO angleType;
    public Vector3 initialPosition;

    private void Start()
    {
        initialPosition = transform.position;
    }
}
