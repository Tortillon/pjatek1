using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour    
{
    public Light dLight;
    private GameObject[] allLights;
    private bool toggleLight=true;
    private void Start()
    {
        allLights = GameObject.FindGameObjectsWithTag("inLight");
        for (int i=0; i<allLights.Length; i++)
        {
                allLights[i].SetActive(false);
        }
        
    }

    IEnumerator Waiter()
    {
        if (toggleLight == true) dLight.intensity = 0;
        else dLight.intensity = 1;
        for (int i = 0; i < allLights.Length; i++)
        {
            allLights[i].SetActive(toggleLight);
            yield return new WaitForSeconds(0.1F);
        }
        toggleLight = !toggleLight;
         
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Door"))
        {
            StartCoroutine(Waiter());
        }
    }
}
