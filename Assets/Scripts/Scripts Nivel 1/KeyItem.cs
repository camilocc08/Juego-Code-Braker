using UnityEngine;

public class KeyItem : MonoBehaviour
{
    public GameObject collectedAnimation; 
    private bool collected = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collected) return;

        if (collision.CompareTag("Player"))
        {
            collected = true;

            // 1. Ocultar la llave visual
            GetComponent<SpriteRenderer>().enabled = false;

            // 2. Reproducir animación hija
            if (collectedAnimation != null)
                collectedAnimation.SetActive(true);

            // 3. Sumar al contador global
            KeyManager.Instance.AddKey();

            // 4. Destruir la llave después de animación
            Destroy(gameObject, 1f);
        }
    }
}
