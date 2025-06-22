using UnityEngine;

public class HackableKeypad : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public string CantHacktext;
    public string Hacktext;
    private GameObject MoveTo;
    public GameObject Canvas;
    private GameObject Player;
    private GameObject PressE;
    public bool canTrigger = false;
    private GameManager gameManager;
    public GameObject door;
    private AudioSource AudioSource;
    void Start()
    {
        AudioSource = this.GetComponent<AudioSource>();
        PressE = this.transform.GetChild(0).gameObject;
        PressE.SetActive(false);
        Canvas.SetActive(false);
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        door = this.transform.GetChild(1).gameObject;
        door.GetComponent<DoorScript>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (canTrigger && Input.GetKeyDown(KeyCode.E) && !gameManager.canHack)
        {
            Canvas.SetActive(true);
            Canvas.GetComponent<DialougeCanvas>().ChangeTxt(CantHacktext);
            canTrigger = false;
            PressE?.SetActive(false);
        }

        if (canTrigger && Input.GetKeyDown(KeyCode.E) && gameManager.canHack)
        {
            AudioSource.Play();
            Canvas.SetActive(true);
            Canvas.GetComponent<DialougeCanvas>().ChangeTxt(Hacktext);
            canTrigger = false;
            PressE?.SetActive(false);
            door.GetComponent<DoorScript>().enabled = true;

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
