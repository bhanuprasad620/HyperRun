using UnityEngine;

public class audiomanager : MonoBehaviour
{
    public AudioSource sfxsound;
    public AudioClip coinsound;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   
    public void playcoin()
    {
        Debug.Log("PlayCoin called");
        Debug.Log("Source enabled: " + sfxsound.enabled);
        Debug.Log("Source active: " + sfxsound.gameObject.activeInHierarchy);
        Debug.Log("Source name: " + sfxsound.gameObject.name);
        sfxsound.PlayOneShot(coinsound);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
