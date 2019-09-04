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
            public bool porsued = false;
            public GameObject closezombie;

            private void Awake()
            {
                villager.name = Data.names[Random.Range(0, 20)];
                villager.npc.age = Random.Range(15, 100);
                villager.npc.velocity = (float)(100 - villager.npc.age) / 10;
            }

            private void Start()
            {
                StartCoroutine("PeriodicVar");
            }

            private void Update()
            {
                //transform.position += transform.forward * 0.1f;


            }

            IEnumerator PeriodicVar()
            {
                for (; ; )
                {
                    transform.eulerAngles = new Vector3(0, Random.Range(0, 360), 0);
                    yield return new WaitForSeconds(3);
                }
            }

            public void Print()
            {
                Debug.Log("----------------------------------------------VILLAGER--|");
                Debug.Log("nombre: " + villager.name);
                Debug.Log("edad: " + villager.npc.age);
                Debug.Log("velocidad: " + villager.npc.velocity);
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
