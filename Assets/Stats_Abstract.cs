using UnityEngine;
using System.Collections;
using System;
using UnityEngine.Events;

public abstract class StatsAbstract : MonoBehaviour {

    public string name;
    public int source = 5;
    public float modifier = 1.0f;
    public float effective { get {return source * modifier; }}

    [Serializable]
    public class StatEvent : UnityEvent<String>{};
    public StatEvent onStatChange;

    public StatsAbstract(int initialValue)
    {
        source = initialValue;
        modifier = 1.0f;
    }
}
