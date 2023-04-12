using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class P_1 : MonoBehaviour
{
    Rigidbody2D rig;
    private bool isTERRA = true;
    [SerializeField] TextMeshProUGUI DM;
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
            transform.Translate(-0.0305f, 0f, 0f);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(0.0305f, 0f, 0f);
        }
        jump();
    }
    private void jump()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space) && isTERRA)
        {
            rig.AddForce(Vector2.up * 550f, ForceMode2D.Force);
            rig.AddForce(Vector2.up * 100f, ForceMode2D.Force);
            isTERRA = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    { 
        if (collision.gameObject.CompareTag("TERRA"))
        {
            isTERRA = true;
        }
        if (collision.gameObject.tag == "Arrow" || collision.gameObject.tag == "Narak")
        {
            Destroy(gameObject);
            DM.text = "DEAD";
        }
    }
}
