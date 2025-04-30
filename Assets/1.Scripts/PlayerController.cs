using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed = 5f;
    public float jumpForce = 8f;
    public Transform groundcheck;
    public LayerMask groundLayer;
    public float Timer = 20.0f;
    public float timer = 15.0f;
    public float tImer = 15.0f;
    float score;


    private Rigidbody2D rb;
    private bool isGrounded;
    private Animator pAni;

    public bool isinvincible = false;
    public bool isfast = false;
    public bool isjump = false;

    public Image[] ItemUI;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        pAni = GetComponent <Animator>();   
        pAni.SetBool("Run", false);

        score = 1000f;
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
            ItemUI[0].color = Color.black;
        }

        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            isfast = false;
            if (isfast == false)
            {
                moveSpeed = 5;
            }
            timer = 15.0f;
            ItemUI[1].color = Color.black;

        }

        tImer -= Time.deltaTime;
        if (tImer <= 0)
        {
            isjump = false;
            if (isjump == false)
            {
                jumpForce = 8;
            }
            tImer = 15.0f;
            ItemUI[2].color = Color.black;

        }

        score -= Time.deltaTime;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Respawn"))
        {
               SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if( collision.CompareTag("Finish"))
        {
            HighScore.TrySet(SceneManager.GetActiveScene().buildIndex, (int)score);
            
            collision.GetComponent<LevelObject>().MoveToNextLevel();
        }

        if( collision.CompareTag("Invincible"))
        {
            Destroy(collision.gameObject);
            isinvincible = true;
            Timer = 20.0f;
            ItemUI[0].color =  Color.white;
            
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
            ItemUI[1].color = Color.white;
        }

        if (collision.CompareTag("Enemy"))
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

        if (collision.CompareTag("Jump"))
        {
            Destroy(collision.gameObject );
            isjump = true;
            tImer = 15.0f;
            if (isjump == true)
            {
                jumpForce = 10.0f;
            }
            ItemUI[2].color = Color.white;
        }

        if (collision.CompareTag("Boss"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        
    }

}
