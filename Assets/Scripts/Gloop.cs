using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gloop : MonoBehaviour
{
    public GameObject gamasDialogue;
    public GameObject player;
    public Transform respawnPosition;

    public bool isCreature;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (isCreature && gamasDialogue.GetComponent<GamasDialogue>().progressEvent < 4) {
                gamasDialogue.GetComponent<GamasDialogue>().progressEvent++;
            }

            collision.GetComponent<PlayerController>().movePoint.transform.position = respawnPosition.position;
            collision.transform.position = collision.GetComponent<PlayerController>().movePoint.transform.position;
        }

        if (isCreature) {

        }
    }

    public void ReturnPlayer() {
            player.GetComponent<PlayerController>().movePoint.transform.position = respawnPosition.position;
            player.transform.position = player.GetComponent<PlayerController>().movePoint.transform.position;
    }
}