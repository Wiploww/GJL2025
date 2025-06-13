using UnityEngine;

public class DoorScript : MonoBehaviour
{
    //HOW TO USE:
    //Place into Scene where you want there to be a door
    //Move the MoveToOBJ that is a child of the door object to where you want the door to lead to
    //Move the PressE object that is also a child of the door object to be somewhere around to door
    //To use doors, stand on them and then press E

    private  GameObject MoveTo;
    private Vector3 MoveToPos;
    private bool canTP=false;
    private GameObject Player;
    private GameObject PressE;
    void Start()
    {
        MoveTo= this.transform.GetChild(0).gameObject;
        MoveToPos = MoveTo.transform.position;
        PressE=this.transform.GetChild(1).gameObject;
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
