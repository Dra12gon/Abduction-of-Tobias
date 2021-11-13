using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAim : MonoBehaviour
{

    public GameObject light;
    public GameObject crate;

    void Update()
    {
        faceMouse();
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("light fired");
        }
    }

    void faceMouse()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector2 direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);

        transform.up = direction;

    }


}
