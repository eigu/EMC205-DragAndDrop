using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCamera : MonoBehaviour
{
    PlayerInput playerInput;
    InputAction lookAction;

    [Header("Mouse Sensitivity")]
    [SerializeField] float sensX;
    [SerializeField] float sensY;

    Rigidbody rb;

    [SerializeField] Transform cameraHolder;
    [SerializeField] Vector3 currentRotation;

    private void Awake()
    {
        rb = PlayerScript.Instance.rigidBody;
        playerInput = GetComponent<PlayerInput>();
        lookAction = playerInput.actions.FindAction("Look");
    }

    private void Start()
    {
        HideCursor();
    }

    private void OnEnable()
    {
        lookAction.performed += Look;
    }

    private void OnDisable()
    {
        lookAction.performed -= Look;
    }

    private void Look(InputAction.CallbackContext context)
    {
        Vector3 mouseDelta = lookAction.ReadValue<Vector2>();

        
        currentRotation.x += mouseDelta.x;
        currentRotation.y -= mouseDelta.y;

        float clampValue = 80f;
        currentRotation.y = Mathf.Clamp(currentRotation.y, -clampValue, clampValue);

        //vertical
        cameraHolder.rotation = Quaternion.Euler(new Vector3(currentRotation.y, cameraHolder.rotation.eulerAngles.y, 0));
        Debug.Log(cameraHolder.rotation.eulerAngles.y);

        //horizontal
        rb.rotation = Quaternion.Euler(new Vector3(0, currentRotation.x, 0));
    }

    private void HideCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
