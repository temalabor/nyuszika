using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_shoot : MonoBehaviour
{
    public GameObject nyuszi;
    public GameObject bullet;

    private bool shooting;
    private float _shootTimer;
    public float shootTime = 2.0f;
    public float _shootingDistance = 10.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        nyuszi = GameObject.Find("blob");
        shooting = false;
    }

    // Update is called once per frame
    void Update()
    {
        CheckShooting();
        if (_shootTimer < shootTime) _shootTimer += Time.deltaTime;
    }

    private void FixedUpdate()
    {
        if (shooting) Shoot();
    }


    private void CheckShooting()
    {
        shooting = Vector3.Distance(transform.position, nyuszi.transform.position) < _shootingDistance;
    }

    private void Shoot()
    {
        if (_shootTimer < shootTime) return;
        
        Instantiate(bullet, transform.position, Quaternion.identity);
        _shootTimer = 0f;
    }
}
