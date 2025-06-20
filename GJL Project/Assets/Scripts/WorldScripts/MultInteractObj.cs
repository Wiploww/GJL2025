using UnityEngine;

public class MultInteractObj : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public string Loop1text;
    public string Loop2text;
    public string Loop3text;
    public string Loop4text;
    private GameObject MoveTo;
    public GameObject Canvas;
    private GameObject Player;
    private GameObject PressE;
    private bool canTrigger = false;
    private GameManager gameManager;
    void Start()
    {
        PressE = this.transform.GetChild(0).gameObject;
        PressE.SetActive(false);
        Canvas.SetActive(false);
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canTrigger && Input.GetKeyDown(KeyCode.E)&& gameManager.roundCounter==1)
        {
            Canvas.SetActive(true);
            Canvas.GetComponent<DialougeCanvas>().ChangeTxt(Loop1text);
            canTrigger = false;
            PressE?.SetActive(false);
        }

        if (canTrigger && Input.GetKeyDown(KeyCode.E) && gameManager.roundCounter == 2)
        {
            Canvas.SetActive(true);
            Canvas.GetComponent<DialougeCanvas>().ChangeTxt(Loop2text);
            canTrigger = false;
            PressE?.SetActive(false);
        }

        if (canTrigger && Input.GetKeyDown(KeyCode.E) && gameManager.roundCounter == 3)
        {
            Canvas.SetActive(true);
            Canvas.GetComponent<DialougeCanvas>().ChangeTxt(Loop3text);
            canTrigger = false;
            PressE?.SetActive(false);
        }

        if (canTrigger && Input.GetKeyDown(KeyCode.E) && gameManager.roundCounter == 4)
        {
            Canvas.SetActive(true);
            Canvas.GetComponent<DialougeCanvas>().ChangeTxt(Loop4text);
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
