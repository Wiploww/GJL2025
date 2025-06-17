using UnityEngine;

public class GameManager : MonoBehaviour
{
    int roundCounter;

    //survey screens
    [SerializeField] GameObject survey1;
    [SerializeField] GameObject survey2;
    [SerializeField] GameObject survey3;
    [SerializeField] GameObject survey4;

    //survey 1 bools
    bool addMoreDesks; //true adds more desks, false removes all desks
    bool floorColorChange; //true for chartreuse, false for aubergine

    //survey 2 bools
    bool birdsOrBots; //true for animals, false for machines
    bool addGoblins; //false adds a question to survey 3

    //survey 3 bools
    //does crossbow v slingshot need a bool?
    bool whichImage; //true for skull, false for backflip
    bool shouldThisQuestionShowUp;
    bool sureAboutGoblins; //only shows up if addGoblins is false

    //survey 4 bools
    bool canBribe;
    bool canHack;
    bool cactusHeight; //true makes cactus taller, false makes it wider
    // reuse shouldThisQuestionShowUp variable?
    bool didPlayerHaveFun;

    //survey 5 (stretch goal)

    //layers
    [SerializeField] GameObject desks;
    [SerializeField] GameObject moreDesks;
    [SerializeField] GameObject animals;
    [SerializeField] GameObject machines;
    [SerializeField] GameObject goblins;
    [SerializeField] GameObject skullImage;
    [SerializeField] GameObject backflipImage;
    [SerializeField] GameObject ogCactus;
    [SerializeField] GameObject tallCactus;
    [SerializeField] GameObject wideCactus;
    
    void Start()
    {
        roundCounter = 1;
    }

    void Update()
    {
        
    }

    public void BeginSurvey()
    {
        switch (roundCounter)
        {
            case 1:
                {
                    survey1.SetActive(true);
                    break;
                }
            case 2:
                {
                    survey2.SetActive(true);
                    break;
                }
            case 3:
                {
                    survey3.SetActive(true);
                    break;
                }
            case 4:
                {
                    survey4.SetActive(true);
                    break;
                }
            default:
                {
                    break;
                }
        }
    }

    public void RecieveSignal(int code)
    {
        switch (code)
        {

            default:
                {
                    break;
                }
        }
    }

    void CheckSurveyInput()
    {

    }

    void CloseSurvey()
    {
        survey1.SetActive(false);
        survey2.SetActive(false);
        survey3.SetActive(false);
        survey4.SetActive(false);
    }
}
