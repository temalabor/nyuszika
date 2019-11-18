using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_collision : MonoBehaviour
{
    private BoxCollider2D bc;

    private BoxCollider2D nyusziBC;

    private Player_life lifescript;

    private float waitTime;
    
    
    // Start is called before the first frame update
    void Start()
    {
        bc = GetComponent<BoxCollider2D>();
        nyusziBC = GameObject.Find("blob").GetComponent<BoxCollider2D>();
        lifescript = GameObject.Find("blob").GetComponent<Player_life>();
        waitTime = 2.0f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (bc.IsTouching(nyusziBC) && waitTime < 0.0f)
        {
            lifescript.DecreaseLife();
            waitTime = 2.0f;
        }
        else waitTime -= Time.deltaTime;
    }
}
