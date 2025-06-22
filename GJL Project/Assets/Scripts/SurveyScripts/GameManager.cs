using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{
    public int roundCounter;

    [SerializeField] GameObject player;
    Vector3 playerStartPos;

    [SerializeField] GameObject pauseMenu;


    //survey screens
    [SerializeField] GameObject survey1;
    [SerializeField] GameObject survey2;
    [SerializeField] GameObject survey3;
    [SerializeField] GameObject survey4;
    [SerializeField] GameObject endScreen;
    [SerializeField] GameObject surveyDoneButton;
    [SerializeField] GameObject sureAboutGoblinsQuestion;
    [SerializeField] GameObject theQuestionSurvey4;
    [SerializeField] GameObject funQuestionPos1;
    [SerializeField] GameObject funQuestionPos2;
    [SerializeField] AudioClip yippee;
    [SerializeField] AudioClip awMan;

    public GameObject baseDesks;
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
    public bool canHack; //code 42
    bool cactusHeight = true; //true makes cactus taller, false makes it wider; codes 43 and 44
    // reuse shouldThisQuestionShowUp variable?

    //survey 5 (stretch goal)

    //layers
    [SerializeField] GameObject desks;
    [SerializeField] GameObject moreDesks;
    [SerializeField] GameObject floorTiles;
    [SerializeField] GameObject animals;
    [SerializeField] GameObject machinesObjects;
    [SerializeField] GameObject goblins;
    [SerializeField] GameObject skullImage;
    [SerializeField] GameObject backflipImage;
    [SerializeField] GameObject cactus;
    [SerializeField] GameObject targetBridges;
    
    void Start()
    {
        roundCounter = 1;
        playerStartPos = player.transform.position;
        canBribe = false;
        canHack = false;

        pauseMenu.SetActive(false);

        //make sure all the things are set correctly
        survey1.SetActive(false);
        survey2.SetActive(false);
        survey3.SetActive(false);
        survey4.SetActive(false);
        endScreen.SetActive(false);
        surveyDoneButton.SetActive(false);
        sureAboutGoblinsQuestion.SetActive(false);
        theQuestionSurvey4.SetActive(false);
        funQuestionPos1.SetActive(false);
        funQuestionPos2.SetActive(false);

        desks.gameObject.SetActive(true);
        moreDesks.gameObject.SetActive(false);
        floorTiles.gameObject.SetActive(true);
        animals.gameObject.SetActive(false);
        machinesObjects.gameObject.SetActive(false);
        goblins.gameObject.SetActive(false);
        skullImage.gameObject.SetActive(false);
        backflipImage.gameObject.SetActive(false);
        cactus.gameObject.SetActive(true);
        targetBridges.gameObject.SetActive(false);

        floorTiles.GetComponent<Tilemap>().color = new Color(201, 201, 201, 255);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }

    public void ToMainMenu()
    {
        SceneManager.LoadScene("MainMenuScene");
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        player.GetComponent<CharacterMovement>().canMove = false;
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        player.GetComponent<CharacterMovement>().canMove = true;
    }

    public void QuitGame()
    {
        //is this needed for a web build?
    }

    public void ActivateBridges()
    {
        targetBridges.SetActive(true);
    }

    public void DeactivateBridges()
    {
        targetBridges.SetActive(false);
    }

    public void BeginSurvey()
    {
        surveyDoneButton.SetActive(true);
        player.GetComponent<CharacterMovement>().canMove = false;
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
                    endScreen.SetActive(true);
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
        player.GetComponent<CharacterMovement>().canMove = true;
    }

    public void RecieveSignal(int code)
    {
        switch (code)
        {
            //desks
            case 11:
                {
                    addMoreDesks = true;
                    baseDesks.SetActive(false);
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
                    AudioSource.PlayClipAtPoint(yippee, Camera.main.transform.position);
                    break;
                }
            case 52:
                {
                    //play sad horn effect :(
                    AudioSource.PlayClipAtPoint(awMan, Camera.main.transform.position);
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
                        floorTiles.GetComponent<Tilemap>().color = new Color32(177, 188, 85, 252);
                    }
                    else
                    {
                        //set floor color to aubergine
                        floorTiles.GetComponent<Tilemap>().color = new Color32(79, 51, 77, 252);
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
                        machinesObjects.gameObject.SetActive(true);
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
                    //player.GetComponent<Gun>().canShoot = true; rest in peace
                    break;
                }
            case 4: //survey 4
                {
                    if (cactusHeight)
                    {
                        cactus.gameObject.transform.localScale = new Vector3(2.0f, 4.0f, 1.0f);
                    }
                    else
                    {
                        cactus.gameObject.transform.localScale = new Vector3(4.0f, 2.0f, 1.0f);
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
        surveyDoneButton.SetActive(false);
        survey1.SetActive(false);
        survey2.SetActive(false);
        survey3.SetActive(false);
        survey4.SetActive(false);
    }
}
