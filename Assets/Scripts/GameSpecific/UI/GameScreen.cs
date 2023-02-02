using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using System;

public class GameScreen : CanvasView
{
    [SerializeField]private TextMeshProUGUI _livesRemainingText;
    // Start is called before the first frame update
    void OnEnable()
    {
        UIManager.Instance.OnLivesUpdated+= UpdateLivesRemainingUI;
    }

    void OnDisable()
    {
        UIManager.Instance.OnLivesUpdated-= UpdateLivesRemainingUI;
    }

    private void UpdateLivesRemainingUI(int obj)
    {
        _livesRemainingText.text = "Lives : "+ obj;
    }

}
