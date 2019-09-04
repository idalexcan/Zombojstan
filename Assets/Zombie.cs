using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NPC.Ally;

namespace NPC
{
    namespace Enemy
    {
        public class Zombie : NPC
        {
            public sZombie zombie = new sZombie();
            public Vector3 direction;
            float pospoint=0;
            public bool porsuing = false;
            public GameObject toporsuing = null;

            //-------------------------------------------<MÉTODOS DE COMPORTAMIENTO>--------------------|
            private void Awake()
            {
                zombie.taste = Data.tastes[Random.Range(0, 5)];
                zombie.color = Data.colors[Random.Range(0, 3)];
                zombie.npc.age = Random.Range(15, 100);
                zombie.npc.velocity = (float)(100 - zombie.npc.age)/10;
            }

            private void Start()
            {
                StartCoroutine("PeriodicVar");
            }
            private void Update()
            {
                pospoint = transform.position.x + transform.position.z;
                //if (General.hero.GetComponent<Hero>().pospoint <= pospoint + 5 && 
                //    General.hero.GetComponent<Hero>().pospoint >= pospoint - 5)
                //{
                //    direction = Vector3.Normalize(General.hero.GetComponent<Hero>().pos - transform.position);
                //    transform.position += direction * 0.1f;
                //}

                transform.position += transform.forward * 0.1f;
                foreach (var item in General.villagers)
                {
                    porsuing =
                        item.GetComponent<Villager>().pospoint <= pospoint + 5 &&
                        item.GetComponent<Villager>().pospoint >= pospoint - 5;
                    item.GetComponent<Villager>().porsued = porsuing;
                    if (porsuing)
                    {
                        
                        if (toporsuing=null)
                        {
                            toporsuing = item;
                        }
                    }
                    //item.GetComponent<Villager>().porsued =
                    //    item.GetComponent<Villager>().pospoint <= pospoint + 5 &&
                    //    item.GetComponent<Villager>().pospoint >= pospoint - 5;
                    //if (item.GetComponent<Villager>().porsued)
                    //{
                    //    break;
                    //}
                }

            }

            private void OnCollisionEnter(Collision col)
            {
                if (col.gameObject.GetComponent<Villager>())
                {
                    col.gameObject.AddComponent<Zombie>().zombie = (Zombie.sZombie)col.gameObject.GetComponent<Villager>().villager;
                    col.gameObject.GetComponent<Zombie>().ZomBecamed();
                    Destroy(col.gameObject.GetComponent<Villager>());
                    col.gameObject.GetComponent<MeshRenderer>().material.color = col.gameObject.GetComponent<Zombie>().zombie.color;
                }
            }

            IEnumerator PeriodicVar() 
            {
                for (; ; )
                {
                    transform.eulerAngles = new Vector3(0, Random.Range(0, 360), 0);
                    
                    yield return new WaitForSeconds(3);
                }
            }

            //-----------------------------------------------<MÉTODOS DE CLASE>-------------------------|

            public void ZomBecamed()
            {
                zombie.taste = Data.tastes[Random.Range(0, 5)];
                zombie.color = Data.colors[Random.Range(0, 3)];
            }///-------------------------------------------------------------<| PARA ZOMBIES QUE ERAN ALDEANOS

            public void Print()
            {
                Debug.Log("----------------------------------------------ZOMBIE-----|");
                Debug.Log("GUSTO: " + zombie.taste);
                Debug.Log("COLOR: " + zombie.color);
                Debug.Log("EDAD: " + zombie.npc.age);
                Debug.Log("VELOCIDAD: " + zombie.npc.velocity);
            }

            //------------------------------------------------------------------------------------------|

            public struct sZombie
            {
                public sNPC npc;
                public string taste;
                public Color color;
            } //-----------------------------------------------------------------<|ESTRUCTURA ZOMBIE|>

            
        }

        

    }
}
