using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class General : MonoBehaviour
{
    public GameObject cube;
    const int max= 25;
    readonly int min;
    int cantBody;
    List<GameObject> zombies = new List<GameObject>();
    List<GameObject> villagers = new List<GameObject>();



    public General()
    {
        min = Rand.rand.Next(5,15);//(int)Rnd.Basic(5, 15)
        cantBody = Rand.rand.Next(min, max);
        
    }

    private void Start()
    {
        for (int i = 0; i < cantBody; i++)
        {
            GameObject go = GameObject.Instantiate(cube) as GameObject;
            go.transform.position = new Vector3(Rand.rand.Next(-10, 10), 0, Rand.rand.Next(-10, 10));

            if (Rand.rand.Next(0,2)==0)
            {
                zombies.Add(go);
                
            }
            else
            {
                
            }
        }
    }

    private void Update()
    {
        
    }
}

public class Rand // CLASE DE LOS BRANDONS
{
    public static System.Random rand = new System.Random();
}








