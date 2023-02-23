using DG.Tweening;
using UnityEngine;

public class WinFlag : MonoBehaviour
{

    private void Awake() 
    {
        GameManager.Instance.OnWinPointReached+= PlayWinAnimation;
    }

    private void OnDestroy()
    {
          GameManager.Instance.OnWinPointReached-= PlayWinAnimation;
    }
   
    void PlayWinAnimation()
    {
        transform.DOMove(transform.position - new Vector3(0,7,0),1.5f).onComplete+= () => GameManager.Instance.OnCastleReached?.Invoke();
    }
}
