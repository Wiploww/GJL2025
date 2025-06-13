using UnityEngine;
using TMPro;

public class DialougeCanvas : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   
    public TextMeshProUGUI Text;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            this.gameObject.SetActive(false);
        }
    }

    public void ChangeTxt(string Txt)
    {
        Text.SetText(Txt);
    }
}
