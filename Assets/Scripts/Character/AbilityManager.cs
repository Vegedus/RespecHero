using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AbilityManager : MonoBehaviour {

	//abstract public float executeTime{ get; set; }
    public ActionTimer timer;
    public Stats selfStats;
    public Stats opponentStats;
    public int abilityNr = 4;

    private Dictionary<int, Ability_Abstract> unlockedAbilities;
    private Ability_Abstract[] assignedAbilities;

    void Awake()
    {
        unlockedAbilities = new Dictionary<int,Ability_Abstract>(){{ 0, new QuickAttack(this) }};
        assignedAbilities = new Ability_Abstract[abilityNr];
        assignedAbilities[0] = unlockedAbilities[0]; 
    }

    public void useAbilityNr(int i)
    {
        //if(assignedAbilities[i] != null && timer.actionPoints < assignedAbilities[i].actionPointCost)
        if (assignedAbilities[i] != null && assignedAbilities[i].Activate(selfStats))
        {
            print("ability " + i + " activated successfully");
            //To do: Sound
            print("abi success");
            return;
        }
        print("abi fail");
        //To do: Sound
        
    }
	
}
