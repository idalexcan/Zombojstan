using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class General : MonoBehaviour
{
    GameObject person;
    GameObject yo;
    private void Start()
    {
        person = GameObject.CreatePrimitive(PrimitiveType.Cube);
        person.AddComponent<Humanoide.Person>();
        person.AddComponent<Rigidbody>();
        person.GetComponent<MeshRenderer>().material.color = Color.cyan;

        yo = GameObject.CreatePrimitive(PrimitiveType.Cube);
        yo.transform.position = new Vector3(2, 0, 0);
        yo.AddComponent<Humanoide.Yo>();
        yo.AddComponent<Rigidbody>();
        yo.GetComponent<MeshRenderer>().material.color = Color.black;

        int f = 4;
        f.ToString();
        
    }

    private void Update()
    {
        
    }
}
public class Humanoide : MonoBehaviour
{
    public int life;
    public string name;

    public class Person : Humanoide
    {
        public  bool oncol = false;
        private void Update()
        {

            transform.Rotate(0, 0.7f, 0);
        }
        //private void OnCollisionEnter(Collision collision)
        //{
        //    oncol = true;
        //}
    }
    public class Yo : Humanoide
    {
        float speed = 5;
        private void Update()
        {
            if (Input.GetKey("w")) { transform.position += transform.forward * (speed / 20); }
            if (Input.GetKey("s")) { transform.position -= transform.forward * (speed / 20); }
            if (Input.GetKey("d")) { transform.position += transform.right * (speed / 20); }
            if (Input.GetKey("a")) { transform.position -= transform.right * (speed / 20); }
        }
        
    }
}



