using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour    
{
    public Light dLight;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            dLight.intensity = 0;
        }

    }
}
