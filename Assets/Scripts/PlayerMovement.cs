using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed;
    public GameObject player;
    public Rigidbody2D rb;
    public Animator animator;
    public static bool isFree;


    // Update is called once per frame
    void Update()
    {
        float horiz = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");

        Vector2 newVelocity = new Vector2(horiz, vert);
        GetComponent<Rigidbody2D>().velocity = newVelocity * moveSpeed;

        animator.SetFloat("Horizontal", horiz);
        animator.SetFloat("Vertical", vert);
        
        animator.SetFloat("Speed", newVelocity.sqrMagnitude);
        animator.SetBool("isFree", isFree); 

    }
}
