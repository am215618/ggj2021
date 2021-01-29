using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gloop : MonoBehaviour
{
    public Transform respawnPosition;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<PlayerController>().movePoint.transform.position = respawnPosition.position;
            collision.transform.position = collision.GetComponent<PlayerController>().movePoint.transform.position;
        }
    }
}