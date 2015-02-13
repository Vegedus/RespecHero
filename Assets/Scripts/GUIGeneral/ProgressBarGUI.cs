using UnityEngine;
using System;
using System.Reflection;

[ExecuteInEditMode]
public class ProgressBarGUI : TextureGUIAbstract {

    public Texture2D barEmpty;
    public Texture2D barFull;
    [Space(5)]
    public GameObject fullnessObject;
    public String fullnessVarName;

    public float modifiedScale;
    public bool vertical; //Whether the bar should charge in a vertical direction
    public bool reverse; //Whether it should charge the opposite direction
    //public bool cycling; //Whether it empties at max, and should stay full at max capacity (e.g. for Action points

    
    public MonoBehaviour fullnessScript; //The script that contains the variable that indicates how full the bar should be
    public PropertyInfo fullnessVariable;

    private Vector2 position; //As in, the position the drawTexture uses, screen/pixel coordinates
    public Vector2 size; //Ditto

    void Awake()
    {
        fullnessScript = fullnessObject.GetComponent<MonoBehaviour>();
        fullnessVariable = fullnessScript.GetType().GetProperty(fullnessVarName);
        Rescale();
    }

    void OnGUI()
    {
        GUI.DrawTexture(new Rect(position.x, position.y, size.x, size.y), barEmpty);
        
        float fullness = (float)fullnessVariable.GetValue(fullnessScript, null);

        //Reduce either the vertical or horizontal size of the bar's group, effectively cropping it
        if (vertical) GUI.BeginGroup(new Rect(position.x, position.y, size.x, size.y * fullness ));
        else GUI.BeginGroup(new Rect(position.x, position.y, size.x * fullness, size.y));
        //Draw the actual texture as full
        GUI.DrawTexture(new Rect(0, 0, size.x, size.y), barFull);
        GUI.EndGroup();
    }

    public override void Rescale()
    {
        //if (anchoredRight)
        float scale = (float)Screen.height / WindowEvent.NativeScreenHeight * transform.localScale.x;
        size = new Vector2(barEmpty.width * scale * modifiedScale, barEmpty.height * scale * modifiedScale);
        //Tranform to pixel position. Y-axis reversed because GUI starts at top left, while screen starts at bottom right. Dumb!
        position = new Vector2(transform.position.x * Screen.width, (1 - transform.position.y) * Screen.height);
    }
}