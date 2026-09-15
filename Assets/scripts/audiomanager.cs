using UnityEngine;

public class audiomanager : MonoBehaviour
{
    public AudioSource sfxsound;
    public AudioClip coinsound;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   
    public void playcoin()
    {
        Debug.Log("play coin sound");
        Debug.Log("AudioSource enabled: " + sfxsound.enabled);
        Debug.Log("AudioSource active: " + sfxsound.gameObject.activeInHierarchy);
        Debug.Log("Sfx object name: " + sfxsound.gameObject.name);
        Debug.Log("Coin sound clip name: " + coinsound.name);
        Debug.Log("sfx scene: " + sfxsound.gameObject.scene.name);
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
