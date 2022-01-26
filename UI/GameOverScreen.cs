using UnityEngine.Events;
using UnityEngine.UI;

public class GameOverScreen : Screen
{
    public event UnityAction RestartButtonClick;
    public override void Close()
    {
        canvasGroup.alpha = 0;
        button.interactable = false;
    }

    public override void Open()
    {
        canvasGroup.alpha = 1;
        button.GetComponent<Image>().raycastTarget = true;
        button.interactable = true;
    }

    protected override void OnButtonClicked()
    {
        RestartButtonClick?.Invoke();
    }

}
