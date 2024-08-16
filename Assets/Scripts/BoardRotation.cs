using UnityEngine;

public class BoardRotation : MonoBehaviour
{
    public float maxDistance = 1f;
    public float smoothness = 5f;
    public float slopeThreshold = 5f;
    public float maxRotationAngle = 45f;
    public float maxDownwardAngle = 30f;
    public float rotationTolerance = 0.1f;
    public Transform character;

    private Quaternion initialRotation;
    private Quaternion targetRotation;

    void Start()
    {
        initialRotation = transform.rotation;
        targetRotation = initialRotation;
    }

    void FixedUpdate()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, maxDistance))
        {
            Vector3 slopeNormal = hit.normal;
            Quaternion newRotation = Quaternion.FromToRotation(transform.up, slopeNormal) * initialRotation;

            float angleDifference = Quaternion.Angle(transform.rotation, newRotation);

            if (angleDifference > slopeThreshold)
            {
                float slopeAngle = Vector3.Angle(Vector3.up, slopeNormal);
                bool isDownwardSlope = slopeNormal.y < -0.2817923f;

                if (isDownwardSlope)
                {
                    float downwardAngle = Mathf.Clamp(-slopeAngle, -maxDownwardAngle, maxDownwardAngle);
                    targetRotation = Quaternion.RotateTowards(transform.rotation, initialRotation * Quaternion.Euler(0, 0, downwardAngle), maxRotationAngle);
                }
                else
                {
                    targetRotation = Quaternion.RotateTowards(transform.rotation, newRotation, maxRotationAngle);
                
                }
            }
            else
            {

                targetRotation = initialRotation;
            }
        }
        else
        {

            targetRotation = initialRotation;
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.fixedDeltaTime * smoothness);
    }

    void LateUpdate()
    {
        if (character != null)
        {
            character.position = transform.position;
        }
    }
}