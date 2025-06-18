using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SurveyButton : Button
{
    bool selected;
    Image image;

    protected override void Start()
    {
        base.Start();
        image = GetComponent<Image>();
    }

    public override void OnPointerClick(PointerEventData eventData)
    {
        base.OnPointerClick(eventData);
        selected = true;
        image.color = Color.cyan;
        GetComponent<ButtonSignals>().sendSignal();
    }

    public bool isSelected()
    {
        return selected;
    }

    public void Deselect()
    {
        selected = false;
        image.color = Color.white;
    }
}
