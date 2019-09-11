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
            Vector3 direction;
            GameObject porsuingme;
            public bool inaction = false;

            //---------------------------------------------------------------------------------------------------------------------------|
            ///-------------------------------------------<|MÉTODOS DEL MONOBIJEVIO|>-----------------------------------------------------|

            private void Awake()
            {
                villager.name = Data.names[Random.Range(0, 20)];
                villager.npc.age = Random.Range(15, 100);
                villager.npc.speed = (float)(100 - villager.npc.age) / 1000;
            }

            private void Update()
            {
                if (General.rungame)
                {
                    Radar();
                    Behavior();
                }
            }

            //----------------------------------------------------------------------------------------------------------------------------|
            ///-----------------------------------------------<|MÉTODOS DE CLASE|>--------------------------------------------------------|

            void Behavior()
            {
                if (inaction)
                {
                    speedaux = villager.npc.speed * 5;
                    GetComponent<MeshRenderer>().material.color = Color.red;
                    transform.position -= Vector3.Normalize(porsuingme.transform.position - transform.position) * speedaux;
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
                            porsuingme = item;
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

            public string Print()
            {
                return "Holandas, mi nombre es " + villager.name + ",y tengo " + villager.npc.age + " años";
            }///----------------------------------------------------------------<| Mensaje

            //----------------------------------------------------------------------------------------------------------------------------|
            ///--------------------------------------------------<|CONSTRUCTOR|>----------------------------------------------------------|
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
