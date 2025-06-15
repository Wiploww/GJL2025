using System.Collections.Generic;
using UnityEngine;

public class FloorManager : MonoBehaviour
{
    public List<GameObject> AllFloors;
    public Color Aubergine;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeFloorColour()
    {
        foreach (GameObject f in AllFloors)
        {
            f.GetComponent<SpriteRenderer>().color=Aubergine;
        }

    }
}   
