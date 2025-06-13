using UnityEngine;

public class DoorScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public GameObject MoveTo;
    private Vector3 MoveToPos;

    private GameObject Player;
    void Start()
    {
        MoveTo= this.transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        MoveToPos= MoveTo.transform.position;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {     
            Player=other.gameObject;
            Player.transform.position= MoveToPos;
        } 
    }
}
