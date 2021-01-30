using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIScript : MonoBehaviour
{
    public GameObject abilityThing;
    public GameObject KeyThing;

    private void Start()
    {
        abilityThing.SetActive(false);
        KeyThing.SetActive(false);
    }
}
