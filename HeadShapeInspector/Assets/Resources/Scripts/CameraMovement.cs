using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Camera camera;
    public Transform target;
    private Vector2 previousTouchPos;
    public Button resetButton;
    public Slider rotationSlider;
    public float rotationSpeed;
    private const string RotationSpeedKey = "RotationSpeed";

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
        rotationSpeed = PlayerPrefs.GetFloat(RotationSpeedKey, 10f); // Default to 1 if no value is saved
        rotationSlider.value = rotationSpeed;
        rotationSlider.onValueChanged.AddListener(OnRotationSpeedChanged);
        AssignNewTarget();
        resetButton.onClick.AddListener(OnResetButtonClicked);
    }
    void OnRotationSpeedChanged(float value)
    {
        rotationSpeed = value;
        PlayerPrefs.SetFloat(RotationSpeedKey, rotationSpeed);
    }
    public void OnResetButtonClicked()
    {
        // Delete the rotation speed key from PlayerPrefs
        PlayerPrefs.DeleteKey(RotationSpeedKey);

        // Reset the rotation speed to a default value (e.g., 1) and update the slider
        rotationSpeed = 10f;
        rotationSlider.value = rotationSpeed;
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
        if (target != null)
        {
            FocusOnTarget();
        }
        else
        {
            Debug.LogError("No suitable GameObject on the 'Baby' layer found in the scene.");
        }
    }
    void FocusOnTarget()
    {
        // Ensure the camera is correctly positioned and oriented to focus on the target
        camera.transform.position = target.position + new Vector3(0, 1, -10); // Adjust as needed
        camera.transform.LookAt(target);
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

        //transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }

    void OnApplicationQuit()
    {
        PlayerPrefs.Save();
    }


}