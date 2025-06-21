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
      
        if (rb.linearVelocity.x > 0 )
        {

            //animator.SetBool("LeftWalk", true);

        }
        if (rb.linearVelocity.x < 0)
        {

            //animator.SetBool("RightWalk", true);
        }

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

        /*  if (rb.linearVelocity.y > 0)
          {

              Debug.Log("Back");

              animator.SetBool("BackwardWalk", true);
          }

          if  (rb.linearVelocity.y<0)
          {
              Debug.Log("Front");
              animator.SetBool("ForwardWalk", true);
          }


          if(rb.linearVelocity.y == 0)
          {
              Debug.Log("None");
              animator.SetBool("ForwardWalk", false);
              animator.SetBool("BackwardWalk", false);

          }
      */
    }

}

