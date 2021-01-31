using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkingToNPCScript : InteractionScript
{
    public GameObject InteractUI;
    public DialogueBranch initialBranch;
    public DialogueBranch[] branches;

    public override void Start()
    {
        base.Start();
        interactThingy.transform.SetAsLastSibling();
    }

    public void InteractWithObject()
    {
        DialogueManager dialogueManager = InteractUI.GetComponent<DialogueManager>();
        InteractUI = (GameObject)Resources.Load("TalkingUI");
        if (interactActive)
        {
            if(initialBranch != null)
            {
                UnlockCursor();

                dialogueManager.NPC = this.gameObject;
                dialogueManager.dialogueBranches = branches;
                if (initialBranch.endPoint != null)
                    dialogueManager.lines = new DialogueLine[initialBranch.dialogueLines.Length + 1];
                else
                    dialogueManager.lines = new DialogueLine[initialBranch.dialogueLines.Length];

                for (int i = 0; i < dialogueManager.lines.Length - 1; i++)
                {
                    dialogueManager.lines[i] = initialBranch.dialogueLines[i];
                }
                if (initialBranch.endPoint != null)
                    dialogueManager.lines[dialogueManager.lines.Length - 1] = initialBranch.endPoint;

                InteractUI = Instantiate(InteractUI);
            }
        }
        //else if (dialogueManager.continueButton.activeInHierarchy)
        //{
        //    Debug.Log("works?");
        //    dialogueManager.NextSentence();
        //}
    }

    public void OnEndConvo()
    {
        LockCursor();
    }

    public void ResetUIVariable()
    {
        InteractUI = (GameObject)Resources.Load("TalkingUI");
    }

    public void LockCursor()
    {
        //put focus on dialogue
    }

    public void UnlockCursor()
    {
        //put focus on game
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;

        Gizmos.DrawWireSphere(transform.position, interactableDistance);
    }

}
