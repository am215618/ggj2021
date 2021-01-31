using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CurrentChatState { normal, a, b, c, d }
public delegate void OnTriggerPressed(CurrentChatState chatState);

public class PlayerManager : MonoBehaviour
{
    #region Singleton
    public static PlayerManager instance;

    private void OnValidate()
    {
        instance = this;
    }
    #endregion

    public PlayerController player;
    public UIScript ui;
    public DialogueManager dialogueManager;

    private void Start()
    {
        ui.gameObject.SetActive(true);
    }
}
