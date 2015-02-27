using UnityEngine;
using System.Collections;

//[ExecuteInEditMode]
public class TextStringSpriteGUI : MonoBehaviour {

    public string word;
    public bool dynamic;

    //public GameObject DynamicLetter;
    //public GameObject StaticLetter;

    public GameObject letterType;

	void Start () {
        //if (dynamic) letterType = DynamicLetter;
        //else letterType = StaticLetter;
        createLetters();
    }

    void createLetters() 
    {
        for (int i = 0; i < word.Length; i++)
        {
            GameObject letter = (GameObject)Instantiate(letterType, transform.position + new Vector3(i*0.7f,0,0), Quaternion.identity);
            letter.transform.parent = transform;
            TextSpriteGUI letterScript = letter.GetComponent<TextSpriteGUI>();
            letterScript.letter = word[i];
        }
    }

    void LateUpdate()
    {
        if (dynamic)
        {
            foreach (Transform child in transform )
            {
                GameObject.Destroy(child.gameObject);
            }
            createLetters();
        }
	}
}