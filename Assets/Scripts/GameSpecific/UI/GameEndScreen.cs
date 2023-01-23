using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEndScreen : CanvasView
{
    public void UIEVENT_PlayAgain()
    {
        GameManager.Instance.OnPlayAgain?.Invoke(GameManager.GameState.StartMenuState);
    }

    public void UIEVENT_Exit()
    {
        Application.Quit();
    }
}
