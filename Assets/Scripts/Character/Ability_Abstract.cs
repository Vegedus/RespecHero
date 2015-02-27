using UnityEngine;
using System.Collections;

public abstract class Ability_Abstract : Ability_Interface {

    private readonly float actionPointCost = 4;
    private AbilityManager abilityManager;
    private Stats oppStats;
    private Stats selfStats;
    private ActionTimer timer;
    private float AbilityBonus;


    private float actionPointsObj;

    protected Ability_Abstract(AbilityManager abilities, float cost)
    {
        actionPointCost = cost;
        this.abilityManager = abilities;
        actionPointsObj = abilityManager.timer.actionPointsObj;
        timer = abilityManager.timer;
    }
    
    abstract public bool Activate(Stats p);


    public bool CheckAndSubstractAP()
    {
        Debug.Log(actionPointsObj + " action");
        if (abilityManager.timer.actionPoints > actionPointCost)
        {
            
            abilityManager.timer.actionPoints -= actionPointCost;
            Debug.Log(abilityManager.timer.actionPoints + " letterScript");
            return true;
        }
        return false;
    }

    public void dealDamage(int abilityBonus)
    {
        Stats selfStats = abilityManager.selfStats;
        //pierce. = abilityManager.opponentStats;
        

    }

}