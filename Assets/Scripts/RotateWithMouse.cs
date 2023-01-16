using UnityEngine;

public class RotateWithMouse : MonoBehaviour
{
    // The speed at which the object will rotate
    public float rotationSpeed = 5f;

    // The distance the mouse has to be dragged before the object starts rotating
    public float dragDistance = 5f;

    // The direction the mouse was last dragged
    private Vector2 lastMousePosition;

    void Update()
    {
        // Get the current mouse position
        Vector2 mousePosition = Input.mousePosition;

        // Check if the mouse button is held down
        if (Input.GetMouseButton(0))
        {
            // Check if the mouse has been dragged far enough to start rotating the object
            if (Vector2.Distance(mousePosition, lastMousePosition) > dragDistance)
            {
                // Calculate the direction the mouse was dragged in
                Vector2 dragDirection = mousePosition - lastMousePosition;

                // Calculate the rotation angle based on the drag direction and the rotation speed
                float rotationAngle = dragDirection.x * rotationSpeed;

                // Round the rotation angle to the nearest multiple of 5
                rotationAngle = Mathf.Round(rotationAngle / 5f) * 5f;

                // Rotate the object based on the calculated rotation angle
                transform.Rotate(Vector3.forward, rotationAngle);
            }
        }

        // Update the last mouse position
        lastMousePosition = mousePosition;
    }
}