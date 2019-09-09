using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NPC;
using NPC.Enemy;

namespace NPC
{
    namespace Ally
    {
        public class Villager : NPC
        {
            public sVillager villager = new sVillager();
            public float zombodistance;

            //---------------------------------------------------------------------------------------------------------------------------|
            //-------------------------------------------<|MÉTODOS DEL MONOBIJEVIO|>-----------------------------------------------------|

            private void Awake()
            {
                villager.name = Data.names[Random.Range(0, 20)];
                villager.npc.age = Random.Range(15, 100);
                villager.npc.speed = (float)(100 - villager.npc.age) / 1000;
            }

            

            private void Update()
            {
                Radar();
                Behavior();

                
            }

            //----------------------------------------------------------------------------------------------------------------------------|
            //-----------------------------------------------<|MÉTODOS DE CLASE|>---------------------------------------------------------|

            void Behavior()
            {
                if (inaction)
                {
                    speedaux = villager.npc.speed * 5;
                    GetComponent<MeshRenderer>().material.color = Color.red;
                    transform.position += transform.forward * speedaux;
                }
                else
                {
                    speedaux= villager.npc.speed; 
                    MoveState();
                    GetComponent<MeshRenderer>().material.color = Color.grey;
                }
                
            }///----------------------------------------------------------------------<| Comportamiento de aldeano

            void Radar()
            {
                foreach (var item in FindObjectsOfType(typeof(GameObject)) as GameObject[])
                {
                    if (item.GetComponent<Zombie>())
                    {
                        if ((item.transform.position - transform.position).magnitude <= 5)
                        {
                            inaction = true;
                            break;
                        }
                        else
                        {
                            inaction = false;
                        }
                    }
                }
            }///-------------------------------------------------------------------------<| Radar de cuerpo cercano

            public void Print()
            {
                Debug.Log("----------------------------------------------VILLAGER--|");
                Debug.Log("nombre: " + villager.name);
                Debug.Log("edad: " + villager.npc.age);
                Debug.Log("velocidad: " + villager.npc.speed);
            }


            public struct sVillager
            {
                public sNPC npc;
                public string name;
                public static explicit operator Zombie.sZombie(sVillager villager)
                {
                    Zombie.sZombie zombie = new Zombie.sZombie();
                    zombie.npc = villager.npc;
                    return zombie;
                }
            }
        }
        
    }
}
