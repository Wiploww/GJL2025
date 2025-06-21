using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject intro;

    void Start()
    {
        mainMenu.SetActive(true);
        intro.SetActive(false);
    }

    public void Intro()
    {
        mainMenu.SetActive(false);
        intro.SetActive(true);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("MainGameScene");
    }
}
