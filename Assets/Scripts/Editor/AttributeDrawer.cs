using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomPropertyDrawer (typeof(Attribute))]
class AttributeDrawer : PropertyDrawer
{	
	public override float GetPropertyHeight (SerializedProperty property, GUIContent label)
	{
		return base.GetPropertyHeight (property, label)*3;
	}
	
	// Draw the property inside the given rect
	public override void OnGUI (Rect position, SerializedProperty property, GUIContent label)
	{
		// Using BeginProperty / EndProperty on the parent property means that
		// prefab override logic works on the entire property.
		EditorGUI.BeginProperty (position, label, property);
		
		// Draw label
		position = EditorGUI.PrefixLabel (position, GUIUtility.GetControlID (FocusType.Passive), label);
		
		// Don't make child fields be indented
		var indent = EditorGUI.indentLevel;
		EditorGUI.indentLevel = 0;
		
		// Calculate rects
		Rect currentRect = new Rect (position.x*0.28f, position.y						, position.width * 1.5f, position.height/3);
		
		Rect effectiveRect = new Rect (position.x*0.28f, position.y + position.height/3	, position.width * 0.75f, position.height/3);
		Rect modifierRect = new Rect (position.x*0.28f*4, position.y + position.height/3, position.width * 0.75f, position.height/3);
		
		Rect sourceRect = new Rect (position.x*0.28f, position.y + 2*position.height/3, position.width * 1.5f, position.height/3);
		
		// Draw fields - passs GUIContent.none to each so they are drawn without labels
		string tabs = "";
		for(int i = 0; i < position.width; i+=50) tabs += "\t";
		
		EditorGUI.PropertyField (currentRect, property.FindPropertyRelative ("current"), new GUIContent(tabs+"current:") );
		
		EditorGUI.PropertyField (effectiveRect, property.FindPropertyRelative ("effective"), new GUIContent(tabs+"Effective:") );
		EditorGUI.PropertyField (modifierRect, property.FindPropertyRelative ("modifier"), new GUIContent(tabs+"Modifier:") );
		
		
		EditorGUI.PropertyField (sourceRect, property.FindPropertyRelative ("source"), new GUIContent(tabs+"Source:") );
		
		//GUIContent[] labels = {new GUIContent("S:\t"), new GUIContent("E:\t")} ;
		
		// Set indent back to what it was
		EditorGUI.indentLevel = indent;
		
		//Update sub-values when GUI changes
		//if (GUI.changed) { Stats.updateAllEffective(); }
		
		
		
		EditorGUI.EndProperty ();
	}
}