using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_1 : MonoBehaviour
{
    Rigidbody2D rig;
    private bool isTERRA = true;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-0.05f, 0f, 0f);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(0.05f, 0f, 0f);
        }
        jump();
    }
    private void jump()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && isTERRA)
        {
            rig.AddForce(Vector2.up * 10f, ForceMode2D.Impulse);
            isTERRA = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    { 
        if (collision.gameObject.CompareTag("TERRA"))
        {
            isTERRA = true;
        }
        
    }
}
