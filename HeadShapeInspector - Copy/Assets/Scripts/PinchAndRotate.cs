using UnityEngine;

public class PinchAndRotate : MonoBehaviour
{
    private float initialPinchDistance;
    private Vector3 initialRotation;

    void Update()
    {
        // Check for pinch gesture
        if (Input.touchCount == 2)
        {
            Touch touch0 = Input.GetTouch(0);
            Touch touch1 = Input.GetTouch(1);

            if (touch0.phase == TouchPhase.Began || touch1.phase == TouchPhase.Began)
            {
                initialPinchDistance = Vector2.Distance(touch0.position, touch1.position);
            }
            else if (touch0.phase == TouchPhase.Moved || touch1.phase == TouchPhase.Moved)
            {
                float currentPinchDistance = Vector2.Distance(touch0.position, touch1.position);
                float pinchDelta = currentPinchDistance - initialPinchDistance;
                float scaleFactor = pinchDelta * 0.002f; // Adjust this value to control zoom speed

                // Apply scaling
                transform.localScale += new Vector3(scaleFactor, scaleFactor, scaleFactor);
            }
        }

        // Check for rotate gesture
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                initialRotation = transform.eulerAngles;
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                float rotateSpeed = 0.1f; // Adjust this value to control rotation speed
                Vector3 rotationDelta = new Vector3(-touch.deltaPosition.y, touch.deltaPosition.x, 0) * rotateSpeed;

                // Apply rotation
                transform.eulerAngles = initialRotation + rotationDelta;
            }
        }
    }
}
