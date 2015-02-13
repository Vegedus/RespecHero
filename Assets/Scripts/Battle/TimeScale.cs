using UnityEngine;
using System.Collections;

public class TimeScale : MonoBehaviour {

	[Range(0,5)]
	public float timeScale = 1.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Time.timeScale = timeScale;
	}
}
