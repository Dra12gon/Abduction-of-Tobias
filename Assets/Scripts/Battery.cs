using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Battery : MonoBehaviour
{
    public bool isInRange;
    public GameObject EPopup;
    public static int numOfBattery = 0;
    public GameObject dialogBox;
    public Text dialogText;
    public string dialog;
    private bool collected;

    void Update()
    {   
        if (isInRange && Input.GetKeyDown("e"))
        {

            if (dialogBox.activeInHierarchy)
            {
                dialogBox.SetActive(false);
                numOfBattery++;
                gameObject.SetActive(false);
            }
            else
            {
                dialogBox.SetActive(true);
                dialogText.text = dialog;
                collected = true;
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
            if (collected)
            {
                gameObject.SetActive(false);
                dialogBox.SetActive(false);
                numOfBattery++;
            }
        }
    }
}
