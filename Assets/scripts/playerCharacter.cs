using UnityEngine;

public class playerCharacter : MonoBehaviour
{
    public float  JumpForce = 10f;
    public Rigidbody2D rb;
    bool isGrounded = true;
    public Animator animator;
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)&&isGrounded || Input.GetMouseButton(0))
        {
            Jump();
        }
    }

    void Jump()
    {
        if (isGrounded)
        {
            isGrounded = false;
            rb.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
            animator.SetTrigger("Jump");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
    
}   