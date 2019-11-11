using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public delegate void PlayerEventDelegate(GameObject level);
    public event PlayerEventDelegate PlayerLeft;
    public event PlayerEventDelegate PlayerEntered;
    
    private MapProperties _properties;
    
    private List<GameObject> _prefabs = new List<GameObject>();
    private Dictionary<Vector2, GameObject> _levels = new Dictionary<Vector2, GameObject>();
    
    private void Start()
    {
        _properties = GetComponent<MapProperties>();
        
        LoadLevels();
    }

    private void LoadLevels()
    {
        _prefabs.Add(Resources.Load<GameObject>("levels/level_00"));
        _prefabs.Add(Resources.Load<GameObject>("levels/level_01"));
        _prefabs.Add(Resources.Load<GameObject>("levels/level_10"));

        _levels.Add(new Vector2(0, 0), Instantiate(_prefabs[0], transform, true));
        _levels.Add(new Vector2(0, 1), Instantiate(_prefabs[1], transform, true));
        _levels.Add(new Vector2(1, 0), Instantiate(_prefabs[2], transform, true));
        
        foreach (var level in _levels)
        {
            level.Value.transform.localScale = new Vector3(_properties.levelWidth, _properties.levelHeight, 1);
            level.Value.transform.position = new Vector3(level.Key.x * _properties.levelWidth, level.Key.y * _properties.levelHeight, 0);
            level.Value.SetActive(false);
        }

        _levels[new Vector2(0, 0)].SetActive(true);
    }

    private bool checkForCharacter = false;
    public void notify(GameObject from)
    {
        PlayerLeft?.Invoke(from);
        from.SetActive(false);

        var position = GetCharacterPosition();

        if (_levels.ContainsKey(position))
        {
            var level = _levels[position];
            level.SetActive(true);
            PlayerEntered?.Invoke(level);
        }
        else
        {
            checkForCharacter = true;
        }
    }

    private Vector2 GetCharacterPosition()
    {
        var charPos = _properties.character.transform.position;
        var pos = new Vector2(Mathf.Round(charPos.x / _properties.levelWidth), Mathf.Round(charPos.y / _properties.levelHeight));

        return pos;
    } 

    private void Update()
    {
        if (!checkForCharacter) return;
        
        var position = GetCharacterPosition();
        if (!_levels.ContainsKey(position)) return;

        var level = _levels[position];
        level.SetActive(true);
        PlayerEntered?.Invoke(level);

        checkForCharacter = false;
    }
}
