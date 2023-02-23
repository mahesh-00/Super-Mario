using System;
using System.Collections;
using System.Collections.Generic;
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
    [SerializeField] private AudioClip _flagTriggerSound;
    [SerializeField] private AudioClip _winSound;
    [SerializeField] private AudioClip _dieSound;

    public Action OnEnemyKilled;
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
        GameManager.Instance.OnPlayerKilled +=()=>
        {
            _gameScreenAudioSource.PlayOneShot(_dieSound);
            _ambientAudioSource.Stop();
        }; 
        GameManager.Instance.OnWinPointReached += () => _gameScreenAudioSource.PlayOneShot(_flagTriggerSound);
        GameManager.Instance.OnCastleReached += () => _gameScreenAudioSource.PlayOneShot(_winSound);
        GameManager.Instance.OnGameCompleted += () => _ambientAudioSource.Stop();
        OnEnemyKilled += () => _gameScreenAudioSource.PlayOneShot(_enemyKilledSound);
        OnBrickHit += () => _gameScreenAudioSource.PlayOneShot(_brickBreakSound);
    }

    void OnDisable()
    {
        GameManager.Instance.OnGameStarted-= PlayBgMusic;
        GameManager.Instance.OnCoinCollected-= () => _gameScreenAudioSource.PlayOneShot(_coinCollectedSound);
          GameManager.Instance.OnJump-= (bool _isJumping) =>
         {
            if(_isJumping)
                 _gameScreenAudioSource.PlayOneShot(_jumpSound);
         };
        GameManager.Instance.OnPlayerKilled -= () =>
        {
            _gameScreenAudioSource.PlayOneShot(_dieSound);
            _ambientAudioSource.Stop();
        } ;
        GameManager.Instance.OnWinPointReached -= () => _gameScreenAudioSource.PlayOneShot(_flagTriggerSound);
        GameManager.Instance.OnCastleReached -= () => _gameScreenAudioSource.PlayOneShot(_winSound);
        GameManager.Instance.OnGameCompleted -= () => _ambientAudioSource.Stop();
        OnEnemyKilled -= () => _gameScreenAudioSource.PlayOneShot(_enemyKilledSound);
        OnBrickHit -= () => _gameScreenAudioSource.PlayOneShot(_brickBreakSound);
    }

    private void PlayBgMusic()
    {
        _ambientAudioSource.clip = _bgMusic;
        _ambientAudioSource.Play();
    }

     private void PlayGameSound(AudioClip _audioClip)
     {
        _gameScreenAudioSource.clip = _coinCollectedSound;
        _gameScreenAudioSource.Play();
     }

}