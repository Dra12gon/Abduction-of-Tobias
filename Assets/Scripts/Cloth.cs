using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cloth : MonoBehaviour
{
    public bool isInRange;
    public GameObject EPopup;
    public string dialog;
    public GameObject dialogBox;
    public Text dialogText;
    public static bool hasCloth = false;
    private bool hasPicked;

    void Update()
    {
        if (isInRange && Input.GetKeyDown("e"))
        {
            if (dialogBox.activeInHierarchy)
            {
                dialogBox.SetActive(false);
                gameObject.SetActive(false);
                hasCloth = true;
            }
            else
            {
                dialogBox.SetActive(true);
                dialogText.text = dialog;
                hasPicked = true;
            }
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
            dialogBox.SetActive(false);
            if (hasPicked)
            {
                gameObject.SetActive(false);
                hasCloth = true;
            }
        }
    }
}
