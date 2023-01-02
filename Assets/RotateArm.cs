using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RotateArm : MonoBehaviour
{
    public TextMeshProUGUI text;
    public float rotation = 180f;

    public GameObject arm;

    private void Start()
    {
        MatchText();
    }

    private string MatchText()
    {
        return text.text = rotation.ToString();
    }

    public void RotateArmClockWise()
    {
        if (rotation > 0)
        {
            rotation -= 30f;
            arm.transform.rotation = Quaternion.Euler(0, 0, rotation);
            MatchText();
        }
    }

    public void RotateArmCounterClockWise()
    {
        if (rotation < 180)
        {
            rotation += 30f;
            arm.transform.rotation = Quaternion.Euler(0, 0, rotation);
            MatchText();
        }
    }
}