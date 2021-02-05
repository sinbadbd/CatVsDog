using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchDirection : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Max")
        {
           // collision.gameObject.GetComponent<Max>().switchDirection();
        }
    }
}
