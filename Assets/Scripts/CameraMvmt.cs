using UnityEngine;

public class CameraMvmt : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;

   public void Update()
    {
        transform.position = player.position+ offset;

    }
}
