using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator anim;
    public float speed = 0.1f;
    private Transform player; 
    void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, (speed * Time.deltaTime)/3);
    }

    
}
