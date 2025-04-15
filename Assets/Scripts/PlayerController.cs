using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed = 5f;
    public float jumpForce = 5;
    public Transform groundcheck;
    public LayerMask groundLayer;
    public float Timer = 20.0f;
    public float timer = 15.0f;


    private Rigidbody2D rb;
    private bool isGrounded;
    private Animator pAni;

    bool isinvincible = false;
    bool isfast = false;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        pAni = GetComponent <Animator>();   
        pAni.SetBool("Run", false); 
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        isGrounded = Physics2D.OverlapCircle(groundcheck.position, 0.2f, groundLayer);

        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            pAni.SetTrigger("Jump");
        }

        if (moveInput < 0)
            transform.localScale = new Vector3(-0.6f, 0.6f, 1f);

        if (moveInput > 0)
            transform.localScale = new Vector3(0.6f, 0.6f, 1f);

        if (moveInput < 0)
        {
            transform.localScale = new Vector3(-0.6f, 0.6f, 1);
            pAni.SetBool("Run", true);

        }
        else if (moveInput > 0)
        {
            transform.localScale = new Vector3(0.6f, 0.6f, 1);
            pAni.SetBool("Run", true);

        }
        else
            pAni.SetBool("Run", false);

        Timer -= Time.deltaTime;
        if (Timer <= 0)
        {
            isinvincible = false;
            Timer = 20.0f;
        }

        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            isfast = false;
            timer = 15.0f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Respawn"))
        {
               SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if( collision.CompareTag("Finish"))
        {
            collision.GetComponent<LevelObject>().MoveToNextLevel();
        }

        if( collision.CompareTag("Invincible"))
        {
            Destroy(collision.gameObject);
            isinvincible = true;
            Timer = 20.0f;
        }

        if( collision.CompareTag("Trap"))
        {
            if (isinvincible == true)
            {
                Destroy(collision.gameObject);
            }
            else if (isinvincible == false)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }            
        }
        
        if( collision.CompareTag("Speed"))
        {
            Destroy(collision.gameObject );
            isfast = true;
            timer = 15.0f;
            if (isfast == true)
            {
                moveSpeed = 10.0f;
            }
        }
    }

}
