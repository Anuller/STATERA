using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class maldi : MonoBehaviour
{
    public Animator effectmaldicion;

    void OnCollisionEnter2D(Collision2D collsion)
    {
        if (collsion.collider.CompareTag("Player"))
        {
            effectmaldicion.SetTrigger("maldição");
        }
    }
    
    
}
