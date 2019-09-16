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

        private void Start()
        {
            StartCoroutine("ChangeVar");
        }

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

        IEnumerator ChangeVar()
        {
            for (; ; )
            {
                state = (NpcState)Random.Range(1, 3);
                switch (state)
                {
                    case NpcState.idle:
                        break;
                    case NpcState.moving:
                        transform.eulerAngles = new Vector3(0, Random.Range(0, 360), 0);
                        break;
                    case NpcState.rotating:
                        float rot = 0;
                        while (rot == 0)
                        {
                            rot = Rand.rand.Next(-1, 2);
                        }
                        break;
                }
                yield return new WaitForSeconds(5);
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
