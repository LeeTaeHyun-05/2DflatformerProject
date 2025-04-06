//using System.Collections;
//using Unity.VisualScripting;
//using UnityEditor.Experimental.GraphView;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;
public class SimpleMoveScripts : MonoBehaviour
{
    public int speed = 3;
    public Animator myAnimator;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // if (collision.name == "Door1")
            Destroy(collision.gameObject);
        UnityEngine.SceneManagement.SceneManager.LoadScene("Map_" + collision.name);
    }
    void Start()
    {
        myAnimator.SetBool("move", false);
        rb = GetComponent<Rigidbody2D>();
        

    }

    // Update is called once per frame
    void Update()
    {
        float direction = Input.GetAxis("Horizontal");

        if (direction > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
            myAnimator.SetBool("move", true);
            
        }
        else if (direction < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            myAnimator.SetBool("move", true);
           
        }
        else
            myAnimator.SetBool("move", false);
           
            transform.Translate(Vector3.right * direction * speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space))
            rb.AddForce(Vector2.up * 150);
        
    }  

      
}
