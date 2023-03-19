using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DisableSpaces : MonoBehaviour
{
    public TMP_InputField inputField;

    void Start()
    {
        inputField.onValueChanged.AddListener(delegate { RemoveSpaces(); });
    }

    void RemoveSpaces()
    {
        inputField.text = inputField.text.Replace(" ", "");
    }
}
