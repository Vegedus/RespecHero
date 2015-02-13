using UnityEngine;
using System.Collections;

public abstract class GUIAbstract : MonoBehaviour {

	//const Vector2 NativeResolution = new Vector2 (800, 600);

	void OnEnable()
	{
		WindowEvent.WindowResized += Rescale;
	}
	
	void OnDisable()
	{
		WindowEvent.WindowResized -= Rescale;
	}
    void OnDestroy()
    {
        WindowEvent.WindowResized -= Rescale;
    }
	
	public abstract void Rescale();
}