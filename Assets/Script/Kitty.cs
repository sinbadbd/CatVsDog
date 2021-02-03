using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kitty : MonoBehaviour
{

    public float speed = 2f;
    private Animator anim;

    private float transalation;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        TurnPlayer();
        transalation = Input.GetAxis("Horizontal");
        transform.Translate(new Vector3(transalation, 0f, 0f) * Time.deltaTime * speed);

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
}
