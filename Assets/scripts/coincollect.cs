using UnityEngine;
using static UnityEngine.ParticleSystem;

public class coincollect : MonoBehaviour
{
     audiomanager manager;
     CoinManager coinmanager;
     particleeffect Particleeffect;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        manager = FindFirstObjectByType<audiomanager>();
        coinmanager = FindFirstObjectByType<CoinManager>();
        Particleeffect = FindFirstObjectByType<particleeffect>();
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
            Particleeffect.playeffect(transform.position);
            Destroy(gameObject);
           
            Debug.Log("Coin collected!");
            manager.playcoin();
            coinmanager.AddCoin();

        }
    }
    


}
