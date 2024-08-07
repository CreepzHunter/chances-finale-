using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    public bool isMoving = false;
    private Collider2D panelCollider;
    public GameObject terrain;
    public Animator anim;
    public Transform child1;
    public Transform child2;

    public void Awake()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        panelCollider = terrain.GetComponent<Collider2D>();
    }

    public void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(horizontalInput, verticalInput).normalized;

        rb.velocity = movement * moveSpeed;

        isMoving = rb.velocity.magnitude > 0.1f;


        if (movement.magnitude < 0.1f)
        {
            anim.SetInteger("movement", 0); // No movement

        }
        else if (verticalInput > 0) // Moving up
        {
            anim.SetInteger("movement", -1);
            child1.localPosition = new Vector2(0, 0.89f);
            child2.localPosition = new Vector2(0, 1.5f);

        }
        else if (verticalInput < 0)// Moving down
        {
            anim.SetInteger("movement", 1);

            child1.localPosition = new Vector2(0, -0.89f);
            child2.localPosition = new Vector2(0, -1.5f);
        }

        if (horizontalInput > 0) // Moving right
        {
            //transform.localScale = new Vector3(0.5636f, 0.5636f, 0.5636f);

            child1.localPosition = new Vector2(0.89f, 0);
            child2.localPosition = new Vector2(01.28f, 0);
        }

        else if (horizontalInput < 0) // Moving left
        {
            child1.localPosition = new Vector2(-0.89f, 0);
            child2.localPosition = new Vector2(-01.28f, 0);

            //transform.localScale = new Vector3(-0.5636f, 0.5636f, 0.5636f);
        }




    }
}
