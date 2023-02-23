using UnityEngine;

public class StartMenuScreen : CanvasView
{

    #region Button-click Methods
    public void UIEVENT_StartGame()
    {
        GameManager.Instance.OnGameStarted?.Invoke();
    }

    public void UIEVENT_Exit()
    {
        Application.Quit();
    }
    #endregion
}
