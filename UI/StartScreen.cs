using UnityEngine;
using UnityEngine.Events;

public class StartScreen : Screen
{
    public event UnityAction PlayButtonClick;
    public override void Close()
    {
        canvasGroup.alpha = 0;
        button.gameObject.SetActive(false);
        button.interactable = false;
    }

    public override void Open()
    {
        canvasGroup.alpha = 1;
        button.gameObject.SetActive(true);
        button.interactable = true;
    }

    protected override void OnButtonClicked()
    {
        PlayButtonClick?.Invoke();
    }
}
