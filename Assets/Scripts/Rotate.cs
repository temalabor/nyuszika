using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public Rigidbody2D rb;
        
        public GameObject nyuszi;
        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            nyuszi = GameObject.Find("blob");
        }
    
        // Update is called once per frame
        void FixedUpdate()
        {
            
            Vector2 dir = nyuszi.transform.position - rb.transform.position;
            if (dir.x < 0)
            {
                transform.localRotation = Quaternion.Euler(0, 0, 0);
                    
            }
            else
            {
                transform.localRotation = Quaternion.Euler(0, 180, 0);
            }
        }
    }