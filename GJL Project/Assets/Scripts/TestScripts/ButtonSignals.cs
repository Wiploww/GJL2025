using UnityEngine;
using UnityEngine.UI;

public class ButtonSignals : MonoBehaviour
{
    [SerializeField] Button partner;
    [SerializeField] GameObject gameManager;
    [SerializeField] int eventCode;

    void Start()
    {
        
    }

    public void sendSignal()
    {
        //send ping w/ event code to game manager
        gameManager.GetComponent<TestGameManager>().RecieveSignal(eventCode);

        //make sure partner button gets deselected, if applicable
        if (partner.GetComponent<SurveyButton>().isSelected())
        {
            partner.GetComponent<SurveyButton>().Deselect();
        }
    }
}
