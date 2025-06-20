using UnityEngine;

public class GuardScripts : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public string CantBribetext;
    public string Bribetext;
    private GameObject MoveTo;
    public GameObject Canvas;
    private GameObject Player;
    private GameObject PressE;
    public bool canTrigger = false;
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
        if (canTrigger && Input.GetKeyDown(KeyCode.E)&& !gameManager.canBribe)
        {
            Canvas.SetActive(true);
            Canvas.GetComponent<DialougeCanvas>().ChangeTxt(CantBribetext);
            canTrigger = false;
            PressE?.SetActive(false);
        }

        if (canTrigger && Input.GetKeyDown(KeyCode.E) && gameManager.canBribe)
        {
            Canvas.SetActive(true);
            Canvas.GetComponent<DialougeCanvas>().ChangeTxt(Bribetext);
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
