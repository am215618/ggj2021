using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Line", menuName = "Dialogue/Line")]
public class DialogueLine : ScriptableObject
{
    public string characterSpeaking;
    [TextArea(4,10)]
    public string line;
    public bool endAutomatically;
    public float endAfterSeconds;
    public bool endImmediatly;
}
