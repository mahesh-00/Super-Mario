using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerStateMachine : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;
    public Rigidbody2D Rb => _rb;
    private PlayerBaseState _currentState;
    private PlayerStateFactory _playerStateFactory;
    public PlayerBaseState CurrentState { get { return _currentState; } set { _currentState = value; } }
    public bool IsGrounded;
    private bool _isWalkingLeft;
    public bool IsWalkingLeft => _isWalkingLeft;
    private bool _isWalkingRight;
    public bool IsWalkingRight => _isWalkingRight;
    private bool _isJumping;
    public bool IsJumping => _isJumping;
    private CharacterInputAction _characterInputMap;
    public CharacterInputAction CharacterInputMap => _characterInputMap;
    // Start is called before the first frame update
    void Start()
    {
        _characterInputMap = new CharacterInputAction();
        _characterInputMap.Enable();
        _rb = GetComponent<Rigidbody2D>();
        _playerStateFactory = new PlayerStateFactory(this);
        _currentState = _playerStateFactory.Grounded();
        _currentState.EnterState();
        _characterInputMap.Movement.WalkLeft.performed += (InputAction.CallbackContext obj) => _isWalkingLeft = true;
        _characterInputMap.Movement.WalkLeft.canceled += (InputAction.CallbackContext obj) => _isWalkingLeft = false;
        _characterInputMap.Movement.WalkRight.performed += (InputAction.CallbackContext obj) => _isWalkingRight = true;
        _characterInputMap.Movement.WalkRight.canceled += (InputAction.CallbackContext obj) => _isWalkingRight = false;
        _characterInputMap.Movement.Jump.performed += (InputAction.CallbackContext obj) => _isJumping = true;
        _characterInputMap.Movement.Jump.canceled += (InputAction.CallbackContext obj) => _isJumping = false;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _currentState.UpdateStates();
    }
}
