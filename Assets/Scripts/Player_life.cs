using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_life : MonoBehaviour
{
    public delegate void LifeDelegate(int remaining);

    public event LifeDelegate LifeEvent;
    public int life;
    
    // Start is called before the first frame update
    void Start()
    {
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
}
