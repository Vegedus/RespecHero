using UnityEngine;
using System;
using System.Reflection;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;


public class GenericValueGUI : MonoBehaviour {

    public GameObject valueObject;
    public String valueVariableName;

    private MonoBehaviour valueScript; //The script that contains the variable that indicates how full the bar should be
    public PropertyInfo value;
    
    private GUIText textComponent;
    private String originalText;
    //public UnityEvent events;

    void Awake()
    {
        valueScript = valueObject.GetComponent<MonoBehaviour>();
        value = valueScript.GetType().GetProperty(valueVariableName);
        textComponent = GetComponent<GUIText>();
        originalText = textComponent.text;
    }

    void ChangeText(String newText)
    {
        textComponent.text = originalText + newText;
    }

    /*void OnGUI()
    {
        textComponent.text = originalText + (float)value.GetValue(valueScript, null);
        transform.localScale = new Vector3(3, 2, 1);
    }*/
}
