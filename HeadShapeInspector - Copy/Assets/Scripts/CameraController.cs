using UnityEngine;


public class CameraController : MonoBehaviour
{
    public float minZoom = 1f;
    public float maxZoom = 10f;
    public float zoomSpeed = 0.5f;

    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        // Detect pinch gesture
        if (Input.touchCount == 2)
        {
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

            float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;

            Zoom(deltaMagnitudeDiff * zoomSpeed);
        }
    }

    private void Zoom(float deltaMagnitudeDiff)
    {
        float newSize = mainCamera.orthographicSize + deltaMagnitudeDiff;
        newSize = Mathf.Clamp(newSize, minZoom, maxZoom);
        mainCamera.orthographicSize = newSize;
    }
}
