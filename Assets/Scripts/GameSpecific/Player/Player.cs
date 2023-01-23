using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private static Player _instance;
    private PlayerAnimationController _playerAnimationController;
    private PlayerPhysicsController _playerPhysicsController;

    void Awake()
    {
        if(_instance == null)
            _instance = this;
        else
            Destroy(this);
    }
    // Start is called before the first frame update
    void Start()
    {
        _playerAnimationController = GetComponent<PlayerAnimationController>();
        _playerPhysicsController = GetComponent<PlayerPhysicsController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
