using UnityEngine;

public class camera_Player : MonoBehaviour
{
    public Transform target;

    private void LateUpdate()
    {
        transform.position = new  Vector3(target.position.x, target.position.y, transform.position.z );

    }
}
