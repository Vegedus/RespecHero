using UnityEngine;
using System;
using System.Reflection;
using System.Collections;
using UnityEngine.UI;

public class GenericValueGUI : MonoBehaviour {

    public GameObject fullnessObject;
    public String fullnessVarName;

    private MonoBehaviour fullnessScript; //The script that contains the variable that indicates how full the bar should be
    public PropertyInfo fullnessVariable;
    
    void Awake()
    {
        fullnessScript = fullnessObject.GetComponent<MonoBehaviour>();
        fullnessVariable = fullnessScript.GetType().GetProperty(fullnessVarName);
    }

    void OnGUI()
    {
    }
}
