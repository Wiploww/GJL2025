using UnityEngine;
using UnityEngine.UI;

public class TestGameManager : MonoBehaviour
{
    [SerializeField] GameObject survey1;
    [SerializeField] GameObject survey2;

    [SerializeField] GameObject layer1A;
    [SerializeField] GameObject layer1B;
    [SerializeField] GameObject layer2;

    bool aOrB;
    bool yesOrNo;
    int roundCounter;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        survey1.SetActive(false);
        survey2.SetActive(false);
        layer1A.gameObject.SetActive(false);
        layer1B.gameObject.SetActive(false);
        layer2.gameObject.SetActive(false);
        roundCounter = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BeginSurvey()
    {
        //pause or reset the game behind the scenes
        if (roundCounter == 1)
        {
            survey1.SetActive(true);
        }
        else if (roundCounter == 2)
        {
            survey2.SetActive(true);
        }
    }

    public void NextRound()
    {
        CheckSurveyInput();
        CloseSurveys();
        roundCounter++;
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

    void CheckSurveyInput()
    {
        switch (roundCounter)
        {
            case 1:
                {
                    if (aOrB)
                    {
                        layer1A.gameObject.SetActive(true);
                    }
                    else
                    {
                        layer1B.gameObject.SetActive(true);
                    }
                    break;
                }
            case 2:
                {
                    if (yesOrNo)
                    {
                        layer2.gameObject.SetActive(true);
                    }
                    break;
                }
            case 3:
                {
                    break;
                }
            default:
                {
                    break;
                }
        }
    }

    void CloseSurveys()
    {
        survey1.SetActive(false);
        survey2.SetActive(false);
    }
}
