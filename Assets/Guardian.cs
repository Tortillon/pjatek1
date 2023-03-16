using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;
using JetBrains.Annotations;

public class Guardian : MonoBehaviour
{
    private int lives = 0;
    int num = Random.Range(3, 7);

    public TextMeshProUGUI talk;
    public TextMeshProUGUI hp;



    string RandomStringGenerator(int lenght)
    {
        string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
        string password = "";

        for (int i = 0; i < lenght; i++)
            password += characters[Random.Range(0, lenght)];

        return password;
    }



    void Start()
    {
        
        RandomStringGenerator(num);

        Debug.Log(password);
       
    }
}
