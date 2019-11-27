using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetFollow : MonoBehaviour
{
    public Vector3 target;
    public float speed = 16;
    private Vector3 _velocity;
    

    private void Update()
    {
        _velocity = (target - transform.position) * speed;
        transform.position += _velocity * Time.deltaTime;
    }
}
