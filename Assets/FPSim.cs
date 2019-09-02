using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSim : MonoBehaviour
{
    /// <summary>
    /// 1. se importa la posición del la clase Hero (heroe) para efectuar la primera persona
    /// 2. x y y utilizan los valores de posición del mause para mover la cámara
    /// 3. la variable estática de rotY (valor en eulers del eje Y) será utilizada para 
    /// guiar la trayectoria del heroe con forward y right
    /// </summary>
    public static float rotY;
    float x = 0, y = 0;

    void Update()
    {
        transform.position = General.hero.GetComponent<Hero>().pos;
        x -= Input.GetAxis("Mouse Y");
        y += Input.GetAxis("Mouse X");
        transform.eulerAngles = new Vector3(x, y, 0);
        rotY = transform.eulerAngles.y;
    }
    
}
