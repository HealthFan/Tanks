using UnityEngine;

public class TankController : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float rotationSpeed = 120.0f;
    public float wheelRotationSpeed = 200.0f; // Added wheel rotation speed
    public GameObject[] leftWheels;
    public GameObject[] rightWheels;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // FixedUpdate is called once per physics step
    void FixedUpdate()
    {
        float moveInput = Input.GetAxis("Vertical");
        float rotationInput = Input.GetAxis("Horizontal");

        MoveTank(moveInput);
        RotateTank(rotationInput);
        RotateWheels(moveInput, rotationInput);
    }

    void MoveTank(float input)
    {
        // Calculate movement direction based on input
        Vector3 moveDirection = transform.forward * input * moveSpeed * Time.fixedDeltaTime;
        
        // Apply force to the tank's Rigidbody component
        rb.AddForce(moveDirection, ForceMode.VelocityChange);
    }

    void RotateTank(float input)
    {
        // Calculate rotation amount based on input
        float rotation = input * rotationSpeed * Time.fixedDeltaTime;
        
        // Apply rotation to the tank's Rigidbody component
        rb.MoveRotation(rb.rotation * Quaternion.Euler(0.0f, rotation, 0.0f));
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
