using UnityEngine;
using System.Collections;

public class ActionTimer : MonoBehaviour
{

    // Use this for initialization
    [Range(0, 7)]
    public float actionPoints = 0;
    public float pointMax = 5;
    public bool maxed = false;

    public float actionFullness
    {
        get
        {
            if (maxed) return 1.0f;
            return (actionPoints - (int)actionPoints);
        }
    }
    public float guiChar { get { return (char)actionPoints; } }
    public float actionPointsObj { get { return actionPoints; } }

    public Stats stats;

    void Start()
    {
        stats = transform.parent.GetComponentInChildren<Stats>();
    }

    void Update()
    {

        if (actionPoints < pointMax) maxed = false;

        if (!maxed) actionPoints += stats.getAttribute(AttributeName.speed) * Time.deltaTime;

        if (actionPoints >= pointMax) { actionPoints = pointMax; maxed = true; }
    }
}