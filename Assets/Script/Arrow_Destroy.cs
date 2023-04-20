using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow_Destroy : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "TERRA" || collision.gameObject.tag == "Narak" || collision.gameObject.tag == "Arrow" || collision.gameObject.tag == "P_1")
        {
            Destroy(gameObject);
        }
    }
}
