using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    Rigidbody2D rb;
    public float playerSpeed = 2;
    public bool canMove = true;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            Movement();
        }
    }

    void Movement()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        
        rb.linearVelocity = new Vector2(moveVertical * playerSpeed, rb.linearVelocity.y);
        rb.linearVelocity = new Vector2(moveHorizontal * playerSpeed, rb.linearVelocity.x);
    }

    public void teleportPlayer( Vector3 MoveToPos)
    {
        
    }

}
