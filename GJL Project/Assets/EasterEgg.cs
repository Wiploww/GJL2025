using UnityEngine;

public class EasterEgg : MonoBehaviour
{
    [SerializeField] GameObject gameManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            gameManager.gameObject.GetComponent<GameManager>().BeginSurvey();
        }
    }
}
