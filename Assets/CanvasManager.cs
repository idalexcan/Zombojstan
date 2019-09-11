using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NPC.Ally;
using NPC.Enemy;

public class CanvasManager : MonoBehaviour
{
    /// <summary>
    /// <Message mensaje que imprime el texto correspondiente al NPC con el que se colisiona
    /// <cantenemy texto que muestra la cantidad de enemigos (zombies)
    /// <contenemy contador para enemigos 
    /// <cantally texto de muestra la cantidad de aliados (aldeanos)
    /// <contally contador para aliados
    /// </summary> 
    public Text message;
    public Text cantenemy;
    int contenemy=0;
    public Text cantally;
    int contally=0;
    public static bool toupdate = false;
    public static GameObject geimober;
    private void Awake()
    {
        geimober= GameObject.Find("Game Uber");
        geimober.SetActive(false);
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

        if (!General.rungame)
        {
            geimober.SetActive(true);
        }
    }

    
}
