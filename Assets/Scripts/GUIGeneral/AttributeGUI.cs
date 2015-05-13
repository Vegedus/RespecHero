using UnityEngine;
using System;
using System.Reflection;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;

public class AttributeGUI : MonoBehaviour {

    public GameObject statsObject;

    private Stats statsScript; //The script that contains the variable that indicates how full the bar should be
    //public PropertyInfo value;
    public AttributeName attribute;
    private GUIText textComponent;
    private string originalText;

    void Awake()
    {
        statsScript = statsObject.GetComponent<Stats>();
        //value = statsScript.GetType().GetProperty(valueVariableName);
        textComponent = GetComponent<GUIText>();
        originalText = textComponent.text;
    }

    void OnGUI()
    {
        
        textComponent.text =  originalText + statsScript.getAttribute(attribute).ToString();
    }

}
