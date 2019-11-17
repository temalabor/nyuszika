using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public Transform nyuszi;
    public Vector2 nyusziCoord;
    public BoxCollider2D nyusziBC;
    


    public Rigidbody2D rb;
    public Transform tr;

    private float _minY;
    // Start is called before the first frame update
    void Start()
    {
        nyuszi = GameObject.Find("blob").transform;
        nyusziCoord = nyuszi.transform.position;
        nyusziBC = GameObject.Find("blob").GetComponent<BoxCollider2D>();
        tr = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        speed = 50000.0f;
        Vector2 dir = nyusziCoord - new Vector2(tr.position.x, tr.position.y);
        dir.Normalize();
        rb.AddForce(dir * (speed * rb.mass * Time.deltaTime));
        _minY = -10.0f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 nyusziCurrent = nyuszi.position;
        //if (Vector2.Distance(tr.position, nyusziCurrent) < 0.5f)
            
            if (rb.IsTouching(nyusziBC))
            {
                Player_life lifescript = GameObject.Find("blob").GetComponent<Player_life>();
                lifescript.DecreaseLife();
            Destroy(gameObject);
        }

        if (tr.position.y < _minY)
        {
            Destroy(gameObject);
        }
    }
}
