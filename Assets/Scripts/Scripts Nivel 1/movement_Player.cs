using UnityEngine;
using UnityEngine.InputSystem; // Necesario para el nuevo Input System

public class PlayerController : MonoBehaviour
{
    [Header("Movimiento")]
    public float speed = 5f;
    public float jumpForce = 5f;

    private Rigidbody2D rb2D;
    private bool isGrounded;
    private Animator animator;

    private InputSystem_Actions controls;
    private Vector2 moveInput;
    private bool jumpPressed;

    void Awake()
    {
        controls = new InputSystem_Actions();

        // Movimiento
        controls.Player.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        controls.Player.Move.canceled  += ctx => moveInput = Vector2.zero;

        // Saltar
        controls.Player.Jump.performed += ctx => jumpPressed = true;
    }

    void OnEnable()
    {
        controls.Enable();
    }

    void OnDisable()
    {
        controls.Disable();
    }

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Movimiento horizontal
        float move = moveInput.x;

        rb2D.linearVelocity = new Vector2(move * speed, rb2D.linearVelocity.y);

        if (move != 0)
            transform.localScale = new Vector3(Mathf.Sign(move), 1, 1);

        // Saltar
        if (jumpPressed && isGrounded)
        {
            rb2D.linearVelocity = new Vector2(rb2D.linearVelocity.x, jumpForce);
            if (animator != null)
                animator.SetTrigger("Jump");

            isGrounded = false;
        }
        jumpPressed = false;

        // Animator
        if (animator != null)
        {
            animator.SetFloat("Speed", Mathf.Abs(move));
            animator.SetFloat("VerticalVel", rb2D.linearVelocity.y);
            animator.SetBool("isGrounded", isGrounded);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
            isGrounded = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
            isGrounded = false;
    }
}
