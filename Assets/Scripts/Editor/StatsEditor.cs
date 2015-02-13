using UnityEngine;
using System.Collections;
using UnityEditor;

//[CustomEditor(typeof(StatsPlayer))]
/*public class StatsEditor : Editor
{
	private StatsPlayer statsPlayer;
	private SerializedObject serializedObject;
	private SerializedProperty property;

	public void OnEnable()
	{		
		statsPlayer = (StatsPlayer)target;		
		serializedObject = new SerializedObject (statsPlayer);
		property = serializedObject.GetIterator ();		
	}
	
	public override void OnInspectorGUI ()
	{
		/*property.Reset();
		property.Next (true);
		do {
			if(property.name == "power") EditorGUILayout.IntField("power2", statsPlayer.power);
			if(property.name != "object Hide Flags") EditorGUILayout.PropertyField(property);
		} while (property.NextVisible(false));

		if (GUI.changed) EditorUtility.SetDirty (target);
		
		//DrawDefaultInspector ();
		//if (GUILayout.Button ("Build Object")) {}
	}
}*/