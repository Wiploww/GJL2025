using UnityEngine;

public class DeskScript :MonoBehaviour 
{
    //How to Use:
    //Works exactly like the door script, the only difference is that in every desk object there are two doors
    //the child named Up deals with moving the player up onto the desk and down moving the player off of the desk
    //If making a scinero where the player jumps on a variety of desks like stairs change where the triggers are on both up and down

    private GameObject MoveTo;
    private Vector3 MoveToPos;
    public bool canTP = false;
    private GameObject Player;
    private GameObject PressE;

    private CircleCollider2D CircleCollider2D;
    private BoxCollider2D BoxCollider2D;

    void Start()
    {
        MoveTo = this.transform.GetChild(0).gameObject;
        MoveToPos = MoveTo.transform.position;
        PressE = this.transform.GetChild(1).gameObject;
        PressE.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (canTP && Input.GetKeyDown(KeyCode.E))
        {
            Player.transform.position = MoveTo.transform.position;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {

    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PressE.SetActive(true);
            Player = other.gameObject;
            canTP = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PressE.SetActive(false);
            canTP = false;
        }
    }
}
