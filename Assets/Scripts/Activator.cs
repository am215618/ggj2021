using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour
{
    public GameObject objectToTurnOff;
    public GameObject objectToTurnOn;

    public GameObject tentacles;

    public void Start()
    {
        if(objectToTurnOff != null)
            objectToTurnOff.SetActive(true);

        if (objectToTurnOn != null)
            objectToTurnOn.SetActive(false);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(objectToTurnOff != null)
            objectToTurnOff.SetActive(false);

        if (tentacles != null)
            tentacles.SetActive(false);

        if(objectToTurnOn != null)
            objectToTurnOn.SetActive(true);
    }
}
