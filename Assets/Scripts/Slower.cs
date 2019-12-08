using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slower : MonoBehaviour
{
    private Movement movement;

    public BoxCollider2D bc;

    public BoxCollider2D nyusziBC;

    private bool slower;

    private float min = 200;
    // Start is called before the first frame update
    void Start()
    {
        bc = GetComponent<BoxCollider2D>();
        nyusziBC=nyusziBC = GameObject.Find("blob").GetComponent<BoxCollider2D>();
        slower = false;
        movement=GameObject.Find("blob").GetComponent<Movement>();
        min = 200;

    }

    // Update is called once per frame
    void Update()
    {
        checkCollision();
    }

    private void FixedUpdate()
    {
        if (slower)
        {
            if (movement.sideForce < min)
            {
                movement.sideForce = min;
            }
            else
            {
                movement.sideForce /= 5;
            }
            Destroy(gameObject);
        }
    }

    private void checkCollision()
    {
        if (bc.IsTouching(nyusziBC))
        {
            slower = true;
        }
        else
        {
            slower = false;
        }
    }
}
