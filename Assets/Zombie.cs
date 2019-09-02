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
            sZombie zombie = new sZombie();
            private void Awake()
            {
                zombie.taste = Data.tastes[Random.Range(0, 5)];
                zombie.color = Data.colors[Random.Range(0, 3)];
                zombie.npc.age = Random.Range(15, 100);
                zombie.npc.velocity = (float)(100 - zombie.npc.age)/10;
            }

            void Update()
            {

            }

            public void Print()
            {
                Debug.Log("----------------------------------------------ZOMBIE-----|");
                Debug.Log("GUSTO: " + zombie.taste);
                Debug.Log("COLOR: " + zombie.color);
                Debug.Log("EDAD: " + zombie.npc.age);
                Debug.Log("VELOCIDAD: " + zombie.npc.velocity);

            }

            public struct sZombie
            {
                public sNPC npc;
                public string taste;
                public Color color;
                public static explicit operator Villager.sVillager(sZombie zombie)
                {
                    return new Villager.sVillager();
                }
            }
        }

    }
}
