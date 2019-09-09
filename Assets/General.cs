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
    }///---------------------------------------------------------------------<| CONSTRUCTOR      

    //-------------------------------------------<MÉTODOS DE COMPORTAMIENTO>--------------------|
    
    private void Start()
    {
        // ---<|HEROE|>--------------------------------------|
        hero = GameObject.Instantiate(cube) as GameObject;
        hero.transform.position = new Vector3(0, 0, -40);
        hero.AddComponent<Hero>();
        hero.transform.localScale = new Vector3(1, 3, 1);
        
        CreateBody("zombie");
        CreateBody("zombie");
        CreateBody("zombie");
        for (int i = 0; i < 10; i++)
        {
            CreateBody("villager");
        }
        // ---< ZOMBIES | VILLAGERS > -----------------------|
        //for (int i = 0; i < cantBody; i++)
        //{
        //    if (Rand.rand.Next(0, 4) == 0)
        //    {
        //        CreateBody("zombie");
        //    }
        //    else
        //    {
        //        CreateBody("villager");
        //    }
        //}
        StartCoroutine("States");
    }

    //-----------------------------------------------<MÉTODOS DE CLASE>-------------------------|

    public void CreateBody(string body)
    {
        if (body=="zombie")
        {   // ---ZOMBIES---------------------------------------------------------------------------------------------------|
            cantZ++;
            zombies.Add(GameObject.Instantiate(cube));
            zombies[cantZ].transform.position = new Vector3(Rand.rand.Next(-30, 30), 0, Rand.rand.Next(-30, 30));
            zombies[cantZ].AddComponent<Zombie>(); 
            zombies[cantZ].GetComponent<MeshRenderer>().material.color = zombies[cantZ].GetComponent<Zombie>().zombie.color;
            
        }
        if (body=="villager")
        {   // ---VILLAGER-------------------------------------------------------------------------------------------------|
            cantA++;
            villagers.Add(GameObject.Instantiate(cube));
            villagers[cantA].transform.position = new Vector3(Rand.rand.Next(-30, 30), 0, Rand.rand.Next(-30, 30));
            villagers[cantA].GetComponent<MeshRenderer>().material.color = Color.grey;
            villagers[cantA].AddComponent<Villager>();
        }
    }///--------------------------------------------------<| CREACIÓN DE PERSONAJES   |
    
    IEnumerator States()
    {
        for (;;)
        {
            foreach (var item in FindObjectsOfType(typeof(GameObject)) as GameObject[])
            {
                if (item.GetComponent<Zombie>())//|| item.GetComponent<Villager>()
                {   //---<|ZOMBIES|>--------------------------------------------------------------------------------------------|
                    item.GetComponent<Zombie>().state = (Zombie.NpcState)Rand.rand.Next(0, 3);
                    switch (item.GetComponent<Zombie>().state)
                    {
                        case NPC.NPC.NpcState.idle:
                            break;
                        case NPC.NPC.NpcState.moving:
                            item.transform.eulerAngles = new Vector3(0, Rand.rand.Next(0, 360), 0);
                            break;
                        case NPC.NPC.NpcState.rotating:
                            float rot = 0;
                            while (rot == 0)
                            {
                                rot = Rand.rand.Next(-1, 2);
                                item.GetComponent<Zombie>().rot = rot;
                            }
                            break;
                    }
                }
                if (item.GetComponent<Villager>())
                {   //---<|ALDEANOS|>-------------------------------------------------------------------------------------------|
                    item.GetComponent<Villager>().state = (Villager.NpcState)Rand.rand.Next(0, 3);
                    switch (item.GetComponent<Villager>().state)
                    {
                        case NPC.NPC.NpcState.idle:
                            break;
                        case NPC.NPC.NpcState.moving:
                            item.transform.eulerAngles = new Vector3(0, Rand.rand.Next(0, 360), 0);
                            break;
                        case NPC.NPC.NpcState.rotating:
                            float rot = 0;
                            while (rot == 0)
                            {
                                rot = Rand.rand.Next(-1, 2);
                                item.GetComponent<Villager>().rot = rot;
                            }
                            break;
                    }
                }
            }
            yield return new WaitForSeconds(3);
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






