using UnityEngine;

public class InteractObjScript : MonoBehaviour
{
    //How To Use:
    //Place into Scene where you want there to be a interactable obj
    //Move the PressE object that is also a child of the obj to be somewhere around the obj
    //change text to whatever you want
    //put the Dialouge canvas in as the canvas

    public string text;
    private GameObject MoveTo;
    public GameObject Canvas;
    private GameObject Player;
    private GameObject PressE;
    public bool canTrigger=false;
    void Start()
    {
        PressE = this.transform.GetChild(0).gameObject;
        PressE.SetActive(false);
        Canvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(canTrigger && Input.GetKeyDown(KeyCode.E))
        {
            Canvas.SetActive(true);
            Canvas.GetComponent<DialougeCanvas>().ChangeTxt(text);
            canTrigger = false;
            PressE?.SetActive(false);
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
}
