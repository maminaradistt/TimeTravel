using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    private Rigidbody2D body;
    private Animator anim;
    private BoxCollider2D boxcollider;
    private int jumpCount = 1;
    private bool isGrounded;
    [SerializeField] private LayerMask groundLayer;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxcollider = GetComponent<BoxCollider2D>();
    }
     private void Update()
    {
        float horizontal_input = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontal_input * speed, body.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        if (horizontal_input > 0.01f)
        {
            transform.localScale = Vector3.one;
        }
        else if (horizontal_input < 0.01f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        anim.SetBool("run", horizontal_input != 0);

        CheckGrounded(); 
    }

    private void Jump()
    {
        if (isGrounded || jumpCount < 2)
        {
            body.velocity = new Vector2(body.velocity.x, jumpForce);
            jumpCount++;
            isGrounded = false;
        }
    }

    private void CheckGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxcollider.bounds.center, boxcollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        isGrounded = raycastHit.collider != null;
        if (isGrounded)
        {
            jumpCount = 1;
        }
    }
}