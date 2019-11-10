using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UIElements;
using Debug = UnityEngine.Debug;
using Random = UnityEngine.Random;

public class GeneratorScript : MonoBehaviour
{
    public Tiles tiles;
    private int random;

    public void Start()
    {
        tiles = GameObject.FindGameObjectWithTag("container").GetComponent<Tiles>();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(this);
    }

    public void Generate(int dir)
    {
        switch (dir)
        {
            case 1:
                random = Random.Range(0, tiles.tiles1.Length);
                Instantiate(tiles.tiles1[random], transform.position, Quaternion.identity);
                break;
            case 2:
                random = Random.Range(0, tiles.tiles2.Length);
                Instantiate(tiles.tiles2[random], transform.position, Quaternion.identity);
                break;
            case 3:
                random = Random.Range(0, tiles.tiles3.Length);
                Instantiate(tiles.tiles3[random], transform.position, Quaternion.identity);
                break;
            case 4:
                random = Random.Range(0, tiles.tiles4.Length);
                Instantiate(tiles.tiles4[random], transform.position, Quaternion.identity);
                break;
            default:
                Debug.Log("invalid dir");
                break;
        }
    }
}