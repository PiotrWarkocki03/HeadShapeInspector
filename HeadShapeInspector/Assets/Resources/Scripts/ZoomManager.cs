
using UnityEngine;
using UnityEngine.InputSystem.Controls;
using UnityEngine.UI;

public class ZoomManager : MonoBehaviour
{
    [SerializeField] private Transform modelTransform;
    [SerializeField] private float zoomOutMin = 0.02f;
    [SerializeField] private float zoomOutMax = 0.08f;

    private float inc;

    Touch touchZero;
    Touch touchOne;
    Vector2 touchZeroPrevPos;
    Vector2 touchOnePrevPos;
    float prevMagnitude;
    float currentMagnitude;
    float diff;

    [SerializeField] private Camera cam;

    private void Update() {

        if (Input.touchCount == 2)
        {
            touchZero = Input.GetTouch(0);
            touchOne = Input.GetTouch(1);

            touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            prevMagnitude = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            currentMagnitude = (touchZero.position - touchOne.position).magnitude;

            diff = currentMagnitude - prevMagnitude;

            Zoom(diff * 0.01f);
        }

        Zoom(Input.GetAxis("Mouse ScrollWheel"));
    }

    void Zoom(float increment){

        // Zoom using the Model
        //inc = Mathf.Clamp(modelTransform.localScale.x+increment, zoomOutMin, zoomOutMax);
        //modelTransform.localScale = new Vector3(inc,inc,inc);

        //Zoom using the Camera
        cam.orthographicSize = Mathf.Clamp(cam.orthographicSize + increment, 3.5f, 5.5f);


    }
}
