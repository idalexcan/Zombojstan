using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NPC
{
    public class NPC : MonoBehaviour
    {

        public NpcState state;
        public float speedaux;
        public float rot;
        


        public void MoveState()
        {
            switch (state)
            {
                case NpcState.idle:
                    break;
                case NpcState.moving:
                    transform.position += transform.forward * speedaux;
                    break;
                case NpcState.rotating:
                    transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + (rot), 0);
                    break;
            }
            //if (item.GetComponent<Zombie>()) // <|ZOMBIES|>
            //{
            //    item.GetComponent<Zombie>().state = (Zombie.NpcState)Rand.rand.Next(0, 3);
            //    switch (item.GetComponent<Zombie>().state)
            //    {
            //        case NPC.NPC.NpcState.idle://------->No requiere asignar nada
            //            break;
            //        case NPC.NPC.NpcState.moving://----->Requiere asignar una nueva dirección de movimiento
            //            item.transform.eulerAngles = new Vector3(0, Rand.rand.Next(0, 360), 0);
            //            break;
            //        case NPC.NPC.NpcState.rotating://--->Requiere asignar un valor (-1 ó 1) para la rotación 
            //            float rot = 0;
            //            while (rot == 0)
            //            {
            //                rot = Rand.rand.Next(-1, 2);
            //                item.GetComponent<Zombie>().rot = rot;
            //            }
            //            break;
            //    }
            //}
        }
        
        public struct sNPC
        {
            public int age;
            public float speed;
        }
        public enum NpcState
        {
            idle,
            moving,
            rotating
        }
    }
    
}
