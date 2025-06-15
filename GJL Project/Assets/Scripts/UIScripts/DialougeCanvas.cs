using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class DialougeCanvas : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private string displayTxt="";
    private string[] placeholder;
    public List<string> backupTxt;
    public TextMeshProUGUI Text;
    public int maxChars;
    private bool canExit = false;
    private GameObject Player;
    void Start()
    {
        Player = GameObject.Find("Paul");
        Player.gameObject.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(0,0);
        
    }

    


    private void OnEnable()
    {
        Player = GameObject.Find("Paul");
        Player.GetComponent<CharacterMovement>().canMove = false;
    }

    private void OnDisable()
    {
        Player.GetComponent<CharacterMovement>().canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canExit)
        {
           
            this.gameObject.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.E) && !canExit)
        {
            if (backupTxt.Count <= 0)
            {
                canExit = true;
            }
           
            if (backupTxt.Count > 0)
            {
                
                DispayLongTxt();
            }
           
           
        }
    }

    //max length is 58
    public void ChangeTxt(string Txt)
    {
        if (Txt.Length > 58)
        {   
            placeholder = Txt.Split(' ');
            canExit = false;
            for (int j=0; j<placeholder.Length-1; j++)
            {
                backupTxt.Add( placeholder[j]);
               
            }
            DispayLongTxt();
        }

        if (Txt.Length < 58)
        {
            Text.SetText(Txt);
            canExit = true;
        }
    }

    private void DispayLongTxt()
    {
        displayTxt = "";
        while (backupTxt.Count!=0)
        { 
            if (displayTxt.Length + backupTxt[0].Length <= maxChars)
            {
                displayTxt = displayTxt + " " + backupTxt[0];
                backupTxt.RemoveRange(0,1);
               if (backupTxt.Count == 0)
                {
                    canExit=true;
                    break;
                }
                
            }
            if (displayTxt.Length + backupTxt[0].Length > maxChars)
            {
                Text.SetText(displayTxt);


                break;
            }
           
        }
        Text.SetText(displayTxt);
       
    }
}





//Ant. Bat. Cow. Dog. Emu. Fox. Gnat. Horse. Iguana. Jackal. Kangaroo.












