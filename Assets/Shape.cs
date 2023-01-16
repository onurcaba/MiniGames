using System;
using UnityEngine;

public class Shape : MonoBehaviour
{
    public bool place = false;
    public bool dragable = true;
    private string _areaunit = "AreaUnit";
    private Vector3 placementPosition;
    private Vector3 initialPosition;

    private void Awake()
    {
        initialPosition = transform.position;
        placementPosition = initialPosition;
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("Mouse Released");

            transform.position = placementPosition;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(_areaunit))
        {
            Debug.Log(other.name);
            placementPosition = other.transform.position;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        placementPosition = initialPosition;
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log(other.transform.position);
    }


    void OnMouseDrag()
    {
        if (dragable)
        {
            // Create a ray from the mouse position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // Create a plane perpendicular to the world Y-axis
            Plane xzPlane = new Plane(Vector3.up, transform.position);

            // Find the point where the ray intersects the plane
            float distance;
            xzPlane.Raycast(ray, out distance);
            Vector3 hitPoint = ray.GetPoint(distance);

            // Set the position of the object to the hit point

            transform.position = hitPoint;
        }
    }
}