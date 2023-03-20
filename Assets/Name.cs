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
    public TextMeshProUGUI Banned;
    public List<string> BannedNamesList;


    void Start()
    {

        NameHim.text = "This is you. Name yourself or generate a random name. Some names are banned.";
        Nice.text = "Accept by clicking space";
        Banned.text = "Hold button to see banned names.";
    }
    void Update()
    {
        if (UnityEngine.Input.GetKeyDown(KeyCode.Space))
        {
            if (IsNameAllowed(inputField))
            {
                Nice.text = "That's a great name!";
                StartCoroutine(LoadLevel());
            }
            else
            {
                Nice.text = "This name is banned :( Choose another name.";
            }
        }
    }

    public bool IsNameAllowed(TMP_InputField input)

    {
        for (int i = 0; i < BannedNamesList.Capacity; i++)
        {
            if (inputField.text == BannedNamesList[i])
            {
                return false;
            }

        }
        return true;

    }
    string RandomNameGenerator()
    {
        string characters = "ABCDEFGHIJKLMNOPQRSTUVWXY";
        string randomName = "";

        int l = Random.Range(3, 7);

        for (int i = 0; i < l; i++)

            randomName += characters[Random.Range(0, l)];

        return randomName;
    }

    

    public void OnButtonClick(TMP_InputField input)
    {
        inputField.text = RandomNameGenerator();
        Nice.text = "That's a great name!";
        StartCoroutine(LoadLevel());
    }

    private IEnumerator LoadLevel()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    private IEnumerator ShowTime(TextMeshProUGUI banned)
    {
        yield return new WaitForSeconds(2);
        banned.text = "";
    }
    public void OnButtonCLick(TextMeshProUGUI banned)
    {
        banned.text = "";
        for (int i = 0;i < BannedNamesList.Capacity;i++)
        {
            banned.text += BannedNamesList[i];
            if (i != BannedNamesList.Capacity-1)
            {
                banned.text += ", ";
            }
        }
        ShowTime(banned);
    }
   

}
