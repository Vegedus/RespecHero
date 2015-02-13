using UnityEngine;
using System.Linq;
using System.Collections;
using UnityEditor;
using System.Reflection;

[ExecuteInEditMode]
public class TextDynamicSpriteGUI : TextureGUIAbstract
{
    //public int orgScale = 15;
 
    public Vector2 relativePosition;
    public float offsetX;

    public Sprite textSheet;
    public GameObject textObject; //The object that contains the variable of the letter to be shown

    protected Sprite[] textSprites;

    protected MonoBehaviour charScript;
    protected PropertyInfo charVariable;

    protected SpriteRenderer currentSprite;
    protected float letter;

    void Awake() 
    {
        charScript = textObject.GetComponent<MonoBehaviour>();
        charVariable = charScript.GetType().GetProperty("guiChar");

        currentSprite = GetComponent<SpriteRenderer>();

        string spriteSheet = AssetDatabase.GetAssetPath(textSheet);
        textSprites = AssetDatabase.LoadAllAssetsAtPath(spriteSheet).OfType<Sprite>().ToArray();

        //print((int)'0'); //48
        //print((int)'A'); //65
        //print((int)'a'); //97
        //26+26+10
        
    }

    void OnGUI()
    {
        letter = (float)charVariable.GetValue(charScript, null);

        currentSprite.sprite = GetSpriteLetter((char)letter);
    }

    protected Sprite GetSpriteLetter(char letter)
    {
        int intLetter = (int)letter;
        int textureIndex = 0;
        if (intLetter >= 97) textureIndex = intLetter - 97 + 26;
        else if (intLetter >= 65) textureIndex = intLetter - 65;
        else if (intLetter >= 48) textureIndex = intLetter - 48 + 26 + 26;
        else if (intLetter <= 10) textureIndex = intLetter + 26 + 26;
        //print("j " + intLetter);
        //print(textureIndex);

        Rescale();
        return textSprites[textureIndex];
    }

    public override void Rescale()
    {
        //Sprite renders aren't GUI objects, so they're in world cordinates.
        //"Viewport" is the relative position, from 0,0 to 1,1.
        transform.position = Camera.main.ViewportToWorldPoint(
            new Vector3(relativePosition.x, relativePosition.y, 30)) + new Vector3(offsetX, 0, 0) ;
    }
}