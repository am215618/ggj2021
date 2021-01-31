using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamasDialogue : MonoBehaviour
{
    CurrentChatState whereTheFuckingPlayerIsUpToLol;
    OnTriggerPressed trigger;

    DialogueManager dialogManager;
    public DialogueLine[] linesNormal;
    public DialogueLine[] linesA;
    public DialogueLine[] linesB;
    public DialogueLine[] linesC;
    public DialogueLine[] linesD;
    //public BoxCollider2D playerCol;
    //public Rigidbody2D playerRb;
    bool inRangeOfPlayer;
    bool eventStarted;

    // Start is called before the first frame update
    void Start()
    {
        dialogManager = PlayerManager.instance.dialogueManager;
        dialogManager.UIDisplay.SetActive(false);

        trigger += ChangeChat;
    }

    // Update is called once per frame
    void Update()
    {
        if (inRangeOfPlayer && !eventStarted && Input.GetKeyDown(KeyCode.E))
        {
            StartEvent();
        }
        else if (eventStarted && Input.GetKeyDown(KeyCode.E))
        {
            dialogManager.NextSentence();
        }
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.GetComponent<PlayerController>())
        {
            inRangeOfPlayer = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        inRangeOfPlayer = false;
    }

    void StartEvent()
    {
        dialogManager.UIDisplay.SetActive(true);
        eventStarted = true;
        switch (whereTheFuckingPlayerIsUpToLol)
        {
            case CurrentChatState.normal:
                dialogManager.lines = linesNormal;
                break;
            case CurrentChatState.a:
                dialogManager.lines = linesA;
                break;
            case CurrentChatState.b:
                dialogManager.lines = linesB;
                break;
            case CurrentChatState.c:
                dialogManager.lines = linesC;
                break;
            case CurrentChatState.d:
                dialogManager.lines = linesD;
                break;
        }
        
        dialogManager.NextSentence();
        Debug.Log(linesNormal[0].line.ToCharArray().Length);
        PlayerManager.instance.player.SetPlayerState(PlayerState.Dialogue);
        Time.timeScale = 0f;
    }

    public void ChangeChat(CurrentChatState newState)
    {
        whereTheFuckingPlayerIsUpToLol = newState;
    }

}
