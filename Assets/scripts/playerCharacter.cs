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
        animator = GetComponent<Animator>();
        wasGrounded=isGrounded;
        coinManager = FindFirstObjectByType<CoinManager>();
        Audiomanager = FindFirstObjectByType<audiomanager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(coinManager.gamePaused || coinManager.gameOver)
            return;
        
        if (Input.GetKeyDown(KeyCode.Space)&&isGrounded || Input.GetMouseButton(0))
        {
            Jump();
        }
        if (isGrounded && !wasGrounded)
        {
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
            rb.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
            animator.SetTrigger("Jump");
            jumpsound.Play();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
    
    void gameOver()
    {
        if(transform.position.x < -15 || transform.position.y < - 5)
        {
            
            coinManager.GameOver();
            Audiomanager.EndGame();
            Audiomanager.stopMusic();
        }
    }
}   