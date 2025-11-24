using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;       // El personaje a seguir
    public float smoothSpeed = 0.125f; // Suaviza el movimiento de la cámara
    public Vector2 minLimits;      // Límite inferior izquierdo del mapa
    public Vector2 maxLimits;      // Límite superior derecho del mapa

    void LateUpdate()
    {
        if(target == null) return;

        // Posición deseada centrada en el personaje
        Vector3 desiredPosition = new Vector3(target.position.x, target.position.y, transform.position.z);

        // Suavizado de movimiento
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Limitar la cámara para que no salga del mapa
        float camX = Mathf.Clamp(smoothedPosition.x, minLimits.x, maxLimits.x);
        float camY = Mathf.Clamp(smoothedPosition.y, minLimits.y, maxLimits.y);

        transform.position = new Vector3(camX, camY, transform.position.z);
    }
}