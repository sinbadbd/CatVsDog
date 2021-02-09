using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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

    public Text ScoreText;

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


    public bool movieRight {

        get
        {
            if (transalation == 1)
                return true;
            return false;
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

        if (isDead)
            return;

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


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "coin")
        {
            //upate the coin score text

            ScoreText.text = (int.Parse(ScoreText.text) + 5).ToString();


            GameObject p = Instantiate(particle, col.transform.position, particle.transform.rotation);
            Destroy(p, 0.5f);
            Destroy(col.gameObject);
        }

        if (col.tag == "home")
        {
            if(transform.childCount > 1)
            {
                GameObject chicken = transform.GetChild(1).gameObject;
                //print(chicken);
                chicken.GetComponent<Chiken>().follow = false;
                chicken.transform.parent = null;
                chicken.GetComponent<Collider2D>().enabled = false;
                chicken.GetComponent<ChikenRunner>().enabled = true;

                StartCoroutine(ChickenDestroy(chicken));
            }
        }
    }

    IEnumerator ChickenDestroy(GameObject chicken)
    {
        yield return new WaitForSeconds(1);
        chicken.SetActive(false);
        Destroy(chicken);

        int ChickenCount = GameObject.FindGameObjectsWithTag("Chicken").Length;
        print(ChickenCount);
        if(ChickenCount == 0)
        {
            //print("Level Cleared");
            UIHandler.instance.ShowLevelDialog("Level Cleard", ScoreText.text);
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Max")
        {
            if (isDead)
                return;
            anim.SetTrigger("death");
            isDead = true;

            UIHandler.instance.ShowLevelDialog("Lavel Failed", ScoreText.text);
        }
    }
}
