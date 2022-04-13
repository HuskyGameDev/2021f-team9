using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    public string name;

    [TextArea(3, 10)]
    public string[] scentences;

    public Dialogue(string name, string[] sentences)
    {
        this.name = name;
        this.scentences = sentences;
    }
}
