using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpForce = 7f;
    private Rigidbody2D body;
    private Animator anim;
    private BoxCollider2D boxcollider;
    private int jumpCount = 1;
    private bool isGrounded;
    [SerializeField] private LayerMask groundLayer;
    private SpriteRenderer sprite;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxcollider = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
    }
     private void Update()
    {
        if (isGrounded) State = States.idle; 
        if (Input.GetButton("Horizontal")) Run();
        if (Input.GetKeyDown(KeyCode.Space)) Jump();
   
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
        else State = States.jump;
    }
    public enum States
    {
        idle, run, jump 
    }
    private States State
    {
        get {return (States)anim.GetInteger("state"); }
        set { anim.SetInteger("state", (int)value); }
    }
    private void Run()
    {
        if (isGrounded) State = States.run;
        Vector3 horizontal_input = transform.right * Input.GetAxis("Horizontal");
        transform.position = Vector3.MoveTowards(transform.position, transform.position + horizontal_input, speed * Time.deltaTime);
       sprite.flipX = horizontal_input.x < 0;
    }

}