using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level Data", menuName = "Super Mario/LevelData", order = 0)]
public class LevelData : ScriptableObject
{
    [SerializeField] private List<MapData> _levelPrefabs;
    [SerializeField] private GameObject _playerPrefab;

    [HideInInspector] public List<MapData> LevelPrefabs => _levelPrefabs;
    [HideInInspector] public GameObject PlayerPrefab => _playerPrefab;

    [Serializable]
    public struct MapData
    {
        public GameObject LevelPrefab;
        public PolygonCollider2D BoundShape2D;
    }

}
