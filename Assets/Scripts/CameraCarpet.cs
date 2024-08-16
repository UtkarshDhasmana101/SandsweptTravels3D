using UnityEngine;

public class CameraCarpet : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;

    void Update()
    {
        transform.position = player.position + offset;

    }
}
