using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class freemove : MonoBehaviour
{
    private Rigidbody2D rb;
    public int rndszorzo = 1;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A))
            rb.transform.position = rb.transform.position + rndszorzo*Time.deltaTime*Vector3.left;
        if (Input.GetKey(KeyCode.W))
            rb.transform.position = rb.transform.position + rndszorzo*Time.deltaTime*Vector3.up;
        if (Input.GetKey(KeyCode.D))
            rb.transform.position = rb.transform.position + rndszorzo*Time.deltaTime*Vector3.right;
        if (Input.GetKey(KeyCode.S))
            rb.transform.position = rb.transform.position + rndszorzo*Time.deltaTime*Vector3.down;
    }
}
