﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{
    public Door doorToUnlock;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("A");
            if (doorToUnlock != null)
            {
                doorToUnlock.isLocked = false;
                doorToUnlock.gameObject.layer = 9;
                Destroy(this.gameObject);
            }
        }
    }
}
