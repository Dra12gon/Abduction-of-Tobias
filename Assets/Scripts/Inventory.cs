using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public bool hasitem;
    public GameObject crate;
    public Sprite Item;
    public Image inven;

    // Update is called once per frame
    void Update()
    {
        if (crate.GetComponent<PuzzleOpen>().hasKey)
        {
            inven.sprite = Item;
        }

        if (crate.GetComponent<PuzzleOpen>().hasLight)
        {
            inven.sprite = Item;
        }
        
    }
}
