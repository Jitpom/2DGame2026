using UnityEngine;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public int jumpForce;
    public AudioClip gemSound;
    public AudioClip jumpSound;
    public int score;
    public TMP_Text scoreText;
    private Animator anim;
    private float localScale;
    private Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        score = 0;
        speed = 5f;
        jumpForce = 7;
        anim = GetComponent<Animator>();
        localScale = gameObject.transform.localScale.x;
        rb = GetComponent<Rigidbody2D>();

        scoreText.text = "SCORE: " + score; //Initialize the score text to display the current score
    }

    // Update is called once per frame
    void Update()
    {
        float  horizontalInput = Input.GetAxis("Horizontal"); 
        anim.SetFloat("RunningSpeed", Mathf.Abs(horizontalInput));
        
        
        if (horizontalInput < 0)
        {
            gameObject.transform.localScale = new Vector3(-localScale, localScale, localScale);
        }
        else if (horizontalInput > 0)
        {
            gameObject.transform.localScale = new Vector3(localScale, localScale, localScale);
        }

        gameObject.transform.Translate(Vector3.right * horizontalInput * speed * Time.deltaTime);   
    
        //If hitting the space bar, trigger the jump animation
        if (Input.GetKeyDown(KeyCode.Space))
        {            
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse); //Add an upward force to the Rigidbody2D to make the player jump
            anim.SetTrigger("Jump");
            gameObject.GetComponent<AudioSource>().clip = jumpSound;
            gameObject.GetComponent<AudioSource>().Play();
        }
    }

   void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Gem"))
        {
            gameObject.GetComponent<AudioSource>().clip = gemSound;
            gameObject.GetComponent<AudioSource>().Play(); //Play the gem collection sound effect
            Destroy(other.gameObject); //Destroy the gem object when the player collides with it
            Debug.Log("Gem collected!"); //Log a message to the console when the gem is collected

            score++; //Increment the score by 1 when a gem is collected
            Debug.Log("Score: " + score); //Log the current score to the console
            scoreText.text = "SCORE: " + score; //Update the score text to display the current score
        }
    }    
}
