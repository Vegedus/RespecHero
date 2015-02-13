using UnityEngine;
using System.Collections;

public class WindowEvent : MonoBehaviour {

    public const int NativeScreenWidth = 800;
    public const int NativeScreenHeight = 600;

	private Vector2 oldResolution = new Vector2(Screen.width, Screen.height);

	public delegate void WindowAction();
	public static event WindowAction WindowResized;

	void Update()
	{
		if(WindowResized != null && oldResolution.x != Screen.width || oldResolution.y != Screen.height){
			WindowResized();
			oldResolution = new Vector2(Screen.width, Screen.height);
            
		}

	}	
	
}