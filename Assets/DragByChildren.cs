using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DragByChildren : MonoBehaviour
{
    public GameManager manager;

    private Vector3 mouseOffset;
    private float mouseZCoord;
    private Vector3 initialPosition;
    private Plane xzPlane;
    [SerializeField]private bool isDragging;
    private bool raised = false;
    private Transform currentDraggingObject;


    private void Start()
    {
        manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    private void Awake()
    {
        initialPosition = transform.position;

        // Create a plane perpendicular to the world Y-axis
        xzPlane = new Plane(Vector3.up, transform.position);
    }

    void Update()
    {
        // Create a ray from the mouse position
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        // Find the point where the ray intersects the plane
        float distance;

        xzPlane.Raycast(ray, out distance);
        Vector3 hitPoint = ray.GetPoint(distance);

        // Set the position of the object to the hit point

        // transform.position = hitPoint;
        //RaiseBlocks();

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hitInfo;

            //currentDraggingObject = hitInfo.collider.transform;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo))
            {
                if (hitInfo.collider.transform.IsChildOf(transform))
                {
                    isDragging = true;
                }
            }
        }

        // Check if the left mouse button is being pressed
        if (Input.GetMouseButton(0) && isDragging)
        {
            //RaiseBlocks();

            xzPlane = new Plane(Vector3.up, new Vector3(0, 1, 0));


            // Raycast to see if we hit a collider
            RaycastHit hitInfo;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo))
            {
                Debug.Log(hitInfo.transform.name);

                // Check if the collider is a child of this GameObject
                if (hitInfo.collider.transform.IsChildOf(transform))
                {
                    transform.position = hitPoint + transform.position - hitInfo.transform.position;
                }
            }
        }

        if (Input.GetMouseButtonUp(0) && isDragging)
        {
            //LowerBlocks();
            xzPlane = new Plane(Vector3.up, new Vector3(0, 0, 0));

            raised = false;

            isDragging = false;
            if (IsAreaEmpty() && IsAllBlocksOnAreas())
            {
                transform.position = new Vector3(Mathf.Round(transform.position.x),
                    Mathf.Round(transform.position.y) - 1,
                    Mathf.Round(transform.position.z));
                
                
            }

            else
            {
                RaycastHit hitInfo;
                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo))
                {
                    //Debug.Log(hitInfo.transform.name);
                    // Check if the collider is a child of this GameObject
                    if (hitInfo.collider.transform.IsChildOf(transform))
                    {
                        transform.Rotate(0, 90, 0);
                    }
                }

                transform.position = initialPosition;
            }

            Invoke("CheckAllAreasFullness", 1);
        }

    }

    void CheckAllAreasFullness()
    {
        foreach (var areaUnit in manager.areaUnitList)
        {
            if (areaUnit.isAreaEmpty)
            {
                Debug.Log(areaUnit.isAreaEmpty);
                return;
            }
        }

        Debug.Log("YOU WIN");
        manager.YouWin();
    }

    bool IsAreaEmpty()
    {
        foreach (var blockUnit in transform.GetComponentsInChildren<BlockUnit>())
        {
            if (blockUnit.collidingOtherBlock == true)
            {
                return false;
            }
        }

        return true;
    }

    bool IsAllBlocksOnAreas()
    {
        foreach (var blockUnit in transform.GetComponentsInChildren<BlockUnit>())
        {
            if (!blockUnit.onAreaUnit)
            {
                return false;
            }
        }

        return true;
    }

    void RaiseBlocks()
    {
        foreach (var blockUnit in transform.GetComponentsInChildren<BlockUnit>())
        {
            Debug.Log("raised");
            blockUnit.transform.position = new Vector3(blockUnit.transform.position.x,
                transform.position.y + 1f, blockUnit.transform.position.z);
        }
    }

    void LowerBlocks()
    {
        foreach (var blockUnit in transform.GetComponentsInChildren<BlockUnit>())
        {
            blockUnit.GetComponent<Transform>().position = new Vector3(blockUnit.transform.position.x,
                transform.position.y, blockUnit.transform.position.z);
        }
    }
}