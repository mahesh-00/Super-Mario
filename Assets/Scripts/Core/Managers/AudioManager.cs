using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    #region Static fields
    private static AudioManager _instance;
    #endregion

    #region Properties
    public static AudioManager Instance => _instance;
    #endregion

    [SerializeField] private AudioSource _ambientAudioSource;
    [SerializeField] private AudioSource _gameScreenAudioSource;
    [SerializeField] private AudioClip _bgMusic;
    [SerializeField] private AudioClip _coinCollectedSound;
    [SerializeField] private AudioClip _jumpSound;
    [SerializeField] private AudioClip _enemyKilledSound;
    [SerializeField] private AudioClip _brickBreakSound;
    [SerializeField] private AudioClip _brickHitSound;
    [SerializeField] private AudioClip _flagTriggerSound;
    [SerializeField] private AudioClip _winSound;
    [SerializeField] private AudioClip _dieSound;
    [SerializeField] private AudioClip _buttonClickSound;

    public Action OnEnemyKilled;
    public Action OnBrickBreaked;
    public Action OnBrickHit;

    void Awake()
    {
        if (_instance == null)
            _instance = this;
        else
            Destroy(this);
    }

    void Start()
    {
        GameManager.Instance.OnGameStarted += PlayBgMusic;
        GameManager.Instance.OnCoinCollected += () => _gameScreenAudioSource.PlayOneShot(_coinCollectedSound);
        GameManager.Instance.OnJump += (bool _isJumping) =>
        {
            if (_isJumping)
                _gameScreenAudioSource.PlayOneShot(_jumpSound);
        };
        GameManager.Instance.OnPlayerKilled += () =>
        {
            _gameScreenAudioSource.PlayOneShot(_dieSound);
            _ambientAudioSource.Stop();
        };
        GameManager.Instance.OnWinPointReached += () =>
        {
            _gameScreenAudioSource.PlayOneShot(_flagTriggerSound);
            _ambientAudioSource.Stop();
        };
        GameManager.Instance.OnCastleReached += () => _gameScreenAudioSource.PlayOneShot(_winSound);
        GameManager.Instance.OnGameCompleted += () => _ambientAudioSource.Stop();
        OnEnemyKilled += () => _gameScreenAudioSource.PlayOneShot(_enemyKilledSound);
        OnBrickBreaked += () => _gameScreenAudioSource.PlayOneShot(_brickBreakSound);
        OnBrickHit += () => _gameScreenAudioSource.PlayOneShot(_brickHitSound);
    }

    void OnDisable()
    {
        GameManager.Instance.OnGameStarted -= PlayBgMusic;
        GameManager.Instance.OnCoinCollected -= () => _gameScreenAudioSource.PlayOneShot(_coinCollectedSound);
        GameManager.Instance.OnJump -= (bool _isJumping) =>
       {
           if (_isJumping)
               _gameScreenAudioSource.PlayOneShot(_jumpSound);
       };
        GameManager.Instance.OnPlayerKilled -= () =>
        {
            _gameScreenAudioSource.PlayOneShot(_dieSound);
            _ambientAudioSource.Stop();
        };
        GameManager.Instance.OnWinPointReached -= () =>
      {
          _gameScreenAudioSource.PlayOneShot(_flagTriggerSound);
          _ambientAudioSource.Stop();
      };
        GameManager.Instance.OnCastleReached -= () => _gameScreenAudioSource.PlayOneShot(_winSound);
        GameManager.Instance.OnGameCompleted -= () => _ambientAudioSource.Stop();
        OnEnemyKilled -= () => _gameScreenAudioSource.PlayOneShot(_enemyKilledSound);
        OnBrickBreaked -= () => _gameScreenAudioSource.PlayOneShot(_brickBreakSound);
        OnBrickHit -= () => _gameScreenAudioSource.PlayOneShot(_brickHitSound);
    }

    private async void PlayBgMusic()
    {
        await Task.Delay(800);
        _ambientAudioSource.clip = _bgMusic;
        _ambientAudioSource.Play();
    }

    public void UIEVENT_OnButtonClick()
    {
        _gameScreenAudioSource.clip = _buttonClickSound;
        _gameScreenAudioSource.Play();
    }

    public void OnGamePaused(bool isPaused)
    {
        if (isPaused)
            _ambientAudioSource.Pause();
        else
            _ambientAudioSource.Play();
    }

}
