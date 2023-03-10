using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Brick : MonoBehaviour
{
    private bool _isBrickHit = false;
    private Animator _blockAnimator;
    private Vector3 _originalPos;
    [SerializeField] private ParticleSystem _breakBrickVFX;
    public enum BrickState
    {
        solid,
        breakable
    }
    public BrickState brickState;


    void Start()
    {
        //_blockAnimator = GetComponent<Animator>();
        _originalPos = transform.position;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(CONSTANTS.PLAYER))
        {
            if (collision.transform.position.y < transform.position.y)
            {
                HandleBrickHit();
            }

        }
    }

    private void HandleBrickHit()
    {
        switch (brickState)
        {
            case BrickState.solid:
                AudioManager.Instance.OnBrickHit?.Invoke();
                transform.DOMove(transform.position + new Vector3(0, 0.3f, 0), 0.15f).onComplete += () =>
                {
                    transform.DOMove(_originalPos, 0.15f);
                };

                //Debug.Log("solid");
                break;
            case BrickState.breakable:
                Instantiate(GameManager.Instance.LevelData.Coin, transform.position + new Vector3(0, 1.3f, 0), Quaternion.identity);
                AudioManager.Instance.OnBrickBreaked?.Invoke();
                GameObject vfx = Instantiate(_breakBrickVFX.gameObject, transform.position, Quaternion.identity);
                Destroy(vfx, 1);
                Destroy(this.gameObject);
                //Debug.Log("breakable");
                break;

        }
    }

}
