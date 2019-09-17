using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NPC.Ally;
using NPC.Enemy;
using NPC;
using UnityEngine.UI;

public class Hero : MonoBehaviour
{
    /// <summary>
    /// < pos para acceder a la posición del héroe
    /// < speed velocidad del héroe
    /// < speedaux una variable auxiliar que permite variar la velocidad
    /// < villagertext se activa al tocar un aldeano para representar que se está mostrando el saludo de un aldeano 
    /// < closezombie 
    /// </summary>
    /// 
    public Vector3 pos;
    readonly float speed;
    float speedaux;
    bool villagertext;
    GameObject closezombie;
    GameObject canvas;

    public Hero()
    {
        speed = Rand.Float(1, 2);
    }///-----------------------------------------------------------<| CONSTRUCTOR    

    //----------------------------------------------------------------------------------------------------------------------|
    ///------------------------------------------<|MÉTODOS DE COMPORTAMIENTO|>----------------------------------------------|
    
    private void Awake()
    {
        
        canvas = GameObject.Find("MeroCanvas");
    }
    
    void Update()
    {
        Move();
        CloseZombieVerify();
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.GetComponent<Villager>())
        {
            villagertext = true;
            canvas.GetComponent<CanvasManager>().message.text = col.gameObject.GetComponent<Villager>().Print();
        }
        
        if (col.gameObject.GetComponent<Zombie>())
        {

            General.rungame = false;
        }
        if (General.rungame)
        {
            StartCoroutine("RestartMessage");
        }
    }

    //----------------------------------------------------------------------------------------------------------------------|
    ///-----------------------------------------------<|MÉTODOS DE CLASE|>--------------------------------------------------|

    void Move()
    {
        if (General.rungame)
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

        }
    }

    void CloseZombieVerify()
    {
        foreach (var item in FindObjectsOfType(typeof(GameObject)) as GameObject[])
        {

            if (item.GetComponent<Zombie>())
            {
                if ((item.GetComponent<Zombie>().transform.position - transform.position).magnitude <= 5 && General.rungame)
                {
                    closezombie = item;
                    break;
                }
                else if (!villagertext)
                {
                    closezombie = null;
                }
            }
        }
        if (closezombie != null)
        {
            canvas.GetComponent<CanvasManager>().message.text = closezombie.gameObject.GetComponent<Zombie>().Print();
        }
        else
        {
            if (!villagertext)
            {
                canvas.GetComponent<CanvasManager>().message.text = "";
            }
        }
    }

    IEnumerator RestartMessage()
    {
        yield return new WaitForSeconds(1.5f);
        GameObject canvas = GameObject.Find("MeroCanvas");
        canvas.GetComponent<CanvasManager>().message.text = "";
        villagertext = false;

    }
}
