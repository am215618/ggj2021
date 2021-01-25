using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueButton : MonoBehaviour
{
    public int buttonIndex;

    Button button;
    DialogueManager dialogueManager;

    private void Start()
    {
        button = GetComponent<Button>();
        dialogueManager = transform.parent.GetComponentInParent<DialogueManager>();
        button.onClick.AddListener(OnClick);
    }

    void OnClick()
    {
        dialogueManager.SelectOption(button.GetComponent<DialogueButton>().buttonIndex);
    }
}
