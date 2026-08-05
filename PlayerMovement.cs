using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private Animator anim;
    private float localScale;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        speed = 5f;
        anim = GetComponent<Animator>();
        localScale = gameObject.transform.localScale.x;
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
    }
}
