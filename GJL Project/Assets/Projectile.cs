using UnityEngine;

public class Projectile : MonoBehaviour
{
    Vector3 direction;
    GameObject player;
    public float speed = 5.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        direction = new Vector3(Input.mousePosition.x - player.transform.position.x, Input.mousePosition.y - player.transform.position.y, 0.0f);
        direction = direction.normalized;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (direction * speed);
    }
}
