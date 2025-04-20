using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController), typeof(PlayerInput))]
public class FirstPersonController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    public float jumpHeight = 2f;
    public float gravity = -9.81f;

    [Header("Look Settings")]
    public float lookSensitivity = 2f;
    public float minPitch = -90f;
    public float maxPitch = 90f;

    [Header("References")]
    public Transform cameraRoot;

    private CharacterController controller;
    private PlayerInput playerInput;
    private InputAction moveAction;
    private InputAction lookAction;
    private InputAction jumpAction;

    private float pitch = 0f;
    private Vector3 velocity;
    private bool isGrounded;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        playerInput = GetComponent<PlayerInput>();

        moveAction = playerInput.actions["Move"];
        lookAction = playerInput.actions["Look"];
        jumpAction = playerInput.actions["Jump"];

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        HandleLook();
        HandleMove();
    }

    void HandleLook()
    {
        Vector2 look = lookAction.ReadValue<Vector2>() * lookSensitivity;

        // Rotate the player horizontally (yaw)
        transform.Rotate(Vector3.up * look.x);

        // Rotate the camera vertically (pitch)
        pitch -= look.y;
        pitch = Mathf.Clamp(pitch, minPitch, maxPitch);
        cameraRoot.localEulerAngles = new Vector3(pitch, 0f, 0f);
    }

    void HandleMove()
    {
        isGrounded = controller.isGrounded;

        // Apply gravity if not grounded
        if (isGrounded && velocity.y < 0)
            velocity.y = -2f; // Small downward force to ensure it sticks to the ground

        // Get movement input (WASD)
        Vector2 input = moveAction.ReadValue<Vector2>();
        Vector3 move = transform.right * input.x + transform.forward * input.y;

        // Apply movement
        controller.Move(move * moveSpeed * Time.deltaTime);

        // Jumping mechanic
        if (isGrounded && jumpAction.triggered)
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);

        // Apply gravity
        velocity.y += gravity * Time.deltaTime;

        // Apply final velocity to the controller
        controller.Move(velocity * Time.deltaTime);
    }
}
