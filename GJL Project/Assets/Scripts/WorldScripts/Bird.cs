using UnityEngine;

public class Bird : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private GameObject MoveTo;
    private GameObject Player;
    private GameObject PressE;
    private Vector3 hold;
    public bool canTrigger = false;
    private GameObject player;
    private CircleCollider2D thisCollider;
    void Start()
    {
        MoveTo = this.transform.GetChild(0).gameObject;

        PressE = this.transform.GetChild(0).gameObject;
        PressE.SetActive(false);
        player = GameObject.Find("Paul");
        thisCollider= this.GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canTrigger && Input.GetKeyDown(KeyCode.E))
        {
            fly();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PressE.SetActive(true);
            canTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PressE.SetActive(false);
            canTrigger = false;
        }
    }

    private void fly()
    {
        //use dotween to animate
        hold=this.transform.position;

        this.transform.position = MoveTo.transform.position;

        player.transform.position= this.transform.position;

        MoveTo.transform.position = hold;
    }
}
