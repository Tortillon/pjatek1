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
    public List<string> BannedNamesList;


    void Start()
    {

        NameHim.text = "This is you. Name yourself or generate a random name.";
        Nice.text = "Accept by clicking space";
        inputField.onValidateInput +=
        delegate (string s, int i, char c) { return char.ToUpper(c); };

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
        for (int i = 0; i < BannedNames.Length; i++)
        {
            if (inputField.text == BannedNames[i] || inputField.text == BannedNamesList[i])
            {
                return false;
            }

        }
        return true;

    }
    string RandomNameGenerator()
    {
        string characters = "BCDEGHIJKLMNOPQSTUVWXY";
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


   

}
