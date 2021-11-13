using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;
    public Animator animator;
    public Vector3 dir;
    public GameObject gameOverText;
    public static bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        
            rb = this.GetComponent<Rigidbody2D>();
            animator = GetComponent<Animator>();
            player = GameObject.FindWithTag("Player").transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (OpenDoor.isOpen == true)
        {
            dir = player.position - transform.position;
            float angle = Mathf.Atan(dir.y) * Mathf.Rad2Deg;
            dir.Normalize();
            movement = dir;
            animator.SetFloat("Horizontal", dir.x);
            animator.SetFloat("Vertical", dir.y);
        }
        
    }
    private void FixedUpdate()
    {
        moveCharacter(movement);
    }
    void moveCharacter(Vector2 dir)
    {
        rb.MovePosition((Vector2)transform.position + (dir * moveSpeed * Time.deltaTime));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gameOverText.SetActive(true);
            gameOver = true;
        }
    }



}
