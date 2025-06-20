using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int roundCounter;

    [SerializeField] GameObject player;
    Vector3 playerStartPos;

    //survey screens
    [SerializeField] GameObject survey1;
    [SerializeField] GameObject survey2;
    [SerializeField] GameObject survey3;
    [SerializeField] GameObject survey4;
    [SerializeField] GameObject sureAboutGoblinsQuestion;
    [SerializeField] GameObject theQuestionSurvey4;
    [SerializeField] GameObject funQuestionPos1;
    [SerializeField] GameObject funQuestionPos2;

    //boolean hell
    //corrresponding button codes are commented next to the buttons; any answers that have no real effect on the game have a button code of 0
    //survey 1 bools
    bool addMoreDesks = true; //true adds more desks, false removes all desks; codes 11 and 12
    bool floorColorChange = false; //true for chartreuse, false for aubergine; codes 13 and 14

    //survey 2 bools
    bool birdsOrBots = true; //true for animals, false for machines; codes 21 and 22
    bool addGoblins = false; //false adds a question to survey 3; codes 23 and 24

    //survey 3 bools
    //does crossbow v slingshot need a bool?
    bool whichImage = true; //true for skull, false for backflip; codes 31 and 32
    bool shouldThisQuestionShowUp = false; //codes 33 and 34
    bool sureAboutGoblins = true; //corresponding question only shows up if addGoblins is false; codes 35 and 23

    //survey 4 bools
    public bool canBribe; //code 41
    bool canHack; //code 42
    bool cactusHeight = true; //true makes cactus taller, false makes it wider; codes 43 and 44
    // reuse shouldThisQuestionShowUp variable?

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
        playerStartPos = player.transform.position;
        canBribe = false;
        canHack = false;

        //make sure all the things are set correctly
        survey1.SetActive(false);
        survey2.SetActive(false);
        survey3.SetActive(false);
        survey4.SetActive(false);
        sureAboutGoblinsQuestion.SetActive(false);
        theQuestionSurvey4.SetActive(false);
        funQuestionPos1.SetActive(false);
        funQuestionPos2.SetActive(false);

        desks.gameObject.SetActive(true);
        moreDesks.gameObject.SetActive(false);
        animals.gameObject.SetActive(false);
        machines.gameObject.SetActive(false);
        goblins.gameObject.SetActive(false);
        skullImage.gameObject.SetActive(false);
        backflipImage.gameObject.SetActive(false);
        ogCactus.gameObject.SetActive(false);
        tallCactus.gameObject.SetActive(false);
        wideCactus.gameObject.SetActive(false);
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
                    sureAboutGoblinsQuestion.SetActive(false); //MAKE SURE IT STARTS AS FALSE
                    if (!addGoblins) //check for bonus question
                    {
                        sureAboutGoblinsQuestion.SetActive(true);
                    }
                    break;
                }
            case 4:
                {
                    survey4.SetActive(true);
                    theQuestionSurvey4.SetActive(false); //MAKE SURE THEY'RE ALL FALSE
                    funQuestionPos1.SetActive(false);
                    funQuestionPos2.SetActive(false);
                    if (shouldThisQuestionShowUp) //check for bonus question
                    {
                        theQuestionSurvey4.SetActive(true);
                        funQuestionPos2.SetActive(true);
                    }
                    else
                    {
                        funQuestionPos1.SetActive(true);
                    }
                    break;
                }
            case 5:
                {
                    //if it's the final round, end the game
                    break;
                }
            default:
                {
                    break;
                }
        }
    }

    public void NextRound()
    {
        ResetGame();
        CheckSurveyInput();
        CloseSurvey();
        roundCounter++;
    }

    void ResetGame()
    {
        player.transform.position = playerStartPos;
        //reset anything else that needs to be reset
    }

    public void RecieveSignal(int code)
    {
        switch (code)
        {
            //desks
            case 11:
                {
                    addMoreDesks = true;
                    break;
                }
            case 12:
                {
                    addMoreDesks = false;
                    break;
                }
            //floor colors
            case 13:
                {
                    floorColorChange = true; //chartreuse
                    break;
                }
            case 14:
                {
                    floorColorChange = false; //aubergine
                    break;
                }
            //animals vs machines
            case 21:
                {
                    birdsOrBots = true; //animals
                    break;
                }
            case 22:
                {
                    birdsOrBots = false; //machines
                    break;
                }
            //goblins!
            case 23:
                {
                    addGoblins = true;
                    sureAboutGoblins = false;
                    break;
                }
            case 24:
                {
                    addGoblins = false;
                    break;
                }
            //starting room painting choice
            case 31:
                {
                    whichImage = true; //flaming skull
                    break;
                }
            case 32:
                {
                    whichImage = false; //backflip
                    break;
                }
            //bonus funny question
            case 33:
                {
                    shouldThisQuestionShowUp = true;
                    break;
                }
            case 34:
                {
                    shouldThisQuestionShowUp = false;
                    break;
                }
            //are you sure we shouldn't add goblins?
            case 35:
                {
                    sureAboutGoblins = true;
                    break;
                }
            //bribe ability vs hacking ability;
            case 41:
                {
                    canBribe = true;
                    canHack = false;
                    break;
                }
            case 42:
                {
                    canBribe = false;
                    canHack = true;
                    break;
                }
            //cactus
            case 43:
                {
                    cactusHeight = true; //make it tall
                    break;
                }
            case 44:
                {
                    cactusHeight = false; //make it wide
                    break;
                }
            //did the player have fun
            case 51:
                {
                    //play confetti effect :)
                    break;
                }
            case 52:
                {
                    //play sad horn effect :(
                    break;
                }
            default:
                {
                    break;
                }
        }
    }

    //lock in responses from surveys
    void CheckSurveyInput()
    {
        switch (roundCounter)
        {
            case 1: //survey 1
                {
                    if (addMoreDesks)
                    {
                        moreDesks.gameObject.SetActive(true); //add em in
                    }
                    else
                    {
                        desks.gameObject.SetActive(false); //remove em all
                    }
                    if (floorColorChange)
                    {
                        //set floor color to chartreuse
                    }
                    else
                    {
                        //set floor color to aubergine
                    }
                    break;
                }
            case 2: //survey 2
                {
                    if (birdsOrBots)
                    {
                        animals.gameObject.SetActive(true);
                    }
                    else
                    {
                        machines.gameObject.SetActive(true);
                    }
                    if (addGoblins)
                    {
                        goblins.gameObject.SetActive(true);
                    }
                    break;
                }
            case 3: //survey 3
                {
                    if (whichImage)
                    {
                        skullImage.gameObject.SetActive(true);
                    }
                    else
                    {
                        backflipImage.gameObject.SetActive(true);
                    }
                    if (!sureAboutGoblins)
                    {
                        goblins.gameObject.SetActive(true);
                    }
                    break;
                }
            case 4: //survey 4
                {
                    if (cactusHeight)
                    {
                        tallCactus.gameObject.SetActive(true);
                        ogCactus.gameObject.SetActive(false);
                    }
                    else
                    {
                        wideCactus.gameObject.SetActive(true);
                        ogCactus.gameObject.SetActive(false);
                    }
                    break;
                }
            default:
                {
                    break;
                }
        }
    }

    void CloseSurvey()
    {
        survey1.SetActive(false);
        survey2.SetActive(false);
        survey3.SetActive(false);
        survey4.SetActive(false);
    }
}
