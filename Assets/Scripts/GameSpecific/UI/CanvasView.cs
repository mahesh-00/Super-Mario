using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(CanvasGroup))]
public abstract class CanvasView : MonoBehaviour
{
    #region Edior-Assigned variables
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private float fadeDuration = 1.0f;
    #endregion

    #region Monobehaviour
    private void Start()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
    }
    #endregion

    #region Methods
    public virtual void ShowView(bool isShow)
    {
        if (isShow)
        {
            gameObject.SetActive(true);
          // _canvasGroup.DOFade(1, fadeDuration);
        }
        else
        {
            gameObject.SetActive(false);
           //_canvasGroup.DOFade(0, fadeDuration).OnComplete(() => gameObject.SetActive(false));
        }
    }
    #endregion
}

