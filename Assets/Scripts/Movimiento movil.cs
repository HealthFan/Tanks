using UnityEngine;

public class TankController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5.0f;
    [SerializeField] private float rotationSpeed = 120.0f;
    [SerializeField] private float wheelRotationSpeed = 200.0f; // Added wheel rotation speed
    public GameObject[] leftWheels;
    public GameObject[] rightWheels;
    public FixedJoystick verticalJoystick; // Joystick for forward/backward movement
    public FixedJoystick horizontalJoystick; // Joystick for rotation

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // FixedUpdate is called once per physics step
    void FixedUpdate()
    {
        float moveInput = verticalJoystick.Vertical;
        float rotationInput = horizontalJoystick.Horizontal;

        MoveTank(moveInput, rotationInput);
    }

    void MoveTank(float moveInput, float rotationInput)
    {
    // Calculate movement direction based on input
    Vector3 moveDirection = transform.forward * moveInput * moveSpeed * Time.fixedDeltaTime;

    // Apply limited force to the tank's Rigidbody component
    if (moveInput != 0)
    {
        rb.AddForce(moveDirection, ForceMode.VelocityChange);
    }
    else
    {
        // Apply damping force if no input (to simulate friction)
        rb.velocity *= 0.95f; // Adjust the damping factor as needed
    }

    // Calculate rotation amount based on input
    float rotation = rotationInput * rotationSpeed * Time.fixedDeltaTime;

    // Apply rotation to the tank's Rigidbody component
    rb.MoveRotation(rb.rotation * Quaternion.Euler(0.0f, rotation, 0.0f));

    // Rotate wheels
    RotateWheels(moveInput, rotationInput);
    }

    void RotateWheels(float moveInput, float rotationInput)
    {
        float wheelRotation = moveInput * wheelRotationSpeed * Time.fixedDeltaTime; // Use wheel rotation speed

        foreach (GameObject wheel in leftWheels)
        {
            if (wheel != null)
            {
                wheel.transform.Rotate(wheelRotation - rotationInput * wheelRotationSpeed * Time.fixedDeltaTime, 0.0f, 0.0f);
            }
        }

        foreach (GameObject wheel in rightWheels)
        {
            if (wheel != null)
            {
                wheel.transform.Rotate(wheelRotation + rotationInput * wheelRotationSpeed * Time.fixedDeltaTime, 0.0f, 0.0f);
            }
        }
    }
}


