using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Behind : MonoBehaviour
{
    SpriteRenderer house;
    void Start()
    {
        house = this.GetComponent<SpriteRenderer>();   
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
           if (collision.gameObject.CompareTag("Player"))
        {
            print("Player Behind house");
            house.color = new Color (255, 255, 255, 0.6f);

        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            print("Player Not Behind house");
            house.color = new Color(255, 255, 255, 1);

        }

    }
}
