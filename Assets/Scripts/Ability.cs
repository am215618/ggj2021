using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (!PlayerManager.instance.ui.abilityThing.activeSelf)
            {
                PlayerManager.instance.ui.abilityThing.SetActive(true);
            }
            Destroy(this.gameObject);
        }
    }
}
