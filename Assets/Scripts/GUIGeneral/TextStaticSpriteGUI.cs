using UnityEngine;
using System.Linq;
using System.Collections;
using UnityEditor;
using System.Reflection;

[ExecuteInEditMode]
public class TextStaticSpriteGUI : TextDynamicSpriteGUI
{
    public string text; //Alternatively, the text can be inputted

    void Awake()
    {
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
       letter = text[0];

       currentSprite.sprite = GetSpriteLetter((char)letter);
    }

}