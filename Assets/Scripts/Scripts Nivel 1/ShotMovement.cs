using UnityEngine;

public class ShotMovement : MonoBehaviour
{
    public float speed = 2f;   // Velocidad de la bala
    public float lifetime = 0.5f; // Tiempo antes de destruir la bala

    void Start()
    {
        Destroy(gameObject, lifetime); // evitar balas eternas
    }

    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }
}

