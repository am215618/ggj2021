using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DialogueManager : MonoBehaviour
{
    public GameObject gamasDialogue;
    public GameObject soundTransition;
    public TextMeshProUGUI characterNameText;
    public Text textDisplay;
    public DialogueLine[] lines;

    public GameObject UIDisplay;

    [HideInInspector]
    public GameObject NPC;

    public float typingSpeed;

    public GameObject gloopScript;

    //public GameObject optionsBox;
    //public GameObject continueButton;

    public Button button;

    [SerializeField] int index = -1;
    //float timePassed;
    //Button[] optionButtons;

    bool canContinue;
    bool canTypeToDisplay;

    public bool tutorialButtonBothOptsSelected;
    [SerializeField] float textTypingTimer = -1;
    [SerializeField] int letterIndex = -1;
    
    // Start is called before the first frame update
    void Start()
    {
        textDisplay.text = "";
        canContinue = false;
        /*if(lines == null)
        {
            lines = new DialogueLine[dialogueBranches[0].dialogueLines.Length + 1];
            for (int i = 0; i < dialogueBranches[0].dialogueLines.Length; i++)
            {
                lines[i] = dialogueBranches[0].dialogueLines[i];
            }
            if(dialogueBranches[0].endPoint != null)
                lines[lines.Length] = dialogueBranches[0].endPoint;
        }*/

        //optionButtons = optionsBox.GetComponentsInChildren<Button>();
        if(characterNameText != null)
            characterNameText.text = lines[index].characterSpeaking;
        //continueButton.SetActive(false);
        //Time.timeScale = 0f;
        //StartCoroutine(Type());
    }

    // Update is called once per frame
    void Update()
    {
        textTypingTimer += Time.unscaledDeltaTime;

        if (!canContinue && canTypeToDisplay)
            TypingOutTextToDisplay();

        if (lines.Length > 0)
        {
            if (textDisplay.text == lines[index].line)
            {
                if (lines[index].endImmediatly && canContinue)
                {
                    if (Input.GetKeyUp(KeyCode.E))
                    {
                        NextSentence();
                    }
                }
            }
        }
    }

    public void TypingOutTextToDisplay ()
    {
        if (textDisplay.text.Length < lines[index].line.Length)
        {
            if (textTypingTimer >= typingSpeed)
            {
                textTypingTimer = 0;
                letterIndex++;
                lines[index].line.ToCharArray();
                char letter = lines[index].line[letterIndex];
                textDisplay.text += letter;
            }
        }
        else
        {
            canContinue = true;
            letterIndex = -1;
        }
    }

    public void SkipDialogue()
    {
        textDisplay.text = "";
        textDisplay.text = lines[index].line;
    }

    public void NextSentence()
    {
        if (index + 1 < lines.Length)
        {
            //continueButton.SetActive(false);

            //timePassed = 0;
            if (index < lines.Length - 1)
            {
                index++;
                canTypeToDisplay = true;
                canContinue = false;
                textTypingTimer = 0;
                //characterNameText.text = lines[index].characterSpeaking;
                textDisplay.text = "";
                
                //StartCoroutine(Type());

            }
            else
            {
                textDisplay.text = "";
            }
        }
        else
        {
            if (lines[index].isTrigger) {
                if (lines[index].triggerName == "gamas leaves") {
                    gameObject.GetComponent<GamasDialogue>().Leave();
                }
                else if (lines[index].triggerName == "return player") {
                    gloopScript.GetComponent<Gloop>().ReturnPlayer();
                }
            }

            if (lines[index].triggerName == "play gamas track") {
            soundTransition.GetComponent<SoundTransition>().PlayGamasTrack();   
            }
            else if (lines[index].triggerName == "play intense") {
                soundTransition.GetComponent<SoundTransition>().PlayIntenseTrack();
            }
            else if (lines[index].triggerName == "play ending") {
                soundTransition.GetComponent<SoundTransition>().PlayIntenseTrack();
            }
            gamasDialogue.GetComponent<GamasDialogue>().eventStarted = false;
            EndConvo();
        }
    }

    public void EndConvo()
    {
        Time.timeScale = 1f;

        PlayerManager.instance.player.SetPlayerState(PlayerState.Normal);
        UIDisplay.SetActive(false);

        if(NPC != null)
        {
            GamasDialogue gamas = NPC.GetComponent<GamasDialogue>();
            if (gamas != null)
            {
                soundTransition.GetComponent<SoundTransition>().PlayDefault();
                gamas.Leave();
            }
        }
    }

    /*void ChangeTutorialButton()
    {
        if (!tutorialButtonBothOptsSelected)
        {
            DialogueButton lastOption = optionButtons[optionButtons.Length - 1].GetComponent<DialogueButton>();
            lastOption.enabled = false;
            lastOption.GetComponent<Button>().interactable = false;
        }
        else
        {
            DialogueButton lastOption = optionButtons[optionButtons.Length - 1].GetComponent<DialogueButton>();
            lastOption.enabled = true;
            lastOption.GetComponent<Button>().interactable = false;
        }
    }*/
}
