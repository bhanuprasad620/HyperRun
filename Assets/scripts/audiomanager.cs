using UnityEngine;

public class audiomanager : MonoBehaviour
{
    public AudioSource sfxsound;
    public AudioClip coinsound;
    public AudioClip gameover;
    public float gameovervolume = 0.3f;
    public AudioSource stopmusic;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   
    public void playcoin()
    {
        
        sfxsound.PlayOneShot(coinsound );
    }
    public void EndGame()
    {
        sfxsound.PlayOneShot(gameover, gameovervolume);
    }
    public void stopMusic()
    {
        stopmusic.Stop();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
