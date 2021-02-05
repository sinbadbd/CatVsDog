using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kitty : MonoBehaviour
{

    public float jumpForce;
    public float speed = 2f;
    private Animator anim;

    private float transalation;

    public GameObject particle;
    public LayerMask whatIsGround;
    public Transform groupPosition;
    public bool Gronded = true;
    private bool isDead = false;

    private Rigidbody2D rb;


    public float getXPos
    {
        get
        {
            return transform.position.x;
        }
    }

    public float getYPos
    {
        get
        {
            return transform.position.y;
        }

    }


    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump();
        }
    }

    void FixedUpdate()
    {

        //if (isDead)
        //    return;

        TurnPlayer();
        transalation = Input.GetAxis("Horizontal");
        // transform.Translate(new Vector3(transalation, 0f, 0f) * Time.deltaTime * speed);
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
        }else if(transalation > 0 ) {
            this.GetComponent<SpriteRenderer>().flipX = false;   
        }

    }

    bool isGrounded()
    {
        if (Physics2D.OverlapCircle(groupPosition.position, 0.3f, whatIsGround))
        {
            return true;
        }else
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


    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "coin")
        {
            GameObject p = Instantiate(particle, col.transform.position, particle.transform.rotation);
            Destroy(p, 0.5f);
            Destroy(col.gameObject);
        }
    }



    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if(collision.gameObject.tag == "Max"){
    //        if (isDead)
    //            return;

    //        anim.SetTrigger("death");
    //        isDead = true;
    //    }
    //}
}
