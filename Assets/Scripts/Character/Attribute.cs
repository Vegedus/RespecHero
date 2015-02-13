using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class Attribute
{
    public string name;
    [Range(0, 10)]
    public int source = 5;
    //[Range(0, 10)]
    public int effective;
    [Range(-3.0f, 3.0f)]
    public float modifier = 1.0f;
    public float current;

    public Attribute(String name, int defaultValue)
    {
        this.name = name;
        source = defaultValue;
    }
}