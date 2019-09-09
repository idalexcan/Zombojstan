using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NPC.Ally;
using NPC.Enemy;
using NPC;

public class Hero : MonoBehaviour
{
    /// <summary>
    /// < pos para acceder a la posición del héroe
    /// < speed velocidad del héroe
    /// < canJump para saber cuando toca el suelo
    /// </summary>
    public Vector3 pos;
    readonly float speed;
    float speedaux;
    bool canJump = false;
    public float zombodistance;

    
    public Hero()
    {
        speed = Rand.Float(1, 2);
        
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speedaux = speed * 2f;
        }
        else
        {
            speedaux = speed;
        }
        transform.eulerAngles = new Vector3(0, FPSim.rotY, 0);
        if (Input.GetKey("w")) { transform.position += transform.forward * (speedaux / 10); }
        if (Input.GetKey("s")) { transform.position -= transform.forward * (speedaux / 10); }
        if (Input.GetKey("d")) { transform.position += transform.right * (speedaux / 10); }
        if (Input.GetKey("a")) { transform.position -= transform.right * (speedaux / 10); }
        pos = transform.position;
        if ((Input.GetKeyDown(KeyCode.Space)) && (canJump))
        {
            this.GetComponent<Rigidbody>().AddForce(Vector3.up * 200);
            canJump = false;
        }
        
    }

    private void OnCollisionEnter(Collision col)
    {
        canJump = true;
        //if (col.gameObject.GetComponent<Villager>())
        //{
        //    col.gameObject.GetComponent<Villager>().Print();
        //}
        //if (col.gameObject.GetComponent<Zombie>())
        //{
        //    col.gameObject.GetComponent<Zombie>().Print();
        //}
    }
}
