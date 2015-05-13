using UnityEngine;
using System.Collections;
using System;

//Used to make the label of the "Power" stat grow larger as the number grows
public class PowerSizeGUI : MonoBehaviour {
    [SerializeField]
    private Vector3 originalScale;
    private GUIText textComponent;

	void Awake () {
        originalScale = transform.localScale;
        textComponent = GetComponent<GUIText>();
	}
	
	void OnGUI () {
        transform.localScale = originalScale * Mathf.Clamp(Convert.ToSingle(textComponent.text)/50.0f+1.0f,1.0f,4.5f);
	}
}
