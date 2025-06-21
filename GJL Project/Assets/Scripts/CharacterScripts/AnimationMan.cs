using Unity.VisualScripting;
using UnityEngine;

public class AnimationMan : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Rigidbody2D rb;
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
        rb =GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
      RegularAnimations();

       
       
    }

    void RegularAnimations()
    {
        if (Input.GetKey(KeyCode.W))
        {
            animator.SetBool("BackwardWalk", true);
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            animator.SetBool("BackwardWalk", false);

        }

        if (Input.GetKey(KeyCode.S))
        {
            animator.SetBool("ForwardWalk", true);
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            animator.SetBool("ForwardWalk", false);

        }

        if (Input.GetKey(KeyCode.D))
        {
            animator.SetBool("RightWalk", true);
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            animator.SetBool("RightWalk", false);

        }

        if (Input.GetKey(KeyCode.A))
        {
            animator.SetBool("LeftWalk", true);
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            animator.SetBool("LeftWalk", false);

        }
    }
}

