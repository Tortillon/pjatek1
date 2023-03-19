using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Collector : MonoBehaviour
{
    private int pills = 0;

    public TextMeshProUGUI pillsCount;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Pill"))
        {
            Destroy(collision.gameObject);
            pills++;
            pillsCount.text = "PILLS: " + pills;

        }
    }
}

