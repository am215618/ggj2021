using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlamDoorTrigger : MonoBehaviour
{
    public Door doorToSlamShut;
    public Door doorToUnlock;
    public GameObject thingToDissappear;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            doorToSlamShut.CloseDoor();

            if (doorToUnlock != null)
            {
                doorToUnlock.isLocked = false;
                doorToUnlock.gameObject.layer = 9;
            }

            if(thingToDissappear != null)
                thingToDissappear.SetActive(false);
        }
    }
}
