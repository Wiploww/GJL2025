using UnityEngine;

public class Aligator : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public GameObject Blocker;
    public GameObject Gator;
    private GameManager GameManager;
    void Start()
    {
       
        Gator.SetActive(false);
        GameManager= GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnEnable()
    {
       
        Blocker.SetActive(false);
        Gator.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionStay2D(Collision2D other)
    {
      
    }
}
