using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamasDialogue : MonoBehaviour
{
    public int progressEvent;
    CurrentChatState progressState;
    OnTriggerPressed trigger;

    DialogueManager dialogManager;
    public DialogueLine[] linesNormal;
    public DialogueLine[] linesGoop;
    public DialogueLine[] linesA;
    public DialogueLine[] linesB;
    public DialogueLine[] linesC;
    public DialogueLine[] linesD;

    public bool hasMultipleEvents;
    bool updateEvent;

    //public int progressEvent;

    //public BoxCollider2D playerCol;
    //public Rigidbody2D playerRb;

    bool inRangeOfPlayer;
    public bool eventStarted;
    bool leaving;

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
        if (progressEvent == 1 && updateEvent)
        {
            progressState = CurrentChatState.a;
            updateEvent = false;
        }
        else if (progressEvent == 2 && updateEvent)
        {
            progressState = CurrentChatState.b;
            updateEvent = false;
        }
        else if (progressEvent == 3 && updateEvent)
        {
            progressState = CurrentChatState.c;
            updateEvent = false;
        }
        

        if (inRangeOfPlayer && !eventStarted && Input.GetKeyDown(KeyCode.E))
        {
            StartEvent();
        }
        else if (eventStarted && Input.GetKeyDown(KeyCode.E))
        {
            dialogManager.NextSentence();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
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
        
        switch (progressState)
        {
            case CurrentChatState.normal:
                dialogManager.lines = linesNormal;
                break;
            case CurrentChatState.a:
                dialogManager.lines = linesGoop;
                break;
            case CurrentChatState.b:
                dialogManager.lines = linesA;
                break;
            case CurrentChatState.c:
                dialogManager.lines = linesB;
                break;
        }
        
        /*if (!dialogManager.NextSentence()) {
            eventStarted = false;
            }
        }*/
        dialogManager.NPC = this.gameObject;
        Debug.Log(linesNormal[0].line.ToCharArray().Length);
        PlayerManager.instance.player.SetPlayerState(PlayerState.Dialogue);
        Time.timeScale = 0f;
    }

    public void ChangeChat(CurrentChatState newState)
    {
        progressState = newState;
    }

    public void Leave()
    {
        transform.position = new Vector3(-10.4f, 0.64f, 0);
    }
}
