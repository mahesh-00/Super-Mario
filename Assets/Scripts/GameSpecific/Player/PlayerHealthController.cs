using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    private PlayerStateMachine _playerStateMachine;
    private int _noOfLives = 3;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.OnEnemyCollision+=OnEnemyCollision;
        _playerStateMachine = GetComponent<PlayerStateMachine>();
        UIManager.Instance.OnLivesUpdated?.Invoke(_noOfLives);
    }

    void OnDisable()
    {
         GameManager.Instance.OnEnemyCollision-=OnEnemyCollision;
    }

    private void OnEnemyCollision()
    {
        _noOfLives-=1;
        UIManager.Instance.OnLivesUpdated?.Invoke(_noOfLives);
        if(_noOfLives < 1)
        {
            GameManager.Instance.OnPlayerDead?.Invoke();
        }
        Debug.Log(CheckPoint.LastCheckPointPos);
    }
}
