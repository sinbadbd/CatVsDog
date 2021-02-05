using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chiken : MonoBehaviour
{

    public GameObject player;

   // private Kitty _kitty;


    void Start()
    {
      //  _kitty = player.GetComponent<Kitty>();
    }

    // Update is called once per frame
    void Update()
    {

       if (!player.GetComponent<SpriteRenderer>().flipX)
        {
            this.gameObject.transform.position = Vector2.MoveTowards(
                new Vector3(transform.position.x, transform.position.y, transform.position.z),
                new Vector3(player.transform.position.x - 1, player.transform.position.y, transform.position.z), 6f * Time.deltaTime
            );
        }
        else
        {
            this.gameObject.transform.position = Vector2.MoveTowards(
                new Vector3(transform.position.x, transform.position.y, transform.position.z),
                new Vector3(player.transform.position.x + 1, player.transform.position.y, transform.position.z), 10f * Time.deltaTime
            );
        }

        
    }
}
