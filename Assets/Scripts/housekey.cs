using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class housekey : MonoBehaviour
{
    public bool isInRange;
    public static bool hasHouseKey;
    public GameObject dialogBox;
    public Text dialogText;
    public string dialog;
    private bool collected;

    void Update()
    {
        transform.parent = null;
        
        if (isInRange && Input.GetKeyDown("e"))
        {
            
            if (dialogBox.activeInHierarchy)
            {
                dialogBox.SetActive(false);
                hasHouseKey = true;
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
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = false;

            if (collected)
            {
                dialogBox.SetActive(false);
                hasHouseKey = true;
                gameObject.SetActive(false);
            }
        }
    }
}
