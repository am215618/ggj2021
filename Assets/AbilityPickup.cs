using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityPickup : MonoBehaviour
{
    public GameObject uiEnable;
    public string tagString;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerController>())
        {
            if (tagString == "ability") {
            uiEnable.SetActive(true);
            other.GetComponent<PlayerController>().hasAbility = true;
            }
            if (tagString == "key") {
            uiEnable.SetActive(true);
            other.GetComponent<PlayerController>().hasKey = true;
            }

            Destroy(gameObject);
        }
    }
}
