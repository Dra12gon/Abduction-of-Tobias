using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    public bool isInRange;
    public KeyCode interactKey;
    public UnityEvent interactAction;
<<<<<<< HEAD
    public GameObject EPopup;
=======
>>>>>>> 4ad9ab75ef3a343770c3299e37d97c590e6fe41d

    // Update is called once per frame
    void Update()
    {
        if (isInRange)
        {
            if (Input.GetKeyDown(interactKey))
            {
                interactAction.Invoke();
<<<<<<< HEAD
                gameObject.SetActive(false);
=======
>>>>>>> 4ad9ab75ef3a343770c3299e37d97c590e6fe41d
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = true;
            print("Player now in range");
<<<<<<< HEAD
            EPopup.SetActive(true);
=======
>>>>>>> 4ad9ab75ef3a343770c3299e37d97c590e6fe41d
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = false;
            print("Player now not in range");
<<<<<<< HEAD
            EPopup.SetActive(false);
=======
>>>>>>> 4ad9ab75ef3a343770c3299e37d97c590e6fe41d
        }
    }
}
