using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Behind : MonoBehaviour
{
    SpriteRenderer house;
    public bool fadeoutin = true; 
    public float fadeSpeed;
    public float fadeValue;
    

    //    void Start()
    //{
    //    house = this.GetComponent<SpriteRenderer>();

    //}


    private void OnTriggerEnter2D(Collider2D collision)
    {
           if (collision.gameObject.CompareTag("Player"))
        {
            print("Player Behind house");
            fadeoutin = false;
            StartCoroutine(FadeOutObject());
            //house.color = new Color (255, 255, 255, 0.6f);

        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            print("Player Not Behind house");
            fadeoutin = true;
            StartCoroutine(FadeInObject());
            // house.color = new Color(255, 255, 255, 1);


        }

    }

    IEnumerator FadeInObject()
    {
        while (this.GetComponent<Renderer>().material.color.a < 1)
        {
            Color objectColor =
            this.GetComponent<Renderer>().material.color; float fadeAmount = objectColor.a + (fadeSpeed * Time.deltaTime); objectColor = new
            Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
            this.GetComponent<Renderer>().material.color = objectColor; yield return null;
        }

    }

    IEnumerator FadeOutObject()
    {
        while (this.GetComponent<Renderer>().material.color.a > fadeValue)
        {
            Color objectColor = this.GetComponent<Renderer>().material.color; float
            fadeAmount = objectColor.a - (fadeSpeed * Time.deltaTime); objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
            this.GetComponent<Renderer>().material.color = objectColor; yield return null;
        }
    }
}
