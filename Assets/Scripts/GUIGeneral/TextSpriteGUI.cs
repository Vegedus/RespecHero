using UnityEngine;
using System.Linq;
using System.Collections;
using UnityEditor;
using System.Reflection;

[ExecuteInEditMode]
public class TextSpriteGUI : MonoBehaviour
{
    public char letter = '0';

    public Sprite textSheet;

    protected Sprite[] textSprites;
    protected SpriteRenderer currentSprite;

    void Start()
    {
        print(letter);

        currentSprite = GetComponent<SpriteRenderer>();

        string spriteSheet = AssetDatabase.GetAssetPath(textSheet);
        textSprites = AssetDatabase.LoadAllAssetsAtPath(spriteSheet).OfType<Sprite>().ToArray();

        //print((int)'0'); //48
        //print((int)'A'); //65
        //print((int)'letterScript'); //97
        //26+26+10

        currentSprite.sprite = GetSpriteLetter(letter);
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

        return textSprites[textureIndex];
    }

}