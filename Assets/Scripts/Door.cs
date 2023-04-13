using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour    
{
    readonly Light light;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            light.intensity = 0;
        }

    }
}
