using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    PlayerInput playerInput;
    InputAction moveAction;

    [SerializeField] private float speed;

    Rigidbody rb;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        moveAction = playerInput.actions.FindAction("Move");
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector3 value = moveAction.ReadValue<Vector2>();

        if (value == Vector3.zero)
        {
            rb.velocity = new Vector3(0, rb.velocity.y, 0);
        }

        Vector3 direction = new Vector3(value.x, 0, value.y);
        Vector3 velocity = direction * speed * Time.deltaTime;
        velocity.y = rb.velocity.y;

        rb.AddRelativeForce(velocity);
    }
}
