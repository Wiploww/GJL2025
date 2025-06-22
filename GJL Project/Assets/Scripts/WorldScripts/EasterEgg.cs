using UnityEngine;

public class EasterEgg : MonoBehaviour
{
    [SerializeField] GameObject gameManager;
    [SerializeField] AudioClip clip;

    private void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position);
            gameManager.gameObject.GetComponent<GameManager>().BeginSurvey();
        }
    }
}
