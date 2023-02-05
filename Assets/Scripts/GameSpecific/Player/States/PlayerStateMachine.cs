using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class PlayerStateMachine : MonoBehaviour
{
    private Rigidbody2D _rb;
    public Rigidbody2D Rb => _rb;
    private PlayerBaseState _currentState;
    private PlayerStateFactory _playerStateFactory;
    public PlayerStateFactory PlayerStateFactory;
    public PlayerBaseState CurrentState { get { return _currentState; } set { _currentState = value; } }

    public bool IsGrounded;
    private bool _isWalkingLeft;
    public bool IsWalkingLeft { get { return _isWalkingLeft; } set { _isWalkingLeft = value; } }
    private bool _isWalkingRight;
    public bool IsWalkingRight => _isWalkingRight;
    private bool _isJumping;
    public bool IsJumping => _isJumping;
    public bool AllowtoJump;
    private CharacterInputAction _characterInputMap;
    [SerializeField] private PlayerData PlayerData;
    public float WalkSpeed;
    public float JumpSpeed;

   public PlayerStates PlayerState;
   public enum PlayerStates
   {
     Idle,
     LeftWalk,
     RightWalk,
     Jump 
   }
    public Action<PlayerStates> OnEnterState;
    public CinemachineVirtualCamera _cinemachineVirtualCamera;

    // Start is called before the first frame update
    void Start()
    {

        _characterInputMap = new CharacterInputAction();
        _characterInputMap.Enable();
        _rb = GetComponent<Rigidbody2D>();
        _cinemachineVirtualCamera = FindObjectOfType<CinemachineVirtualCamera>();
        WalkSpeed = PlayerData.WalkSpeed;
        JumpSpeed = PlayerData.jumpSpeed;
        _characterInputMap.Movement.WalkLeft.performed += (InputAction.CallbackContext obj) =>
        {
            _isWalkingLeft = true;
            // _cinemachineVirtualCamera.enabled = false;
        };
        _characterInputMap.Movement.WalkLeft.canceled += (InputAction.CallbackContext obj) =>
        {
            _isWalkingLeft = false;
            //_cinemachineVirtualCamera.enabled = true;
        };
        _characterInputMap.Movement.WalkRight.performed += (InputAction.CallbackContext obj) => _isWalkingRight = true;
        _characterInputMap.Movement.WalkRight.canceled += (InputAction.CallbackContext obj) => _isWalkingRight = false;
        _characterInputMap.Movement.Jump.performed += (InputAction.CallbackContext obj) => _isJumping = true;
        _characterInputMap.Movement.Jump.canceled += (InputAction.CallbackContext obj) => _isJumping = false;
        _playerStateFactory = new PlayerStateFactory(this);
        _currentState = _playerStateFactory.Grounded();
        _currentState.EnterState();

        GameManager.Instance.OnPlayerKilled += RespawnPlayer;
        GameManager.Instance.OnLeftWalk += (bool _isWalking) => _isWalkingLeft = _isWalking;
        GameManager.Instance.OnRightWalk += (bool _isWalking) => _isWalkingRight = _isWalking;
        GameManager.Instance.OnJump += (bool _isJumpPressed) => _isJumping = _isJumpPressed;

    }

    void OnDisable()
    {
        _characterInputMap.Movement.WalkRight.performed -= (InputAction.CallbackContext obj) => _isWalkingRight = true;
        _characterInputMap.Movement.WalkRight.canceled -= (InputAction.CallbackContext obj) => _isWalkingRight = false;
        _characterInputMap.Movement.Jump.performed -= (InputAction.CallbackContext obj) => _isJumping = true;
        _characterInputMap.Movement.Jump.canceled -= (InputAction.CallbackContext obj) => _isJumping = false;
        GameManager.Instance.OnPlayerKilled -= RespawnPlayer;
        GameManager.Instance.OnLeftWalk -= (bool _isWalking) => _isWalkingLeft = _isWalking;
        GameManager.Instance.OnRightWalk -= (bool _isWalking) => _isWalkingRight = _isWalking;
        GameManager.Instance.OnJump -= (bool _isJumpPressed) => _isJumping = _isJumpPressed;
    }



    // Update is called once per frame
    void FixedUpdate()
    {
        _currentState.UpdateStates();
    }

    private void RespawnPlayer()
    {
        transform.position = CheckPoint.LastCheckPointPos;
    }

}
