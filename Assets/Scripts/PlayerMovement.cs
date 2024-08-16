using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float sideForce = 500f;
    public float jumpForce = 5f;
    public float backForce = 500f;
    public float groundDistance = 0.5f;
    public float maxDownwardVelocity = -5f;
    public float smoothDownwardForce = 2f;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, groundDistance);
    }

    void FixedUpdate()
    {
        if (Input.GetKey("a"))
        {
            rb.AddForce(0, 0, -sideForce * Time.deltaTime);
        }
        if (Input.GetKey("d"))
        {
            rb.AddForce(0, 0, sideForce * Time.deltaTime);
        }
        if (Input.GetKey("w"))
        {
            rb.AddForce(0, 0, -backForce * Time.deltaTime);
        }
        if (Input.GetKey("space") && IsGrounded())
        {
            rb.velocity = Vector3.up * jumpForce;
        }

        float downwardForce = 0f;
        if (!IsGrounded())
        {
            downwardForce = Mathf.Clamp(maxDownwardVelocity - rb.velocity.y, -smoothDownwardForce, smoothDownwardForce);
        }
        rb.AddForce(Vector3.down * downwardForce, ForceMode.Acceleration);
    }


}
