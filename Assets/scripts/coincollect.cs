using UnityEngine;

public class coincollect : MonoBehaviour
{
     audiomanager manager;
     CoinManager coinmanager;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        manager = FindFirstObjectByType<audiomanager>();
        coinmanager = FindFirstObjectByType<CoinManager>();
    }

    // Update is called once per frame
    void Update()
    {
     //transform.Translate(Vector2.left* speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            Destroy(gameObject);
            Debug.Log("Coin collected!");
            manager.playcoin();
            coinmanager.AddCoin();

        }
    }
    


}
