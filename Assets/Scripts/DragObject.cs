using UnityEngine;

public class DragObject : MonoBehaviour
{
    private bool isDragging;
    private Vector3 screenPoint;
    private Vector3 offset;
    private Transform objectToDrag;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("dragable"))
                {
                    objectToDrag = hit.transform;
                    screenPoint = Camera.main.WorldToScreenPoint(objectToDrag.position);
                    offset = objectToDrag.position -
                             Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y,
                                 screenPoint.z));
                    isDragging = true;
                }
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }
        if (isDragging)
        {
            Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
            Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
            objectToDrag.position = curPosition;
        }
    }
}