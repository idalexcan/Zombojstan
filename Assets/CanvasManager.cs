using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NPC.Ally;
using NPC.Enemy;

public class CanvasManager : MonoBehaviour
{
    public Text message;
    public Text cantenemy;
    int contenemy=0;
    public Text cantally;
    int contally=0;
    public static bool toupdate = false;
    

    private void Start()
    {
        
    }

    void Update()
    {
        if (toupdate)
        {
            foreach (var item in FindObjectsOfType(typeof(GameObject)) as GameObject[])
            {
                if (item.GetComponent<Villager>())
                {
                    contally++;
                }
                if (item.GetComponent<Zombie>())
                {
                    contenemy++;
                }
            }
            cantally.text = "Aldeanos: " + contally;
            cantenemy.text = "Zombies: " + contenemy;
            toupdate = false;
            contally = 0;
            contenemy = 0;
        }
    }

    
}
