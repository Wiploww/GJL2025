using UnityEngine;

public class BridgeMachine : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public string text;
    public GameObject Blocker;
    public GameObject bridge;   
    private GameObject Player;
    private GameObject PressE;
    public bool canTrigger = false;
    private AudioSource AudioSource;
    void Start()
    {
        PressE = this.transform.GetChild(0).gameObject;
        PressE.SetActive(false);
        bridge = this.transform.GetChild(1).gameObject;
        bridge.SetActive(false);
        AudioSource=this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canTrigger && Input.GetKeyDown(KeyCode.E))
        {
            AudioSource.Play();
            Blocker.SetActive(false);
            bridge.SetActive(true);
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
