using UnityEngine;
using System.Collections;

public class BattleControl : MonoBehaviour {

    public AbilityManager playerAbilities;

	void Awake () {
        //print( FindObjectsOfType(typeof(AbilityManager))[0]) ;
        //ability1 = 
	}
	
	void Update () {
        for (int i = 0; i < playerAbilities.abilityNr; i++)
        {
            if (Input.GetButtonDown("Ability "+i))
            {
                playerAbilities.useAbilityNr(i);
            }
        }
	}

    void setAbility(AbilityManager ability, int nr)
    {
    }

}
