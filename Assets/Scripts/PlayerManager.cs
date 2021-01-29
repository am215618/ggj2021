using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void OpenDoor();

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

    private void Start()
    {
        ui.gameObject.SetActive(true);
    }
}
