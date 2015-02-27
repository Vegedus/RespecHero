using UnityEngine;
using System;
using System.Reflection;
using System.Collections;
using UnityEngine.UI;

//[ExecuteInEditMode]
public class ProgressBarGUI : MonoBehaviour{

    //public Texture2D barEmpty;
    //public Texture2D barFull;
    //[Space(5)]
    public GameObject fullnessObject;
    public String fullnessVarName;

    public MonoBehaviour fullnessScript; //The script that contains the variable that indicates how full the bar should be
    public PropertyInfo fullnessVariable;

    private Image image;
    
    void Awake()
    {
        image = GetComponent<Image>();
        fullnessScript = fullnessObject.GetComponent<MonoBehaviour>();
        fullnessVariable = fullnessScript.GetType().GetProperty(fullnessVarName);
    }

    void OnGUI()
    {
        image.fillAmount = (float)fullnessVariable.GetValue(fullnessScript, null);
    }
}