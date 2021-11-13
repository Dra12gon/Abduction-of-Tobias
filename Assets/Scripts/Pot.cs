using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pot : MonoBehaviour
{
    public bool isInRange;
    public GameObject EPopup;
    public GameObject dialogBox;
    public Text dialogText;
    public string dialog;


    void Update()
    {
        if (isInRange)
        {
            if (Input.GetKeyDown("e") && Cloth.hasCloth == true)
            {
                gameObject.SetActive(false);
                PlayerMovement.isFree = true;
                Cloth.hasCloth = false; 
            }
            else if (Input.GetKeyDown("e") && Cloth.hasCloth == false)
            {
                if (dialogBox.activeInHierarchy)
                {
                    dialogBox.SetActive(false);
                }
                else
                {
                    dialogBox.SetActive(true);
                    dialogText.text = dialog;
                }
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

        }
    }
}
