using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSim : MonoBehaviour
{
    public static float rotY;
    float x = 0, y = 0;

    private void Start()
    {
        transform.position = new Vector3(General.hero.GetComponent<Hero>().pos.x, General.hero.GetComponent<Hero>().pos.y + 2, General.hero.GetComponent<Hero>().pos.z);
    }
    void Update()
    {
        if (General.rungame)
        {
            transform.position = new Vector3(General.hero.GetComponent<Hero>().pos.x, General.hero.GetComponent<Hero>().pos.y + 2, General.hero.GetComponent<Hero>().pos.z);

            x -= Input.GetAxis("Mouse Y");
            y += Input.GetAxis("Mouse X");
            transform.eulerAngles = new Vector3(x, y, 0);
            rotY = transform.eulerAngles.y;
        }
    }
    
}
