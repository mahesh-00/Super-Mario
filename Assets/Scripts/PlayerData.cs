using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player Data", menuName = "Super Mario/PlayerData")]
public class PlayerData : ScriptableObject
{
    [SerializeField] private float _walkSpeed;
    [SerializeField] private float _jumpSpeed;
    public float WalkSpeed => _walkSpeed;
    public float jumpSpeed=> _jumpSpeed;
}
