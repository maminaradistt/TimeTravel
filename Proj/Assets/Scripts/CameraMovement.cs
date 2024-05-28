using Unity.VisualScripting;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{   
    private Transform player;
    public GameObject gobject;
    public Transform pos;
    public Transform[] transforms = new Transform[3];
    public float speed = 5.0f;
    public float rotatespeed = 10f;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update() {
        float posX;
        for (int i = 0; i < transforms.Length; i++) {
            if (transforms[i] == null) continue;
            transforms[i].Translate(new Vector2(1,0)*speed*Time.deltaTime);
            posX = transforms[i].position.x;
            if (posX > 10f && transforms[i].gameObject.name == "Cube")
                Destroy(transforms[i].gameObject);
        }
    }
    void LateUpdate()
    {
        Vector3 temp = transform.position;
        temp.x = player.position.x;
        temp.y = player.position.y +2.2f;

        transform.position = temp;
    }
}
