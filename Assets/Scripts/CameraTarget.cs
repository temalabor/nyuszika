using UnityEditor.Advertisements;
using UnityEngine;

public class CameraTarget : MonoBehaviour
{
    public Vector3 offset;
    public LevelManager levelManager;
    public GameObject player;

    public float snapSpeed;
    
    private Vector3 _target;
    private bool _inLevel = true;

    private void Left(GameObject level)
    {
        _inLevel = false;
    }

    private void Entered(GameObject level)
    {
        _inLevel = true;
        SetTarget(level.transform.position);
    }

    private void SetTarget(Vector3 target)
    {
        _target = target;
    }

    private void Start()
    {
        levelManager.PlayerLeft += Left;
        levelManager.PlayerEntered += Entered;
    }

    private void Update()
    {
        if(_inLevel) AnimateInLevel(Time.deltaTime);
        if(!_inLevel) AnimateNotInLevel(Time.deltaTime);
    }

    private void AnimateInLevel(float deltaTime)
    {
        Animate(deltaTime, snapSpeed);
    }
    
    private void AnimateNotInLevel(float deltaTime)
    {
        SetTarget(player.transform.position);
        Animate(deltaTime, snapSpeed * 2);
    }

    private void Animate(float deltaTime, float speed)
    {
        var _transform = transform;
        var position = _transform.position;
        position += speed * deltaTime * (new Vector3(_target.x + offset.x, _target.y + offset.y, _target.z + offset.z) - position);
        _transform.position = position;
    }
}
