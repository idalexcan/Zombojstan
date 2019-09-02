using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using NPC.Ally;
using NPC.Enemy;
using NPC;

public class General : MonoBehaviour
{
    /// <summary>
    /// < cube objeto referencia
    /// < hero heroe
    /// < zombies lista de zombies 
    /// < cantZ contador de zombies
    /// < villagers lista de aldeanos
    /// < contA contador de aldeanos
    /// </summary>
    public GameObject cube;
    public static GameObject hero;
    public static List<GameObject> zombies = new List<GameObject>();
    public static int cantZ = -1;
    public static List<GameObject> villagers = new List<GameObject>();
    public static int cantA = -1;
    /// <summary>
    /// < max límite máximo posible de personajes
    /// < min líite mínimo posible de personajes
    /// < cantBody cantidad aleatoria de personajes entre min y max
    /// </summary>
    const int max = 25;
    readonly int min;
    int cantBody;

    public General()
    {   
        min = Rand.rand.Next(5, 15);
        cantBody = Rand.rand.Next(min, max);
    }
    
    private void Start()
    {
        // --- HEROE -------------------------------------|
        hero = GameObject.Instantiate(cube) as GameObject;
        hero.transform.position = new Vector3(0, 0, 0);
        hero.AddComponent<Hero>();
        // -----------------------------------------------|

        CreateBody("zombie");
        CreateBody("villager");
        villagers[cantA].GetComponent<Villager>().Print();

    }

    public void CreateBody(string body)
    {
        if (body=="zombie")
        {
            cantZ++;
            zombies.Add(GameObject.Instantiate(cube));
            //zombies[cantZ].transform.position = new Vector3(Rand.rand.Next(-10, 10), 0, Rand.rand.Next(-10, 10));
            zombies[cantZ].transform.position = new Vector3(5, 0, 0);
            zombies[cantZ].AddComponent<Zombie>();
            zombies[cantZ].GetComponent<MeshRenderer>().material.color = zombies[cantZ].GetComponent<Zombie>().zombie.color;

        }
        if (body=="villager")
        {
            cantA++;
            villagers.Add(GameObject.Instantiate(cube));
            //villagers[cantA].transform.position = new Vector3(Rand.rand.Next(-10, 10), 0, Rand.rand.Next(-10, 10));
            villagers[cantZ].transform.position = new Vector3(5, 0, 7);
            villagers[cantA].GetComponent<MeshRenderer>().material.color = Color.grey;
            villagers[cantA].AddComponent<Villager>();
        }
    }
    
}



public class Rand 
{
    public static System.Random rand = new System.Random();

    public static float Float(int a, int b)
    {
        float r;
        r = (float)rand.NextDouble() + (rand.Next(a, b));
        return r;
    }
}


//for (int i = 0; i < 4; i++) 
//{
//    if (Rand.rand.Next(0, 2) == 0)
//    {   // --- ZOMBIES ----------------------------------------------------------------------------------|
//        cantZ++;
//        zombies.Add(GameObject.Instantiate(cube));
//        zombies[cantZ].transform.position = new Vector3(Rand.rand.Next(-10, 10), 0, Rand.rand.Next(-10, 10));
//        zombies[cantZ].GetComponent<MeshRenderer>().material.color = Color.red;
//    }
//    else
//    {   // --- ALDEANOS ----------------------------------------------------------------------------------|
//        cantA++;
//        villagers.Add(GameObject.Instantiate(cube));
//        villagers[cantA].transform.position = new Vector3(Rand.rand.Next(-10, 10), 0, Rand.rand.Next(-10, 10));
//        villagers[cantA].GetComponent<MeshRenderer>().material.color = Color.grey;
//    }
//} ///generación de zombies y aldeanos





