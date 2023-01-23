using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class GameScreen : CanvasView
{
    [SerializeField]private TextMeshProUGUI _livesRemainingText;
    // Start is called before the first frame update
    void Start()
    {
        UIManager.Instance.OnLivesUpdated+= UpdateLivesRemainingUI;
    }

    private void UpdateLivesRemainingUI(int obj)
    {
        _livesRemainingText.text = "Lives : "+ obj;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
