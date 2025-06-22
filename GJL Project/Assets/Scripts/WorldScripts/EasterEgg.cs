using UnityEngine;

public class EasterEgg : MonoBehaviour
{
    [SerializeField] GameObject gameManager;
    AudioSource audioSource;

    private void Start()
    {
        audioSource = this.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            audioSource.Play();
            gameManager.gameObject.GetComponent<GameManager>().BeginSurvey();
        }
    }
}
