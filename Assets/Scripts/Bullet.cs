using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    private GameObject nyuszi;
    private Vector2 nyusziCoord;
    private BoxCollider2D nyusziBC;
    private Player_life lifescript;
    


    private Rigidbody2D rb;
    private Transform tr;

    // Start is called before the first frame update
    void Start()
    {
        lifescript = GameObject.Find("blob").GetComponent<Player_life>();
        nyuszi = GameObject.Find("blob");
        nyusziBC = GameObject.Find("blob").GetComponent<BoxCollider2D>();
        tr = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        speed = 50000.0f;
        Vector2 dir = nyusziCoord - new Vector2(tr.position.x, tr.position.y);
        dir.Normalize();
        rb.AddForce(dir * (speed * rb.mass * Time.deltaTime));
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
    }
}
