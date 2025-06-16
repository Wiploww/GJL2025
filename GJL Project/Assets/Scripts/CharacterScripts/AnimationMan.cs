using UnityEngine;

public class AnimationMan : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    Rigidbody2D rb;
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
      
        if (rb.linearVelocity.x > 0 )
        {

            //animator.SetBool("LeftWalk", true);

        }
        if (rb.linearVelocity.x < 0)
        {

            //animator.SetBool("RightWalk", true);
        }

        if(rb.linearVelocity.y > 0)
        {
            Debug.Log("Front");
            animator.SetBool("FrontWalk",true);
        }

        if (rb.linearVelocity.y < 0)
        {
            Debug.Log("Back");

            animator.SetBool("BackwardWalk", true);
        }
    }
}
