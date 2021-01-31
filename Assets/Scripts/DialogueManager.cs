using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI characterNameText;
    public TextMeshProUGUI textDisplay;
    public DialogueBranch[] dialogueBranches;
    public DialogueLine[] lines;

    [HideInInspector]
    public GameObject NPC;

    public float typingSpeed;

    //public GameObject optionsBox;
    //public GameObject continueButton;

    public Button button;

    int index;
    //float timePassed;
    //Button[] optionButtons;

    bool canContinue;
    bool canTypeToDisplay;

    public bool tutorialButtonBothOptsSelected;
    float textTypingTimer;
    int letterIndex;
    

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
        characterNameText.text = lines[index].characterSpeaking;
        //continueButton.SetActive(false);
        Time.timeScale = 0f;
        //StartCoroutine(Type());
    }

    // Update is called once per frame
    void Update()
    {
        textTypingTimer += Time.deltaTime;
        //(tutorialIntro != null)
            //tutorialButtonBothOptsSelected = tutorialIntro.BothOptionsSelected();

        if (textDisplay.text == lines[index].line)
        {
            //timePassed += Time.unscaledDeltaTime;

            //if (lines[index].endAfterSeconds <= timePassed && lines[index].endAutomatically || lines[index].endImmediatly)
            if (lines[index].endImmediatly && canContinue)
            {
                if (Input.GetKeyUp(KeyCode.E)) {
                    NextSentence();
                }
            }

            //if (lines[index].GetType() == typeof(DialogueOptions))
            //{
                //DialogueOptions dialogOpt = (DialogueOptions)lines[index];

                //if (dialogOpt.options.Length > optionButtons.Length)
                //{
                    //for (int i = 0; i < dialogOpt.options.Length; i++)
                    //{
                    //    button.GetComponent<DialogueButton>().buttonIndex = i;
                    //    Instantiate(button.gameObject, optionsBox.transform);
                    //}
                    //optionButtons = optionsBox.GetComponentsInChildren<Button>();

                    /*for (int i = 0; i < optionButtons.Length; i++)
                    {
                        optionButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = dialogOpt.options[i];
                        optionButtons[i].GetComponent<DialogueButton>().buttonIndex = i + 1;
                    }*/

                    //if(tutorialIntro != null)
                    //{
                    //    ChangeTutorialButton();
                    //}

                    //optionsBox.SetActive(true);
                //}
            //}
            //else
            //{
            //    if(!lines[index].endAutomatically)
            //        continueButton.SetActive(true);
            //}
        }
        if (!canContinue && canTypeToDisplay)
            TypingOutTextToDisplay();
    }

    void TypingOutTextToDisplay () {
        if (textDisplay.text.Length < lines[index].line.Length) {
            if (textTypingTimer >= typingSpeed)
            {
                textTypingTimer = 0;
                letterIndex++;
                lines[letterIndex].line.ToCharArray();
                char letter = lines[index].line[letterIndex];
                textDisplay.text += letter;
            }
        }
        else {
            canContinue = true;
            letterIndex = 0;
        }
    }

    public void SkipDialogue()
    {
        StopAllCoroutines();
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
                characterNameText.text = lines[index].characterSpeaking;
                textDisplay.text = "";
                canTypeToDisplay = true;
                canContinue = false;
                //StartCoroutine(Type());

            }
            else
            {
                textDisplay.text = "";
            }
        }
        else
        {
            EndConvo();
        }
    }

    public void SelectOption(int buttonIndex)
    {
        //GetComponent<FlashScript>().text.gameObject.SetActive(true);

        index = 0;
        characterNameText.text = lines[index].characterSpeaking;
        textDisplay.text = "";
        if (dialogueBranches[buttonIndex].dialogueLines.Length > 0)
        {
            lines = dialogueBranches[buttonIndex].dialogueLines;
        }
        else
        {
            EndConvo();
        }

        //optionsBox.SetActive(false);
    }

    public void EndConvo()
    {
        Time.timeScale = 1f;

        Destroy(gameObject);
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
