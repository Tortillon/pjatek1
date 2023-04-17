using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disable : MonoBehaviour
{
    public Light dLight;
    public Light lLight;
    // Start is called before the first frame update
    void Start()
    {
        lLight.intensity = 0;
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("dupa");
            dLight.intensity = 0;
            lLight.intensity = 5;
        }
    }
    
}
