using UnityEngine;

public class CameraMovement : MonoBehaviour
{   
    private Transform player;
    public GameObject gobject;
    public Transform pos;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update() {
        if (Input.GetKey(KeyCode.LeftShift))
            pos.position = new Vector2(0, 0);
    }
    void LateUpdate()
    {
        Vector3 temp = transform.position;
        temp.x = player.position.x;
        temp.y = player.position.y;

        transform.position = temp;
    }
}
