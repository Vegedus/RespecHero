using UnityEngine;
using System.Collections;
using System;
[Serializable]
public class StatsPlayer : MonoBehaviour {

	public Stats playerStats = new Stats();
	
	void Start () {
	}

	public void ModifyBaseStat(AttributeName statName, int value){

		//float effectiveRatio = stats[stat]/baseStats[stat];

		if((int)statName == 0 || (int)statName == 1){
		//	if(currentLife > effective.maxLife) currentLife = effective.maxLife;
			//if(currentMana > stats[stat] & stat == 0) currentMana = stats[stat];
		}

	}

	public void levelUp(){
		playerStats.power++;
	}

}
