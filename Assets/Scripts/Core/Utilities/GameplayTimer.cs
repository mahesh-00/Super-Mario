using UnityEngine;

public class GameplayTimer : MonoBehaviour
{
    private float gameTime = 0;
    private bool isStartTime = false;

    private static GameplayTimer _instance;

    public static GameplayTimer Instance => _instance;


    private void Awake()
    {
        _instance = this;
    }

    private void OnDestroy()
    {
        if (_instance != null)
        {
            _instance = null;
        }
    }

    private void Update()
    {
        if (isStartTime)
        {
            gameTime += Time.deltaTime;
        }
    }

    public void StartTimer()
    {
        isStartTime = true;
    }

    public void StopTimer()
    {
        isStartTime = false;
        gameTime = 0;
    }

    public string GetTime()
    {
        float minutes = Mathf.FloorToInt(gameTime / 60);
        float seconds = Mathf.FloorToInt(gameTime % 60);
        string time = string.Format("{0:00}:{1:00}", minutes, seconds);
        return time;
    }

}
