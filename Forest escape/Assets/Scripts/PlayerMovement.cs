using UnityEngine;
using UnityEngine.SceneManagement;



public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float jump =  14f;
  
    public Vector2 velocity;

    private bool isGround;

    
    public AudioSource jumpSource;
    public AudioSource fallSource;
    public AudioSource gameOverSource;

    private Rigidbody2D rb;
    private Animator animator;

    [SerializeField] private GameObject Panel;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GameObject.Find("Sprite").GetComponent<Animator>();
       
    }

   
    private void Update()
    {
        if (isGround)
            rb.gravityScale = 2;
        {
            if ((Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.UpArrow)) && isGround)
            {
                jumpSource.Play();
                rb.velocity = new Vector2(rb.velocity.x, jump);
                animator.SetBool("IsJump", true);
               

            }
        }
        
        if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            fallSource.Play();
            rb.gravityScale = 10;

        }

        if (rb.velocity.y < 0f)
        {
            animator.SetBool("IsFall", true);
        }

    }
    
    public void Jump()
    {
        if (isGround)
        {
            jumpSource.Play();
            rb.velocity = new Vector2(rb.velocity.x, jump);
            animator.SetBool("IsJump", true);
        }
    }

    public void Fall()
    {
        fallSource.Play();
        rb.gravityScale = 10;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGround = true;
            animator.SetBool("IsJump", false);
            animator.SetBool("IsFall", false);
        }
  
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGround = false;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Spike"))
        {
            Die();
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Die();
        }
    }

    private void Die()
    {
        Time.timeScale = 0;
        GameOverPanel();
    }

    void GameOverPanel()
    {
        gameOverSource.Play();
        Panel.SetActive(true);
    }
}

