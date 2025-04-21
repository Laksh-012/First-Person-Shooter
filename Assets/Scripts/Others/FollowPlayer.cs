using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;

    public Vector3 offset = new Vector3();

    void Update()
    {
        transform.position = player.position + offset;
        
    }
}
