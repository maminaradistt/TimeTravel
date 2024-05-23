using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class Cubeee : MonoBehaviour
{
    public Image heart1, heart2, heart3;
    private Rigidbody2D body;
    private bool isTouching = false;
    public Animator die;
    private int Health = 3;
    void Start() {
        body = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        CheckHealth();
        die.SetBool("isTouching", isTouching);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Cube"){
        isTouching = true;
        Health -= 1;
        body.velocity = new Vector2(body.velocity.x, 5);
        }
        else if (other.gameObject.tag == "Ground") {
            isTouching = false;
        }
        
    }
    private void CheckHealth() {
        if (Health == 2)
        heart1.gameObject.SetActive(false);
        if (Health == 1)
        heart2.gameObject.SetActive(false);
        if (Health == 0){
            transform.position = new Vector3(-11.54f, -0.813f, 0);
            Health = 3;
            heart1.gameObject.SetActive(true);
            heart2.gameObject.SetActive(true);
        }
    }
}
