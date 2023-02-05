using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    //[SerializeField] private float _gravity;
    [SerializeField] private Vector2 _velocity;
    [SerializeField] private bool _isWalkingLeft = true;
    private Animator _enemyAnimator;
    public Action OnEnemyKilled;
    //private bool _grounded = false;

    private enum EnemyState
    {
        walking,
        dead
    }
    private EnemyState state = EnemyState.walking;
    private Rigidbody2D _rb;

    void OnEnable()
    {
        OnEnemyKilled+= KillEnemy;
    }
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
       _enemyAnimator = GetComponent<Animator>();
        enabled = false;
        //Fall();
    }




    // Update is called once per frame
    void Update()
    {
        UpdateEnemyPosition();
    }

    void OnDisable()
    {
        OnEnemyKilled-= KillEnemy;
    }

    private void UpdateEnemyPosition()
     {
    //     if(state != EnemyState.dead)
    //     {
            Vector3 pos = transform.localPosition;
            Vector3 scale = transform.localScale;

            // if(state == EnemyState.falling)
            // {
            //     pos.y += _velocity.y * Time.deltaTime;
            //     _velocity.y -= _gravity * Time.deltaTime;
            // }

            if(state == EnemyState.walking)
            {
                if(_isWalkingLeft)
                {

                    pos.x -= _velocity.x * Time.deltaTime;
                    scale.x = -1;
                }
                else
                {
                    pos.x += _velocity.x * Time.deltaTime;
                    scale.x = 1;
                }
            }
            transform.localPosition = pos;
            transform.localScale = scale;
        //}
    }

    void OnBecameVisible()
    {
        enabled = true;
    }

    // void Fall()
    // {
    //     _velocity.y = 0;
    //     state = EnemyState.falling;
    //     _grounded = true;
    // }

    void OnCollisionEnter2D(Collision2D collision)
    {
        _isWalkingLeft = _isWalkingLeft?false:true;
    }
    
    private void KillEnemy()
    {
        state = EnemyState.dead;
       _enemyAnimator.SetBool("isCrushed",true);
       StartCoroutine(WaitForEnemyToDie());

    }

    IEnumerator WaitForEnemyToDie()
    {
        yield return new WaitForSeconds(0.1f);
        gameObject.SetActive(false);
    }
}
