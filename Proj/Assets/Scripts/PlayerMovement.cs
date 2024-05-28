using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpForce = 7f;
    private Rigidbody2D body;
    private Animator anim;
    private BoxCollider2D boxcollider;
    private int jumpCount = 0;
    private SpriteRenderer sprite;
    private GroundCheck groundCheck;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxcollider = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        groundCheck = GetComponentInChildren<GroundCheck>();
    }

    private void Update()
    {
        if (groundCheck.isGrounded) State = States.idle;
        if (Input.GetButton("Horizontal")) Run();
        if (Input.GetKeyDown(KeyCode.Space)) Jump();

        if (groundCheck.isGrounded)
        {
            jumpCount = 0;
        }

        UpdateState();
    }

    private void Jump()
    {
        if (groundCheck.isGrounded || jumpCount < 2)
        {
            body.velocity = new Vector2(body.velocity.x, jumpForce);
            jumpCount++;
            if (groundCheck.isGrounded)
            {
                groundCheck.isGrounded = false;
            }
        }
    }

    private void UpdateState()
    {
        if (!groundCheck.isGrounded && body.velocity.y != 0)
        {
            State = States.jump;
        }
        else if (Input.GetButton("Horizontal"))
        {
            State = States.run;
        }
        else
        {
            State = States.idle;
        }
    }

    public enum States
    {
        idle, run, jump
    }

    private States State
    {
        get { return (States)anim.GetInteger("state"); }
        set { anim.SetInteger("state", (int)value); }
    }

    private void Run()
    {
        Vector3 horizontal_input = transform.right * Input.GetAxis("Horizontal");
        transform.position = Vector3.MoveTowards(transform.position, transform.position + horizontal_input, speed * Time.deltaTime);
        sprite.flipX = horizontal_input.x < 0;
    }
}
