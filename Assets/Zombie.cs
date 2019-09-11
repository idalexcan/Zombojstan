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
            GameObject inporsuing = null;
            float herodistance;
            

            //----------------------------------------------------------------------------------------------------------------------------|
            ///-------------------------------------------<|MÉTODOS DEL MONOBIJEVIO|>-----------------------------------------------------|

            private void Awake()
            {
                zombie.taste = Data.tastes[Random.Range(0, 5)];
                zombie.color = Data.colors[Random.Range(0, 3)];
                zombie.npc.age = Random.Range(15, 100);
                zombie.npc.speed = (float)(100 - zombie.npc.age)/1000;
                speedaux = zombie.npc.speed;
            }
            
            private void Update()
            {
                if (General.rungame)
                {
                    Radar();
                    Behavior();
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
                    col.transform.name = "zombie";
                    CanvasManager.toupdate = true;
                }
            }

            //----------------------------------------------------------------------------------------------------------------------------|
            ///----------------------------------------------<|MÉTODOS DE CLASE|>---------------------------------------------------------|

            void Behavior()
            {
                if (inporsuing != null && inporsuing.GetComponent<Villager>())
                {
                    direction = Vector3.Normalize(inporsuing.transform.position - transform.position);
                    speedaux = zombie.npc.speed * 1.5f;
                    transform.position += direction * speedaux;
                }
                else
                {
                    if (herodistance <= 5)
                    {
                        direction = Vector3.Normalize(General.hero.GetComponent<Hero>().pos - transform.position);
                        speedaux = zombie.npc.speed * 2;
                        transform.position += direction * speedaux;

                    }
                    else
                    {
                        MoveState();
                    }
                }
            }///--------------------------------------------------------------<| Comportamiento de zombie

            void Radar()
            {
                herodistance = (General.hero.GetComponent<Hero>().pos - transform.position).magnitude;
                foreach (var item in FindObjectsOfType(typeof(GameObject)) as GameObject[])
                {
                    if (item.GetComponent<Villager>())
                    {
                        item.GetComponent<Villager>().zombodistance = (item.GetComponent<Villager>().transform.position - transform.position).magnitude;
                        if (item.GetComponent<Villager>().zombodistance <= 5)
                        {
                            inporsuing = item;
                        }
                    }
                }
            }///-----------------------------------------------------------------<| Radar de cuerpo cercano

            public void ZomBecamed()
            {
                zombie.taste = Data.tastes[Random.Range(0, 5)];
                zombie.color = Data.colors[Random.Range(0, 3)];
            }///-----------------------------------------------------<| Asigna variables de aldeanos convertidos

            public string Print()
            {
                return "asdkfsdkfs soy un zombi y quiero comer " + zombie.taste;
            }///--------------------------------------------------------<| Mensaje

            //----------------------------------------------------------------------------------------------------------------------------|
            ///----------------------------------------------<|ESTRUCTURA ZOMBIE|>--------------------------------------------------------|

            public struct sZombie
            {
                public sNPC npc;
                public string taste;
                public Color color;
            } 
    
        }

    }
}
