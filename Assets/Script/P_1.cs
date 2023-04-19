using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class P_1 : MonoBehaviour
{
    Rigidbody2D rig;
    private bool isTERRA = true;
    [SerializeField] GameObject arrow;
    [SerializeField] GameObject trap;
    [SerializeField] GameObject Goal;
    [SerializeField] GameObject grave;
    [SerializeField] Transform grave_Pos;
    [SerializeField] TextMeshProUGUI load;
    [SerializeField] TextMeshProUGUI text;
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        SelfMove();
        jump();
    }
    void SelfMove()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-0.0305f, 0f, 0f);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(0.0305f, 0f, 0f);
        }
    }
    private void jump()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && isTERRA || Input.GetKeyDown(KeyCode.Space) && isTERRA)
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
            text.text = "Success";
        }
        if (collision.gameObject.tag == "Goal")
        {
            text.text = "Failed";
            Destroy(Goal);
            Gooal();
            Destroy(gameObject);
            Destroy(load);
        }
    }
    void EndPage()
    {
        St1_Arrow.isOnOff();
        St1_Arrow.trapOff();
    } 
    void Gooal()
    {
        GameObject Dead = Instantiate(grave);
        Dead.transform.position = grave_Pos.position;
        text.text = "Player 1 WIN";
    }
}
