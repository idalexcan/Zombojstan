using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NPC
{
    public class NPC : MonoBehaviour
    {

        public NpcState state;
        //public bool inaction = false;
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
