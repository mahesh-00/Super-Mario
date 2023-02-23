using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    //[SerializeField] private float _gravity;
    [SerializeField] private Vector2 _velocity;
    [SerializeField] private bool _isWalkingLeft = true;
    [SerializeField] private Transform _groundRayTF;
    private bool _isGrounded = false;
    private Animator _enemyAnimator;
    public Action OnEnemyKilled;
    [SerializeField] LayerMask _layerMask;
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
        OnEnemyKilled += KillEnemy;
    }
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _enemyAnimator = GetComponent<Animator>();
        //Fall();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        UpdateEnemyPosition();

        // Cast a ray downward from the enemy's position
        RaycastHit2D hitGroundLeft = Physics2D.Raycast(_groundRayTF.position - new Vector3(1, 0, 0), Vector2.down);
        RaycastHit2D hitGroundRight = Physics2D.Raycast(_groundRayTF.position + new Vector3(1, 0, 0), -Vector2.up);
        Debug.DrawRay(_groundRayTF.position - new Vector3(1, 0, 0), -Vector2.up * hitGroundLeft.distance);

        if (hitGroundLeft.collider == null)
            _isWalkingLeft = _isWalkingLeft ? false : true;

        if (hitGroundRight.collider == null)
            _isWalkingLeft = _isWalkingLeft ? false : true;

    }

    void OnDisable()
    {
        OnEnemyKilled -= KillEnemy;
    }

    // private Vector3 CheckGround(Vector3 pos)
    // {
    //     Vector2 originLeft = new Vector2(pos.x - 0.5f + 0.2f, pos.y - .5f);
    //     Vector2 originRight = new Vector2(pos.x + 0.5f - 0.2f, pos.y - .5f);
    //     RaycastHit2D groundLeft = Physics2D.Raycast(originLeft, Vector2.down, _velocity.y * Time.deltaTime, _layerMask);
    //     RaycastHit2D groundRight = Physics2D.Raycast(originRight, Vector2.down, _velocity.y * Time.deltaTime, _layerMask);
    //     Debug.DrawRay(originLeft, Vector2.down * _velocity.y * Time.deltaTime, Color.black, 1f);
    //     if (groundLeft.collider != null || groundRight.collider != null)
    //     {
    //         RaycastHit2D rayHit = groundLeft;
    //         if (groundLeft)
    //             rayHit = groundLeft;
    //         else
    //             rayHit = groundRight;
    //         pos.y = rayHit.collider.bounds.center.y + rayHit.collider.bounds.size.y / 2 + .5f;
    //         return pos;
    //     }
    //     return Vector3.zero;

    // }

    private void UpdateEnemyPosition()
    {

        Vector3 pos = transform.localPosition;
        Vector3 scale = transform.localScale;

        // if(state == EnemyState.falling)
        // {
        //     pos.y += _velocity.y * Time.deltaTime;
        //     _velocity.y -= _gravity * Time.deltaTime;
        // }

        if (state == EnemyState.walking)
        {
            if (_isWalkingLeft)
            {
                //_rb.MovePosition(_rb.position + new Vector2(3,0) * Time.fixedDeltaTime);
                pos.x -= _velocity.x * Time.deltaTime;
                scale.x = -1;
            }
            else
            {
                //_rb.MovePosition(_rb.position + new Vector2(-3,0) * Time.fixedDeltaTime);
                pos.x += _velocity.x * Time.deltaTime;
                scale.x = 1;
            }
        }
        transform.localPosition = pos;
        transform.localScale = scale;
    }



    // void Fall()
    // {
    //     _velocity.y = 0;
    //     state = EnemyState.falling;
    //     _grounded = true;
    // }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Debug.Log("Entered collision "+collision.gameObject.name);
        _isWalkingLeft = _isWalkingLeft ? false : true;
        if (collision.gameObject.CompareTag(CONSTANTS.GROUND))
        {
            _isGrounded = true;

        }

    }

    void OnCollisionExit2D(Collision2D collision)
    {
        //Debug.Log(collision.gameObject.name);
        if (collision.gameObject.CompareTag(CONSTANTS.GROUND))
        {
            _isGrounded = false;
            _isWalkingLeft = _isWalkingLeft ? false : true;
        }

    }
    void OnTriggerExit2D(Collider2D collision)
    {

    }

    private void KillEnemy()
    {
        state = EnemyState.dead;
        _enemyAnimator.SetBool("isCrushed", true);
        StartCoroutine(WaitForEnemyToDie());

    }

    IEnumerator WaitForEnemyToDie()
    {
        yield return new WaitForSeconds(0.1f);
        gameObject.SetActive(false);
    }
}