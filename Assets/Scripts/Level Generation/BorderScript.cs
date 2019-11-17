using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderScript : MonoBehaviour
{
    public GeneratorScript gen;
    public GameObject super;
    public int dir;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("Player"))
        {
            if (gen != null)
            {
                if (dir % 2 ==0)
                { 
                    gen.Generate(dir);
                    Destroy(gen);
                }
                else
                {
                    //wait
                    gen.Generate(dir);
                    Destroy(gen);
                }
            }

            Destroy(super);
        }
    }
}