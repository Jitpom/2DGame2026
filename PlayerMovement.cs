using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private Animator anim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float  horizontalInput = Input.GetAxis("Horizontal"); 
        anim.SetFloat("RunningSpeed", Mathf.Abs(horizontalInput));
    }
}
