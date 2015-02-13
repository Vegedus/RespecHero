using UnityEngine;
using System.Collections;

public class QuickAttack : Ability_Abstract {

    public QuickAttack(AbilityManager abilityManger) : base(abilityManger, 1.0f) { }

	override public bool Activate(Stats p) {
        if(!CheckAndSubstractAP()) return false;


        return true;
	}

}