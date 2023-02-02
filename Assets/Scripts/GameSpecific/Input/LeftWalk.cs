using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LeftWalk : MonoBehaviour, IPointerDownHandler,IPointerUpHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        GameManager.Instance.OnLeftWalk?.Invoke(true);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
       GameManager.Instance.OnLeftWalk?.Invoke(false);
    }

    
}
