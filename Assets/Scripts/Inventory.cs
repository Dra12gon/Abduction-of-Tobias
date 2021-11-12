using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public GameObject key;
    public GameObject flashlight;
    public GameObject cloth;


    // Update is called once per frame
    void Update()
    {
        if (PuzzleOpen.hasKey == true)
        {
            key.SetActive(true);
        }

        if (PuzzleOpen.hasLight == true)
        {
            flashlight.SetActive(true);
        }

        if (Cloth.hasCloth == true)
        {
            cloth.SetActive(true);
        }
        else if (Cloth.hasCloth == false)
        {
            cloth.SetActive(false);
        }
    }
}
