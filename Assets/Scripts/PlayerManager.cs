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

    public Player player;
    //public UIScript ui;
}
