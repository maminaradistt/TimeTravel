using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    public float jumpforce = 3f;
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
        transform.position += new Vector3(horizontal_input, 0,0) * speed * Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space)) {
            body.AddForce(new Vector2(0, jumpforce), ForceMode2D.Impulse);
        }

        anim.SetBool("run", horizontal_input != 0);
    }
}