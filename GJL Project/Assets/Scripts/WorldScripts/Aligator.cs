using UnityEngine;

public class Aligator : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private GameObject Blocker;
    private GameObject Gator;
    private GameManager GameManager;
    void Start()
    {
        Blocker= this.transform.GetChild(0).gameObject;
        Gator=this.transform.GetChild(1).gameObject;
        Gator.SetActive(false);
        GameManager= GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionStay2D(Collision2D other)
    {
      
    }
}
