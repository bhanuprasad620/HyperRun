using UnityEngine;

public class coincollect : MonoBehaviour
{
    public audiomanager manager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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


        }
    }
    


}
