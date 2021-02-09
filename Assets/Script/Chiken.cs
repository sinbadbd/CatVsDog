using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chiken : MonoBehaviour
{

    public GameObject player;

   // private Kitty _kitty;

    public bool follow = false;
    void Start()
    {
      //  _kitty = player.GetComponent<Kitty>();
    }

    // Update is called once per frame
    void Update()
    {

        if (!follow)
            return;
       if (!player.GetComponent<SpriteRenderer>().flipX)
        {
            // left move
            this.gameObject.transform.position = Vector2.MoveTowards(
                new Vector3(transform.position.x, transform.position.y, transform.position.z),
                new Vector3(player.transform.position.x - 1, player.transform.position.y, transform.position.z), 6f * Time.deltaTime
            );
        }
        else
        {
            // right move
            this.gameObject.transform.position = Vector2.MoveTowards(
                new Vector3(transform.position.x, transform.position.y, transform.position.z),
                new Vector3(player.transform.position.x + 1, player.transform.position.y, transform.position.z), 10f * Time.deltaTime
            );
        }

        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {

            int children = player.transform.childCount;
            if(children == 2)
                return;
           

            follow = true;
            transform.SetParent(player.transform);
        }
        if (collision.tag == "Max")
        {
            follow = false;
            transform.parent = null;
        }
    }
}
