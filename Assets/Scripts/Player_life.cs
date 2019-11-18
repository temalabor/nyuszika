using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_life : MonoBehaviour
{
    public int life;
    // Start is called before the first frame update
    void Start()
    {
        life = 5;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DecreaseLife()
    {
        life--;
    }
}
