using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Enemy_move3 : MonoBehaviour
{
    public GameObject nyuszi;

    public bool nyusziClose = false;

    public Rigidbody2D rb;

    public float speed;

    public float maxDistance;

    private Vector2 current;

    private Vector2 nyusziCurrent;
    
   
    public float waitTime;
    public float movingTime;
    public bool newTime=true;


    // Start is called before the first frame update
    void Start()
    {
        nyuszi = GameObject.Find("blob");
        rb = GetComponent<Rigidbody2D>();
        speed = 500.0f;
        maxDistance = 10.0f;
        current = rb.transform.position;
        nyusziCurrent = nyuszi.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        CheckNyusziClose();
       
        
    }

    private void FixedUpdate()
    {
        
        if (nyusziClose)
        {
            Move();
        }

        else
        {
            rb.velocity = Vector2.zero;
        }
    }

    private void CheckNyusziClose()
    {
        current = rb.transform.position;
        nyusziCurrent = nyuszi.transform.position;
        if (Vector2.Distance(current, nyusziCurrent) < maxDistance)
        {
            if (newTime)
            {
                waitTime = Random.Range(0.5f, 5.0f);
                movingTime = Random.Range(2.0f, 7.0f);
                newTime = false;
            }
            nyusziClose = true;
        }
        else
        {
            nyusziClose = false;
            newTime = true;
        }
    }

    

    private void Move()
    {
        if (waitTime > 0.0f)
        {
            waitTime -= Time.deltaTime;
            return;
        }
        if (movingTime > 0.0f)
        {
            Vector2 dir = nyusziCurrent - current;
            dir.Normalize();
            rb.AddForce(dir * (speed * rb.mass * Time.deltaTime));
            movingTime -= Time.deltaTime;
        }

        else
        {
            waitTime = Random.Range(0.5f, 5.0f);
            movingTime = Random.Range(2.0f, 7.0f);
            rb.velocity=Vector2.zero;
        }
    }
}