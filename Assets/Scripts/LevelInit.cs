using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelInit : MonoBehaviour
{
    public Vector2 position;

    private LevelManager _parentManager;
    
    private Bounds _bounds;
    private GameObject _character;

    public bool inside = false;
    
    private void Start()
    {
        var transform_ = transform;
        _bounds = new Bounds(transform_.position, transform_.localScale);
        _character = GetComponentInParent<MapProperties>().character;
        _parentManager = GetComponentInParent<LevelManager>();
    }

    private void Update()
    {
        var shouldNotify = inside;

        inside = _bounds.Contains(_character.transform.position);
        
        if(!inside && shouldNotify) _parentManager.notify(transform.gameObject);
    }
}
