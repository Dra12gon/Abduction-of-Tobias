using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class housekey : MonoBehaviour
{
    public bool isInRange;
    public static bool hasHouseKey;

    void Update()
    {
        if (isInRange && Input.GetKeyDown("e"))
        {
            hasHouseKey = true;
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = false;
        }
    }
}
