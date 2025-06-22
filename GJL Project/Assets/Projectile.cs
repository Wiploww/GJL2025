using UnityEngine;

public class Projectile : MonoBehaviour
{
    Vector3 direction;
    Vector3 mousePos;
    GameObject player;
    GameObject gameManager;
    public float speed = 0.5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        mousePos = Input.mousePosition;
        direction = new Vector3(mousePos.x - player.transform.position.x, mousePos.y - player.transform.position.y, 0.0f);
        direction = direction.normalized;
        direction *= speed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (direction * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Target")
        {
            gameManager.GetComponent<GameManager>().ActivateBridges();
            this.gameObject.SetActive(false);
        }
    }
}
