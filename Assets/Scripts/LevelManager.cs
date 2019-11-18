using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public delegate void PlayerEventDelegate(GameObject level);
    public event PlayerEventDelegate PlayerLeft;
    public event PlayerEventDelegate PlayerEntered;
    
    private MapProperties _properties;
    
    private List<GameObject> _prefabs = new List<GameObject>();
    private Dictionary<Vector2Int, GameObject> _levels = new Dictionary<Vector2Int, GameObject>();
    
    private void Start()
    {
        _properties = GetComponent<MapProperties>();
        
        CreateMap();
    }

    private void LoadPrefabs()
    {
        _prefabs.Add(Resources.Load<GameObject>("levels/level_00"));
        _prefabs.Add(Resources.Load<GameObject>("levels/level_01"));
        _prefabs.Add(Resources.Load<GameObject>("levels/level_02"));
        _prefabs.Add(Resources.Load<GameObject>("levels/level_10"));
        _prefabs.Add(Resources.Load<GameObject>("levels/level_11"));
        _prefabs.Add(Resources.Load<GameObject>("levels/level_12"));
        _prefabs.Add(Resources.Load<GameObject>("levels/level_20"));
        _prefabs.Add(Resources.Load<GameObject>("levels/level_21"));
        _prefabs.Add(Resources.Load<GameObject>("levels/level_22"));
    }

    private void GenerateMap()
    {
        _levels.Add(new Vector2Int(-1, 1), Instantiate(_prefabs[0], transform, true));
        _levels.Add(new Vector2Int(0, 1), Instantiate(_prefabs[1], transform, true));
        _levels.Add(new Vector2Int(1, 1), Instantiate(_prefabs[2], transform, true));
        _levels.Add(new Vector2Int(-1, 0), Instantiate(_prefabs[3], transform, true));
        _levels.Add(new Vector2Int(0, 0), Instantiate(_prefabs[4], transform, true));
        _levels.Add(new Vector2Int(1, 0), Instantiate(_prefabs[5], transform, true));
        _levels.Add(new Vector2Int(-1, -1), Instantiate(_prefabs[6], transform, true));
        _levels.Add(new Vector2Int(0, -1), Instantiate(_prefabs[7], transform, true));
        _levels.Add(new Vector2Int(1, -1), Instantiate(_prefabs[8], transform, true));
    }
    
    private void CreateMap()
    {
        LoadPrefabs();
        GenerateMap();

        foreach (var level in _levels)
        {
            level.Value.transform.localScale = new Vector3(_properties.levelWidth, _properties.levelHeight, 1);
            level.Value.transform.position = new Vector3(level.Key.x * _properties.levelWidth, level.Key.y * _properties.levelHeight, 0);
            level.Value.SetActive(false);
        }

        ActivateLevels(new Vector2Int(0, 0), new Vector2Int(0, 0));
    }

    private void ActivateLevels(Vector2Int from, Vector2Int to)
    {
        for (var y = -1; y <= 1; y++)
        {
            for (var x = -1; x <= 1; x++)
            {
                var current = new Vector2Int(x, y);
                
                if(_levels.ContainsKey(from + current)) _levels[from + current].SetActive(false);
            }
        }
        
        for (var y = -1; y <= 1; y++)
        {
            for (var x = -1; x <= 1; x++)
            {
                var current = new Vector2Int(x, y);
                
                if(_levels.ContainsKey(to + current)) _levels[to + current].SetActive(true);
            }
        }
    }

    private bool _checkForCharacter = false;
    private Vector2Int _prevLevelIndex;
    public void notify(GameObject from)
    {
        PlayerLeft?.Invoke(from);
        _prevLevelIndex = GetIndexFromPosition(from.transform.position);

        var positionIndex = GetIndexFromPosition(_properties.character.transform.position);

        if (_levels.ContainsKey(positionIndex))
        {
            var level = _levels[positionIndex];
            ActivateLevels(_prevLevelIndex, positionIndex);
            PlayerEntered?.Invoke(level);
        }
        else
        {
            _checkForCharacter = true;
        }
    }

    private Vector2Int GetIndexFromPosition(Vector2 position)
    {
        var pos = Vector2Int.RoundToInt(new Vector2(position.x / _properties.levelWidth, position.y / _properties.levelHeight));

        return pos;
    } 

    private void Update()
    {
        if (!_checkForCharacter) return;
        
        var position = GetIndexFromPosition(_properties.character.transform.position);
        if (!_levels.ContainsKey(position)) return;

        var level = _levels[position];
        ActivateLevels(_prevLevelIndex, position);
        PlayerEntered?.Invoke(level);

        _checkForCharacter = false;
    }
}
