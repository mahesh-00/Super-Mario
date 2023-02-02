using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Jump : MonoBehaviour, IPointerDownHandler,IPointerUpHandler
{
    private bool _isJumpPressed = false;
    public void OnPointerDown(PointerEventData eventData)
    {
        if(_isJumpPressed == false)
        {
            GameManager.Instance.OnJump?.Invoke(true);
            _isJumpPressed = true;
        }
       
    }

    public void OnPointerUp(PointerEventData eventData)
    {
       GameManager.Instance.OnJump?.Invoke(false);
       _isJumpPressed = false;
    }

    
}
