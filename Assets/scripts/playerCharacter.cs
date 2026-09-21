using UnityEngine;

public class playerCharacter : MonoBehaviour
{
    public float  JumpForce = 10f;
    public Rigidbody2D rb;
    bool isGrounded = true;
    public Animator animator;
    public AudioSource jumpsound;
    public AudioClip landsound;
    private bool wasGrounded;
    public CoinManager coinManager;
    audiomanager Audiomanager;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        
        wasGrounded =isGrounded;
        coinManager = FindFirstObjectByType<CoinManager>();
        Audiomanager = FindFirstObjectByType<audiomanager>();

    }
  
    void Update()
    {
        if(coinManager.gamePaused || coinManager.gameOver)
            return;
        
        if (Input.GetKeyDown(KeyCode.Space)&&isGrounded || Input.GetMouseButtonDown(0))
        {
            Jump();
           
        }
        if (isGrounded && !wasGrounded)
        {

          
            animator.SetBool("IsJump", false);

            jumpsound.PlayOneShot(landsound);
        }
        if(Input.GetKey(KeyCode.LeftShift))
        {
            coinManager.gamePause();
        }
        wasGrounded = isGrounded;
        gameOver();
    }

    void Jump()
    {
        if (isGrounded)
        {
            isGrounded = false;
          
           rb.linearVelocity = new Vector2(rb.linearVelocity.x, JumpForce);
            
            animator.SetBool("IsJump", true);
         
            jumpsound.Play();
            Debug.Log("JUMP FORCE APPLIED");

            
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        if (collision.gameObject.CompareTag("powercoin"))
        {
            coinManager.Doublecoin();
            Audiomanager.playpowerup();

        }
        if(collision.gameObject.CompareTag("Enemy"))
        {
            coinManager.GameOver();
            Audiomanager.EndGame();
            Audiomanager.stopMusic();
        }
    }

    
    void gameOver()
    {
        if(transform.position.x < -15 || transform.position.y < - 15)
        {
            
            coinManager.GameOver();
            Audiomanager.EndGame();
            Audiomanager.stopMusic();
        }
    }
}   