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
    [SerializeField] private float rotationSpeed = 10f; // Default rotation speed
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
        //AssignSliderTarget();
        LoadRotationSpeed();
        if (rotationSlider != null)
        {
            rotationSlider.value = rotationSpeed;
            rotationSlider.onValueChanged.AddListener(OnRotationSpeedChanged);
        }
        if (resetButton != null)
        {
            resetButton.onClick.AddListener(OnResetButtonClicked);
        }
    }

    void OnRotationSpeedChanged(float value)
    {
        rotationSpeed = value;
        PlayerPrefs.SetFloat(RotationSpeedKey, rotationSpeed);
        PlayerPrefs.Save();
    }

    public void OnResetButtonClicked()
    {
        PlayerPrefs.DeleteKey(RotationSpeedKey);
        rotationSpeed = 10f; // Reset to default value
        if (rotationSlider != null)
        {
            rotationSlider.value = rotationSpeed;
        }
    }

    void LoadRotationSpeed()
    {
        rotationSpeed = PlayerPrefs.GetFloat(RotationSpeedKey, 10f); // Default to 10 if no value is saved
        if (rotationSlider != null)
        {
            rotationSlider.value = rotationSpeed;
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        LoadRotationSpeed(); // Load rotation speed when scene is loaded
        AssignBabyTarget();
        AssignSliderTarget();
        AssignResetButtonTarget();
    }

    void AssignBabyTarget()
    {
        GameObject[] allObjects = GameObject.FindGameObjectsWithTag("Baby");
        foreach (GameObject obj in allObjects)
        {
            if (obj != camera.gameObject)
            {
                target = obj.transform;
                break;
            }
        }
        if (target != null)
        {
            FocusOnTarget();
            Debug.Log("Baby found");
        }
        else
        {
            Debug.LogWarning("No suitable GameObject found in the scene.");
        }
    }

    void AssignSliderTarget()
    {
        GameObject sliderObject = GameObject.FindGameObjectWithTag("Sensitivity");
        if (sliderObject != null)
        {
            rotationSlider = sliderObject.GetComponent<Slider>();
            if (rotationSlider != null)
            {
                rotationSlider.value = rotationSpeed;
                rotationSlider.onValueChanged.AddListener(OnRotationSpeedChanged);
                Debug.Log("Slider found and assigned.");
            }
        }
        else
        {
            Debug.LogWarning("Slider GameObject not found in the scene.");
        }
    }

    void AssignResetButtonTarget()
    {
        GameObject buttonObject = GameObject.FindGameObjectWithTag("Reset");
        if (buttonObject != null)
        {
            resetButton = buttonObject.GetComponent<Button>();
            if (resetButton != null)
            {
                resetButton.onClick.AddListener(OnResetButtonClicked);
                Debug.Log("Reset button found and assigned.");
            }
        }
        else
        {
            Debug.LogWarning("Reset button GameObject not found in the scene.");
        }
    }

    void FocusOnTarget()
    {
        camera.transform.position = target.position + new Vector3(0, 1, -10);
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

                camera.transform.Rotate(Vector3.right, -touchDelta.y * rotationSpeed);
                camera.transform.Rotate(Vector3.up, touchDelta.x * rotationSpeed, Space.World);

                camera.transform.Translate(Vector3.forward * -10);

                previousTouchPos = touch.position;
            }
        }
    }
}