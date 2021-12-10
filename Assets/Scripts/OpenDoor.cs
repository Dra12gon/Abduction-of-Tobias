using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenDoor : MonoBehaviour
{
    public bool isInRange;
    public GameObject EPopup;
    public GameObject dialogBox;
    public Text noKeyText;
    public string dialog;
    public static bool isOpen = false;
    public AudioSource doorOpen;
    public AudioSource inMusic;
    public AudioSource chase;

    void Update()
    {
        if (isInRange)
        {
            if (Input.GetKeyDown("e") && PuzzleOpen.hasKey == true)
            {
                gameObject.SetActive(false);
                isOpen = true;
                doorsound();
                inMusic.Stop();
                chase.Play();
            }
            else if(Input.GetKeyDown("e") && PuzzleOpen.hasKey == false)
            {
                if (dialogBox.activeInHierarchy)
                {
                    dialogBox.SetActive(false);
                }
                else
                {
                    dialogBox.SetActive(true);
                    noKeyText.text = dialog;
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

    public void doorsound()
    {
        doorOpen.Play();
    }
}
