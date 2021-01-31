using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{
    public Door doorToUnlock;
    public AudioSource source;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("A");
            source.Play();
            if (!PlayerManager.instance.ui.KeyThing.activeSelf)
            {
                PlayerManager.instance.ui.KeyThing.SetActive(true);
            }

            if (doorToUnlock != null)
            {
                doorToUnlock.isLocked = false;
                doorToUnlock.gameObject.layer = 9;
                Destroy(this.gameObject);
            }
        }
    }
}
