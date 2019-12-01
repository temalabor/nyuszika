using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlusLife : MonoBehaviour
{
    private Player_life life;

    public BoxCollider2D bc;

    public BoxCollider2D nyusziBC;

    private bool pluslife;
    // Start is called before the first frame update
    void Start()
    {
        bc = GetComponent<BoxCollider2D>();
        nyusziBC=nyusziBC = GameObject.Find("blob").GetComponent<BoxCollider2D>();
        pluslife = false;
        life=GameObject.Find("blob").GetComponent<Player_life>();

    }

    // Update is called once per frame
    void Update()
    {
        checkCollision();
    }

    private void FixedUpdate()
    {
        if (pluslife)
        {
           life.AddLife();
            Destroy(gameObject);
        }
    }

    private void checkCollision()
    {
        if (bc.IsTouching(nyusziBC))
        {
            pluslife = true;
        }
        else
        {
            pluslife = false;
        }
    }
}
