using UnityEngine;

public class positions : MonoBehaviour
{
    public Transform start;
    public Transform end;

    float speed = 8f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       transform.Translate(Vector2.left*speed*Time.deltaTime);
        
        if (transform.position.x < -150f)
        {
            Destroy(gameObject);
        }
    }
}
