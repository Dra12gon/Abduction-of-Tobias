using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PuzzleOpen : MonoBehaviour
{
    public static bool isOpen = false;
    public static bool hasKey = false;
    public static bool hasLight = false;
    public GameObject light;
    public bool isInRange;
    public GameObject EPopup;
    public GameObject dialogBox;
    public Text dialogText;
    public string dialog;
    public string takeItems;
    private bool hasTaken;

    void Update()
    {
        if (isInRange)
        {
            if (Input.GetKeyDown("e") && PlayerMovement.isFree == true)
            {
                if (PuzzleScript.solved == true)
                {
                    if (dialogBox.activeInHierarchy)
                    {
                        hasKey = true;
                        hasLight = true;
                        gameObject.SetActive(false);
                        light.SetActive(true);
                    }
                    else
                    {
                        dialogBox.SetActive(true);
                        dialogText.text = takeItems;
                        hasTaken = true;
                    }
                }
                else
                {
                    SceneManager.LoadSceneAsync("Puzzle");
                }
            }
            else if (Input.GetKeyDown("e") && PlayerMovement.isFree == false)
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

    public void OpenBox()
    {
        if (isOpen == false)
        {
            isOpen = true;
            print("opened");
            hasKey = true;
            this.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        }

    }
    public void OpenPot()
    {
        if (isOpen == false)
        {
            isOpen = true;
            print("opened");
            hasLight = true;
            this.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
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

            if (hasTaken)
            {
                hasKey = true;
                hasLight = true;
                gameObject.SetActive(false);
                light.SetActive(true);
            }
        }
    }
}
