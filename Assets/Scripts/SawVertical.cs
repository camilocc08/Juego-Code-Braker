using UnityEngine;

public class SawVertical : MonoBehaviour
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
        float y = Mathf.PingPong(Time.time * speed, distance) - (distance / 2);
        transform.position = new Vector3(startPos.x, startPos.y + y, startPos.z);
    }
}