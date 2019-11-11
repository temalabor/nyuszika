using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_shoot : MonoBehaviour
{
    public Transform nyuszi;
    public Rigidbody2D rb;
    public GameObject bullet;

    public bool shooting;
    private float _shootTimer;
    public float shootTime ;

    private float _shootingDistance;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        shootTime = 2.0f;
        shooting = false;
        _shootingDistance = 10.0f;
    }

    // Update is called once per frame
    void Update()
    {
        CheckShooting();
        if (_shootTimer < shootTime) _shootTimer += Time.deltaTime;
    }

    private void FixedUpdate()
    {
        if (shooting)
        {
            Shoot();
        }
    }


    private void CheckShooting()
    {
        if (Vector3.Distance(rb.transform.position, nyuszi.transform.position) < _shootingDistance)
        {
            shooting = true;
        }
        else
        {
            shooting = false;
        }
    }

    private void Shoot()
    {
        if (_shootTimer < shootTime) return;
        _shootTimer = 0f;
        Instantiate(bullet, rb.transform.position, Quaternion.identity);
    }
}
