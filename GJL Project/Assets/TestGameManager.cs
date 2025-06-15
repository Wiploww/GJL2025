using UnityEngine;

public class TestGameManager : MonoBehaviour
{
    bool aOrB;
    bool yesOrNo;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RecieveSignal(int code)
    {
        switch (code)
        {
            case 1:
                {
                    aOrB = true; //a = true
                    break;
                }
            case 2:
                {
                    aOrB = false; //b = false
                    break;
                }
            case 3:
                {
                    yesOrNo = true; //yes
                    break;
                }
            case 4:
                {
                    yesOrNo = false; //no
                    break;
                }
            default:
                {
                    break;
                }
        }
    }
}
