using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 100;
    private GameObject nyuszi;
    private Vector2 nyusziCoord;
    private BoxCollider2D nyusziBC;
    private Player_life lifescript;
    private Vector2 startPos;
    


    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        lifescript = GameObject.Find("blob").GetComponent<Player_life>();
        nyuszi = GameObject.Find("blob");
        nyusziBC = GameObject.Find("blob").GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        Vector2 dir = nyuszi.transform.position - transform.position;
        dir.Normalize();
        rb.velocity += dir * speed;
        startPos = rb.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 nyusziCurrent = nyuszi.transform.position;
        //if (Vector2.Distance(tr.position, nyusziCurrent) < 0.5f)
            
            if (rb.IsTouching(nyusziBC))
            {
                lifescript.DecreaseLife();
            Destroy(gameObject);
        }

            if (rb.transform.position.y<startPos.y-10)
            {
                Destroy(gameObject);
            }
    }
}
