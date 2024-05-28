using UnityEngine;
using UnityEngine.UI;

public class Cubeee : MonoBehaviour
{
    public Image heart1, heart2, heart3;
    public Image poison1, poison2, poison3;
    private Rigidbody2D body;
    public GameObject Poison1, Poison2, Poison3;
    public GameObject enemy;
    private bool isTouching = false;
    public Animator die;
    private int Health = 3;
    private int poison_count = 0;
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
        else if (other.gameObject.tag == "Ground")
            isTouching = false;
        else if (other.gameObject.tag == "Poison") {
            if (poison_count == 0) {
            poison1.gameObject.SetActive(true);
            Destroy(other.gameObject);
            }
            else if (poison_count == 1) {
                poison2.gameObject.SetActive(true);
                Destroy(other.gameObject);
            }
            else {
                poison3.gameObject.SetActive(true);
                Destroy(other.gameObject);
            }
            poison_count++;
        }
        if (other.gameObject.tag == "Enemy") {
            isTouching = true;
            Health -= 1;
            body.velocity = new Vector2(body.velocity.x, 5);
            enemy.gameObject.SetActive(false);
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
            enemy.transform.position = new Vector3(1.26f, -1.57f, 0);
            enemy.gameObject.SetActive(true);
        }
    }
}
