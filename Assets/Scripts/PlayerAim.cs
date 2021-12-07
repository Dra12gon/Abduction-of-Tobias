using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAim : MonoBehaviour
{

    public GameObject light;
    public GameObject enemy;
    public GameObject crate;
    public bool isOn;

    void Update()
    {
        faceMouse();
        {
            if (Input.GetMouseButton(0))
            {
                light.GetComponent<SpriteRenderer>().material.color = new Color(250, 255, 0, 100);
                Debug.Log("Light On");
                isOn = true;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                light.GetComponent<SpriteRenderer>().material.color = new Color(245, 255, 69, 0);
                isOn = false;
                Debug.Log("Light Off");
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && isOn)
        {
            print("Enemy is in range");
            enemy.GetComponent<Enemy>().moveSpeed = 0;

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            print("Enemy is NOT in range");
            enemy.GetComponent<Enemy>().moveSpeed = 4;
        }
    }

}
