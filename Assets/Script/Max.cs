﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Max : MonoBehaviour
{
    public float jumpForce;
    public float speed = 2f;
    private Animator anim;

    private float transalation;


    public LayerMask whatIsGround;
    public Transform groupPosition;
    public bool Gronded = true;
    private bool allowJump = false;

    private Kitty kitty;
    private Rigidbody2D rb;
    void Start()
    {
        kitty = GameObject.FindGameObjectWithTag("Player").GetComponent<Kitty>();

        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        //print(kitty.getXPos);

    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    jump();
        //}
    }

    void FixedUpdate()
    {

        TurnPlayer();
        //transalation = Input.GetAxis("Horizontal");

        AI();


        rb.velocity = new Vector2(transalation * Time.deltaTime * speed, rb.velocity.y);
        if (transalation > 0 || transalation < 0)
        {
            anim.SetFloat("speed", 1);
        }

        if (transalation == 0)
        {
            anim.SetFloat("speed", 0);
        }
    }

    void TurnPlayer()
    {
        if (transalation < 0)
        {
            this.GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (transalation > 0)
        {
            this.GetComponent<SpriteRenderer>().flipX = false;
        }

    }

    bool isGrounded()
    {
        if (Physics2D.OverlapCircle(groupPosition.position, 0.3f, whatIsGround))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void jump()
    {
        if (!isGrounded())
        {
            return;
        }
        else
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }

      void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Jump")
        {
            allowJump = true;
        }
    }
      void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Jump")
        {
            allowJump = false;
        }
    }


    void AI()
    {

        if (kitty.getXPos - 0.5f > transform.position.x)
        {
            transalation = 1f;
        }
        else if (kitty.getXPos + 0.5f < transform.position.x)
        {
            transalation = -1f;
        }


        if(kitty.getYPos > transform.position.y && allowJump)
        {
            jump();
        }



    }
    void switchDirection()
    {

    }
}
