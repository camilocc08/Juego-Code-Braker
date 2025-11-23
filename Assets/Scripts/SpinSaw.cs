using UnityEngine;

public class SpinSaw : MonoBehaviour
{
    public float velocidad = 360f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rb.MoveRotation(rb.rotation + velocidad * Time.fixedDeltaTime);
    }
}