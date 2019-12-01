using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_life : MonoBehaviour
{
    public delegate void LifeDelegate(int remaining);

    public event LifeDelegate LifeEvent;
    public int life;

    private int maxLife = 5;
    // Start is called before the first frame update
    void Start()
    {
        life = maxLife;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DecreaseLife()
    {
        life--;
        LifeEvent?.Invoke(life);
    }

    public void AddLife()
    {
        if (life != maxLife)
        {
            life++;
        }
    }
}
