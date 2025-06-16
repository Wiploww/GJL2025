using System.Collections.Generic;
using UnityEngine;

public class FloorManager : MonoBehaviour
{
    //To Use:
    //Put all floor areas into the All floors list
    //They then will change colour when either of the two functions are called
    //Make sure that the floor's sprite image is FloorSprite instead of a default unity sprite

    public List<GameObject> AllFloors;

    public void changeFloorColourAubergine()
    {
        foreach (GameObject f in AllFloors)
        {
            f.GetComponent<SpriteRenderer>().color= new Color32(79,51,77,252);
        }

    }

    public void changeFloorColourChartuse()
    {
        foreach (GameObject f in AllFloors)
        {
            f.GetComponent<SpriteRenderer>().color = new Color32(177, 188, 85, 252);
        }

    }
}   
