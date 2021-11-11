using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PuzzleOpen : MonoBehaviour
{
    public bool isOpen;
    public bool hasKey;
    public bool hasLight;

    public void OpenBox()
    {
        if (!isOpen)
        {
            isOpen = true;
            print("opened");
            hasKey = true;
            this.GetComponent<SpriteRenderer>().material.color = new Color(255,255,255,0);
        }
        
    }
    public void OpenPot()
    {
        if (!isOpen)
        {
            isOpen = true;
            print("opened");
            hasLight = true;
            this.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        }

    }




}
