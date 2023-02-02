using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
   [SerializeField] private static Vector2 _lastCheckPointPos;
    public static Vector2 LastCheckPointPos => _lastCheckPointPos;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    void OnTriggerEnter2D(Collider2D collider2D)
    {
        _lastCheckPointPos = transform.position;
    }
}
