using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionScript : MonoBehaviour
{
    public float interactableDistance = 10.0f;

    protected GameObject player;
    protected GameObject interactThingy;
    protected Transform interactPosition;

    protected Text interactText;
    public string interactOption;

    protected bool interactActive = false;

    public virtual void Start()
    {
        player = PlayerManager.instance.player.gameObject;
        interactThingy = GetComponentInChildren<Canvas>(includeInactive: true).gameObject;
        interactText = interactThingy.GetComponentInChildren<Text>();
        interactThingy.SetActive(false);
    }

    public virtual void Update()
    {
        switch (interactActive)
        {
            case false:
                if (Vector3.Distance(gameObject.transform.position, player.transform.position) <= interactableDistance)
                {
                    interactThingy.SetActive(true);
                    interactPosition = transform;

                    interactText.text = interactOption;
                    interactActive = true;
                }
                break;

            case true:
                if (Vector3.Distance(gameObject.transform.position, player.transform.position) > interactableDistance)
                {
                    interactThingy.SetActive(false);
                    interactActive = false;
                }
                break;
        }
    }
}
