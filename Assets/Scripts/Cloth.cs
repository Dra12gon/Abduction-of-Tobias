using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloth : MonoBehaviour
{
    public bool isInRange;
    public GameObject EPopup;
    public static bool hasCloth = false;

    void Update()
    {
        if (isInRange && Input.GetKeyDown("e"))
        {
            gameObject.SetActive(false);
            hasCloth = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = true;
            print("Player now in range");
            EPopup.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = false;
            print("Player now not in range");
            EPopup.SetActive(false);
        }
    }
}
