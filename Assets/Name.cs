using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;
using JetBrains.Annotations;
using System.ComponentModel;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
using UnityEngine.Windows;

public class Name : MonoBehaviour
{
    public TextMeshProUGUI NameHim;
    public TextMeshProUGUI Nice;
    public TMP_InputField inputField;
    private string[] BannedNames = {"BOB", "JEFF", "POPO"};



    void Start()
    {

        NameHim.text = "This is you. Name yourself or generate a random name.";
        Nice.text = "";

    }
    void Update()
    {
        if (UnityEngine.Input.GetKeyDown(KeyCode.RightShift))
        {
            if (IsNameAllowed(inputField))
            {
                Nice.text = "That's a great name!";
            }
            else
            {
                Nice.text = "This name is banned ¯\\_(ツ)_/¯ Choose another name.";
            }
        }
    }


    string RandomNameGenerator()
    {
        string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
        string randomName = "";

        int l = Random.Range(3, 7);

        for (int i = 0; i < l; i++)

            randomName += characters[Random.Range(0, l)];

        return randomName;
    }

    public bool IsNameAllowed(TMP_InputField input)

    {
        for (int i = 0; i < BannedNames.Length; i++)
        {
            if (inputField.text == BannedNames[i])
            {
                return false;
            }

        }
        return true;

    }

    public void OnButtonClick(TMP_InputField input)
    {
        inputField.text = RandomNameGenerator();
        Nice.text = "That's a great name!";
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }




   

}
