using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RightWalk : MonoBehaviour, IPointerDownHandler,IPointerUpHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        GameManager.Instance.OnRightWalk?.Invoke(true);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
       GameManager.Instance.OnRightWalk?.Invoke(false);
    }

    
}
