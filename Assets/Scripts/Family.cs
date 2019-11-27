using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Family : MonoBehaviour
{
    [Range(min:1, max:10)]
    public float followDistance;
    public Vector3 offset;

    private List<TargetFollow> _fam = new List<TargetFollow>();
    private Vector3[] _prevPositions = new Vector3[10];
    
    private void Start()
    {
        for (var i = 0; i < _prevPositions.Length; i++)
        {
            _prevPositions[i] = Vector3.zero;
        }

        for (int i = 0; i < 6; i++)
        {
            AddFamilyMember(Resources.Load<Sprite>("sprites/fam"));
        }
    }

    private void Update()
    {
        var distance = (_prevPositions[0] - transform.position).magnitude; 
        if (distance > followDistance)
        {
            for (int i = 9; i > 0; i--)
            {
                _prevPositions[i] = _prevPositions[i - 1];
            }

            _prevPositions[0] = transform.position;
        }
        
        var l = distance / followDistance;
        for (int i = 9; i > 0; i--)
        {
            _prevPositions[i] = _prevPositions[i] * (1 - l) + _prevPositions[i - 1] * l;
        }

        _prevPositions[0] = _prevPositions[0] * (1 - l) + transform.position * l;
        
        
        for(var i = 0; i < _fam.Count; i++)
        {
            _fam[i].target = _prevPositions[i + 1] + offset;
        }
    }
 
    private void AddFamilyMember(Sprite sprite)
    {
        var member = new GameObject("member_" + _fam.Count);
        member.AddComponent<SpriteRenderer>().sprite = sprite;
        _fam.Add(member.AddComponent<TargetFollow>());
    }

    private Vector3 FindMemberPosition(int index)
    {
        return Physics2D.Raycast(transform.position + (index + 1) * followDistance * Vector3.left, Vector2.down).point;
    }
}
