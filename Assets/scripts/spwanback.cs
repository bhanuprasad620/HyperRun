using UnityEngine;

public class spwanback : MonoBehaviour
{
    public  GameObject[] prefab;
    Transform endpoint;
    int index = 0;
    public GameObject player;
    int indexvalue = -1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        firstSwpan();
        secondSwpan();
        secondSwpan();
        player.transform.position = new Vector3(-2.5f, -3, 0);
        Instantiate(player);
    }

    // Update is called once per frame
    void Update()
    {
        if(endpoint.position.x<player.transform.position.x+50)
        {
            secondSwpan();
        }
        
    }
    void firstSwpan()
    {
        GameObject obj = Instantiate(prefab[0]);
        positions positions = obj.GetComponent<positions>();
        endpoint = positions.end;
        indexvalue=0;
    }
    void secondSwpan()
    {
        int randomindex = Random.Range(0, prefab.Length);
        while(indexvalue  == randomindex)
        {
            randomindex=Random.Range(0, prefab.Length);
        }
        indexvalue = randomindex;
        GameObject obj = Instantiate(prefab[randomindex]);
        positions positions = obj.GetComponent<positions>();
        obj.transform.position+= endpoint.position-positions.start.position;
        endpoint = positions.end;
        index = Random.Range(0, prefab.Length);
        if (index >= prefab.Length)
        {
            index = 0;
        }
    }
}
