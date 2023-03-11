using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disapear : MonoBehaviour
{

      
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject, 1);
        }
    }
}
