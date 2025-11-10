using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 5.1f;

    private Rigidbody2D rb2D;
    private bool isGrounded;
    private Animator animator;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float move = 0f;

        // Movimiento horizontal
        if (Input.GetKey(KeyCode.A))
            move = -1f;
        else if (Input.GetKey(KeyCode.D))
            move = 1f;

        rb2D.linearVelocity = new Vector2(move * speed, rb2D.linearVelocity.y);

        // Flip del personaje
        if (move != 0)
            transform.localScale = new Vector3(Mathf.Sign(move), 1, 1);

        // Saltar
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            rb2D.linearVelocity = new Vector2(rb2D.linearVelocity.x, jumpForce);
            animator.SetTrigger("Jump"); // Usa tu parámetro Jump
            isGrounded = false;
        }

        // Actualizar parámetros del Animator
        animator.SetFloat("Speed", Mathf.Abs(move));
        animator.SetFloat("VerticalVel", rb2D.linearVelocity.y);
        animator.SetBool("isGrounded", isGrounded);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            isGrounded = false;
        }
    }
}
