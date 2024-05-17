using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Camera camera;
    public Transform target;
    private Vector2 previousTouchPos;

    [SerializeField] private float rotationSpeed = 20f;
    
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void Start()
    {
        AssignNewTarget();
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        AssignNewTarget();
    }

    void AssignNewTarget()
    {
        // Define the layer mask for the "Baby" layer
        int layerMask = 1 << LayerMask.NameToLayer("Baby");

        // Find all GameObjects in the "Baby" layer
        GameObject[] allObjects = FindObjectsOfType<GameObject>();
        foreach (GameObject obj in allObjects)
        {
            if (obj.layer == LayerMask.NameToLayer("Baby") && obj != camera.gameObject) // Check if the object is on the "Baby" layer and is not the camera
            {
                target = obj.transform;
                break;
            }
        }

        if (target == null)
        {
            Debug.LogError("No suitable GameObject on the 'Baby' layer found in the scene.");
        }
    }

    void Update()
    {
        if (target == null) return;

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

                // Rotate the camera around the object in the y axis
                camera.transform.Rotate(Vector3.right, -touchDelta.y * rotationSpeed);
                // Rotate the camera around the object in the x axis
                camera.transform.Rotate(Vector3.up, touchDelta.x * rotationSpeed, Space.World);

                camera.transform.Translate(Vector3.forward * -10);

                previousTouchPos = touch.position;
            }
        }
    }

    
}
