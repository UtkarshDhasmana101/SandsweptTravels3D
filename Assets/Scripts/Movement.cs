using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class Movement : MonoBehaviour
{
    [Header("Slope Handle")]
    public float maxSlopeAngle;
    private RaycastHit slopeHit;
    public float playerHeight;
    public Vector3 moveDirection;
    // Start is called before the first frame update
    public Rigidbody rb;
    [SerializeField] float forceMag;
    [SerializeField] float jump = 5f;
    [SerializeField] GameObject lane1Cube;
    [SerializeField] GameObject lane2Cube;
    [SerializeField] GameObject lane3Cube;
    [SerializeField] float groundDistance = 0.5f;

    private Vector3[] lanePos;

    int currentLaneIndex;
    int targetIndex;

    void Start()
    {
        Debug.Log("Start");
        lanePos = new Vector3[3];

        currentLaneIndex = 1;

        lanePos[0] = lane1Cube.transform.position;
        lanePos[1] = lane2Cube.transform.position;
        lanePos[2] = lane3Cube.transform.position;
    }




    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.A))
        {
            if (currentLaneIndex != 0)
                targetIndex = currentLaneIndex - 1;

            currentLaneIndex = targetIndex;

            Debug.Log(lanePos[targetIndex]);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            if (currentLaneIndex != 2)
                targetIndex = currentLaneIndex + 1;

            currentLaneIndex = targetIndex;
            Debug.Log(lanePos[targetIndex]);
        }
        float step = 10f * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, lanePos[currentLaneIndex], step);
    }





    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "coin")
            Destroy(collision.gameObject);
    }
    private bool OnSlope()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out slopeHit, playerHeight * 0.5f + 0.3f))
        {
            float angle = Vector3.Angle(Vector3.up, slopeHit.normal);
            return angle < maxSlopeAngle && angle != 0;
        }
        return false;

    }
    private Vector3 GetSlopeMoveDirection()
    {
        {
            return Vector3.ProjectOnPlane( moveDirection, slopeHit.normal).normalized;

        }
    }
}












