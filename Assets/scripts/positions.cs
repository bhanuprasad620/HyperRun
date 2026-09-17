using UnityEngine;

public class positions : MonoBehaviour
{
    public Transform start;
    public Transform end;

    float speed = 8f;
    CoinManager _manager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _manager= FindFirstObjectByType<CoinManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_manager.gameOver ||_manager.gamePaused)
            return;
       transform.Translate(Vector2.left*speed*Time.deltaTime);
        
        if (transform.position.x < -150f)
        {
            Destroy(gameObject);
        }
    }
}
