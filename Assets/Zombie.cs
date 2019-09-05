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
            public bool porsuing = false;
            public GameObject toporsuing = null;
            public int myindex;
            float speedaux;

            //-------------------------------------------<MÉTODOS DE COMPORTAMIENTO>--------------------|
            private void Awake()
            {
                zombie.taste = Data.tastes[Random.Range(0, 5)];
                zombie.color = Data.colors[Random.Range(0, 3)];
                zombie.npc.age = Random.Range(15, 100);
                zombie.npc.speed = (float)(100 - zombie.npc.age)/1000*2;
                speedaux = zombie.npc.speed;
            }

            private void Start()
            {
                StartCoroutine("PeriodicVar");
            }
            private void Update()
            {

                General.hero.GetComponent<Hero>().zombodistance = (General.hero.GetComponent<Hero>().pos - transform.position).magnitude;

                //if (Input.GetKeyDown(KeyCode.O))
                //{
                //    transform.position = new Vector3(Random.Range(-30, 30), 0, Random.Range(-30, 30));
                //}

                foreach (var item in General.villagers)
                {
                    if (item.GetComponent<Villager>())
                    {
                        item.GetComponent<Villager>().zombodistance = (item.GetComponent<Villager>().transform.position - transform.position).magnitude;
                        item.GetComponent<Villager>().porsued = item.GetComponent<Villager>().zombodistance <= 5;
                        if (item.GetComponent<Villager>().zombodistance <= 5)
                        {
                            toporsuing = item;
                            item.GetComponent<Villager>().closezombie = General.zombies[myindex];
                        }
                    }
                }

                if (toporsuing != null && toporsuing.GetComponent<Villager>())
                {
                    direction = Vector3.Normalize(toporsuing.transform.position - transform.position);
                    speedaux = zombie.npc.speed * 3;
                    transform.position += direction * speedaux;
                }
                else
                {
                    if (General.hero.GetComponent<Hero>().zombodistance <= 5)
                    {
                        direction = Vector3.Normalize(General.hero.GetComponent<Hero>().pos - transform.position);
                        speedaux = zombie.npc.speed * 3;
                        transform.position += direction * speedaux;
                    }
                    else
                    {
                        speedaux = zombie.npc.speed;
                        transform.position += transform.forward * speedaux;
                    }
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
                    toporsuing = null;
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
                Debug.Log("VELOCIDAD: " + zombie.npc.speed);
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

//General.hero.GetComponent<Hero>().zombodistance = (General.hero.GetComponent<Hero>().pos - transform.position).magnitude;

//                foreach (var item in General.villagers)
//                {
//                    if (item.GetComponent<Villager>())
//                    {
//                        item.GetComponent<Villager>().zombodistance = (item.GetComponent<Villager>().transform.position - transform.position).magnitude;
//                        if (item.GetComponent<Villager>().zombodistance <= 5)
//                        {
//                            toporsuing = item;
//                        }
//                    }
//                }
//                if (toporsuing != null && toporsuing.GetComponent<Villager>())
//                {
//                    direction = Vector3.Normalize(toporsuing.transform.position - transform.position);
//                    transform.position += direction* 0.1f;
//                }
//                else
//                {
//                    if (General.hero.GetComponent<Hero>().zombodistance <= 5)
//                    {
//                        direction = Vector3.Normalize(General.hero.GetComponent<Hero>().pos - transform.position);
//                        transform.position += direction* 0.1f;
//                    }
//                    else
//                    {
//                        transform.position += transform.forward* 0.1f;
//                    }

//                }