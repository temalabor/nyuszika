using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Faster : MonoBehaviour
{
    private Movement movement;

    public BoxCollider2D bc;

    public BoxCollider2D nyusziBC;

    private bool faster;
    // Start is called before the first frame update
    void Start()
    {
        bc = GetComponent<BoxCollider2D>();
        nyusziBC=nyusziBC = GameObject.Find("blob").GetComponent<BoxCollider2D>();
        faster = false;
        movement=GameObject.Find("blob").GetComponent<Movement>();

    }

    // Update is called once per frame
    void Update()
    {
        checkCollision();
    }

    private void FixedUpdate()
    {
        if (faster)
        {
            movement.sideForce *= 5;
            Destroy(gameObject);
        }
    }

    private void checkCollision()
    {
        if (bc.IsTouching(nyusziBC))
        {
            faster = true;
        }
        else
        {
            faster = false;
        }
    }
}
