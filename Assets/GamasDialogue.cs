using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamasDialogue : MonoBehaviour
{
    InteractableCharacter interactable;
    //public BoxCollider2D playerCol;
    //public Rigidbody2D playerRb;

    // Start is called before the first frame update
    void Start()
    {
        interactable = gameObject.GetComponent<InteractableCharacter>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D (Collider2D other) {
        if (other.GetComponent<CharacterController>()) {
            if (Input.GetKeyDown(KeyCode.E)) {
                    StartEvent();
                }
        }
    }

    void StartEvent() {
        
    }
}
