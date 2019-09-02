using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NPC
{
    public class NPC : MonoBehaviour
    {
        public NpcState state;
        private void Awake()
        {
            
        }
        private void Update()
        {
            
        }
        public struct sNPC
        {
            public int age;
            public float velocity;
        }
        public enum NpcState
        {
            idle,
            moving,
            rotating,
            action
        }
    }
    
}
