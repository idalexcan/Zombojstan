using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class General : MonoBehaviour
{
    const int max= 25;
    readonly int min;
    public int cantBody;
    List<GameObject> bodies = new List<GameObject>();

    public General()
    {
        min = Rand.rand.Next(5,15);//(int)Rnd.Basic(5, 15)
        cantBody = Rand.rand.Next(min, max);
        
    }

    private void Start()
    {
        for (int i = 0; i < cantBody; i++)
        {
            if (Rand.rand.Next(0,2)==0)
            {
                Debug.Log(i + ". esto es un zombie");
            }
            else
            {
                Debug.Log(i + ". esto es un aldeano");
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








