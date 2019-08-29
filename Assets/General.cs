using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class General : MonoBehaviour
{
    
    void Start()
    {
        GameObject copito = GameObject.CreatePrimitive(PrimitiveType.Cube) as GameObject;
        copito.AddComponent<Alpinito>();

        
    }
    
    public virtual void Print()
    {
        Debug.Log("capuccino rossini");
        
    }
    
}

public class Alpinito : General
{
    private void Start()
    {
        int c = 4;
        
    }
    public override void Print()
    {
        Debug.Log("capuccino rossini bambini paganini peperoni");

    }

    

}

