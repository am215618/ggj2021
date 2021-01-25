using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Dialogue Branch", menuName = "Dialogue/Dialogue Branch")]
public class DialogueBranch : ScriptableObject
{
    public DialogueLine[] dialogueLines;
    public DialogueLine endPoint;
}
