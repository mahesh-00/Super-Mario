using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    private PlayerStateMachine _playerStateMachine;
    private int _noOfLives = 1;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.OnPlayerKilled+=OnEnemyCollision;
        _playerStateMachine = GetComponent<PlayerStateMachine>();
        UIManager.Instance.OnLivesUpdated?.Invoke(_noOfLives);
    }

    void OnDisable()
    {
        GameManager.Instance.OnPlayerKilled-=OnEnemyCollision;
    }

    private void OnEnemyCollision()
    {
        _noOfLives-=1;
        UIManager.Instance.OnLivesUpdated?.Invoke(_noOfLives);
        if(_noOfLives < 1)
        {
            GameManager.Instance.OnPlayerDead?.Invoke();
        }
    }
}
