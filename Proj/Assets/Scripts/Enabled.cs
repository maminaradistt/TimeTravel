using UnityEngine;

public class Enabled : MonoBehaviour
{
    public Transform obj;
    void Start()
    {
        
    }

    void Update()
    {
        float posX;
        if (Input.GetKeyDown(KeyCode.Escape)) {
            posX = obj.position.x;
            if (obj.position.x == 5.99f) 
                obj.position = new Vector2(0, 0);
            else 
                obj.position = new Vector2(5.99f, 0.98f);
        }
    }
}
