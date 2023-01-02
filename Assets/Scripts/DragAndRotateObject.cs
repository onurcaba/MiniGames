using UnityEngine;

public class DragAndRotateObject : MonoBehaviour
{
    private Vector3 screenPoint;
    private Vector3 offset;
    private float rotationSpeed = 10f;

    void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        //transform.position = curPosition;

        // Calculate the angle between the pivot point and the mouse position
        Vector3 pivotToMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(pivotToMouse.y, pivotToMouse.x) * Mathf.Rad2Deg;

        // Rotate the object around the pivot point
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}