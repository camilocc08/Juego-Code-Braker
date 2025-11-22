using UnityEngine;

public class SawHorizontal : MonoBehaviour
{
     public float speed = 2f;       // velocidad del movimiento
    public float distance = 2f;    // qué tanto se mueve

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float x = Mathf.PingPong(Time.time * speed, distance) - (distance / 2);
        transform.position = new Vector3(startPos.x + x, startPos.y, startPos.z);
    }
}
