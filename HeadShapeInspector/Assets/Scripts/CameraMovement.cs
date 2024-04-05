using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Camera camera;
    [SerializeField] private Transform target;
    private Vector2 previousTouchPos;

    [SerializeField] private float rotationSpeed =20f;

    void Update()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                previousTouchPos = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                Vector2 touchDelta = (touch.position - previousTouchPos) * Time.deltaTime;

                camera.transform.position = target.position;

                //rotates the camera around the object in the y axis

                camera.transform.Rotate(Vector3.right, -touchDelta.y * rotationSpeed);
                //rotates the camera around the object in the x axis
                camera.transform.Rotate(Vector3.up, touchDelta.x * rotationSpeed, Space.World);
                
                camera.transform.Translate(Vector3.forward * -10);

                previousTouchPos = touch.position;
            }
        }
    }
}
