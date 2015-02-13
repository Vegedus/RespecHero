using UnityEngine;
using System.Collections;
using System;

//[ExecuteInEditMode]
[Serializable]
public class Stats : MonoBehaviour
{

	public Attribute[] attributes = {
		new Attribute (getAttribNameString (0),5),
		new Attribute (getAttribNameString (1),5),
		new Attribute (getAttribNameString (2),5),
		new Attribute (getAttribNameString (3),5),
		new Attribute (getAttribNameString (4),5),
		new Attribute (getAttribNameString (5),5),
		new Attribute (getAttribNameString (6),5),
		new Attribute (getAttribNameString (7),5) };
	
	public int power = 1;
	public float remainingLife = 10;
	public float remainingMana = 10;
	
	//Make sure the stats are correct when created
	public void Awake(){
		updateAllEffective();
		remainingLife = attributes[(int)AttributeName.life].current;
		remainingMana = attributes[(int)AttributeName.mana].current;
	}
	
	public static string getAttribNameString (int enumIndex){
		return ((AttributeName)enumIndex).ToString ();
	}
	
	public void setPower(int newPower){ power = newPower; updateAllEffective(); }
	public void incrementPower() { power++; }

	public void setSourceAtt(AttributeName statName, int value){
		attributes[(int)statName].source = value;
		updateAllEffective();
	}
		
	public void updateAllEffective(){
		for(int i = 0; i < attributes.Length; i++){
			attributes[i].effective = attributes[i].source * power;
		}
		updateAllCurrent();
	}
	
	public void resetAllModifiers(){
		for(int i = 0; i < attributes.Length; i++){
			attributes[i].modifier = 1.0f;
		}
		updateAllCurrent();
	}
	
	public void setModifier(AttributeName statName, int value){
		attributes[(int)statName].modifier = value;
		updateAllCurrent();
	}
	
	private void updateAllCurrent(){
		for(int i = 0; i < attributes.Length; i++){
			attributes[i].current = (float)attributes[i].effective * attributes[i].modifier;
			
		}
		checkRemaining();
	}

    //Gui related
    public float lifeFullness { get { return remainingLife / attributes[(int)AttributeName.life].current; } }
    public float manaFullness { get { return remainingMana / attributes[(int)AttributeName.mana].current; } }
	
	//In case the maximum values of life or mana has changed, make sure that the current life/mana stays within bounds
    public void checkRemaining()
    {
        remainingLife = Mathf.Clamp(remainingLife, -9999.0f, attributes[(int)AttributeName.life].current);
        remainingMana = Mathf.Clamp(remainingLife, -9999.0f, attributes[(int)AttributeName.mana].current);
    }
	
	public float getAttribute(AttributeName name){ return attributes[(int)name].current; }
	
}

