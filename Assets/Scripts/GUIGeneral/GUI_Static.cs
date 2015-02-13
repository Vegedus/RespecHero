using UnityEngine;
using System.Collections;

public class GUI_Static : MonoBehaviour{
    //Deprecated?
	//The resolution at which the game is developed. It is scales "from" this resolution.
	private static Vector2 nativeResolution = new Vector2 (800, 600);
	//private static Vector2 currentResolution;
	private static Camera mainCamera = Camera.main;

    private static int a  = 5;

	public static Vector2 getWorldPosition( Transform textureTransform, GUITexture textureComponent ){
		return mainCamera.ScreenToWorldPoint( textureTransform.position );
	}


	public static void DrawHorizontalProgressBar (Texture2D barFull, Vector2 position, Vector2 size, float barFullness)
	{	
		//Makes a gui group, but makes it smaller on the x-axis than the texture. This will effectively "crop"
		//the texture for that bar feel
		GUI.BeginGroup (new Rect (position.x, position.y, size.x * barFullness, size.y));
		//Draw the actual texture as full
		GUI.DrawTexture (new Rect (0, 0, size.x, size.y), barFull);
		GUI.EndGroup ();
	}
	
	public static void ScaleTexture (Transform transform, GUITexture textureObject, int baseSize)
	{
		//float scale = nativeResolution.y / Screen.height;
		
		//textureObject.fontSize = (int)Mathf.Round(baseSize * scale);
		
	}
	
	public static void ScaleText (Transform transform, GUIText textObject, int baseSize)
	{
		float scale = nativeResolution.y / Screen.height;
		
		textObject.fontSize = (int)Mathf.Round(baseSize * scale);
		print("text scaled");
		
	}
	
	//Resize the gui to match resolution with GUI.matrix. WILL resize everything, stretching textures if aspect ratio is changed
	//Not recommended and deprecated for the same reason
	public static void MatrixScale(){
		Vector2 resizeRatio = new Vector2((float)Screen.width / nativeResolution.x, (float)Screen.height / nativeResolution.y);
		GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, new Vector3(resizeRatio.x, resizeRatio.y, 1.0f));
	}
	
}