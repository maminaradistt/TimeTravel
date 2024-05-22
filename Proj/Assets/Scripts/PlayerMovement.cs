using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D body;
    private Animator anim;
    private BoxCollider2D boxcollider;

    private void Awake() {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxcollider = GetComponent<BoxCollider2D>();
    }
    private void Update() {
        float horizontal_input = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontal_input * speed, body.velocity.y);

        if (Input.GetKey(KeyCode.Space)) {
            Jump();
        }

        if (horizontal_input > 0.01f) {
            transform.localScale = Vector3.one;
        }
        else if (horizontal_input < 0.01f) {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        anim.SetBool("run", horizontal_input != 0);
    }
    private void Jump() {
        body.velocity = new Vector2(body.velocity.x, speed);
    }
}