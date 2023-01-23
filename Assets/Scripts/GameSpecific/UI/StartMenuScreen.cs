using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenuScreen : CanvasView
{
   
        #region Button-click Methods
        public void UIEVENT_StartGame()
        {
            GameManager.Instance.IsGameStarted = true;
        }
        #endregion
}
