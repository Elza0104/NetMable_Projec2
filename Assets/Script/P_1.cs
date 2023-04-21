using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class P_1 : MonoBehaviour
{
    Rigidbody2D rig;
    private bool isTERRA = true;
    public float spawn_x;
    public float spawn_y;
    public float spawn_Z;
    [SerializeField] GameObject Player;
    [SerializeField] GameObject Stage;
    [SerializeField] GameObject Goal;
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
    public void ReSpawn()
    {
        transform.position = new Vector2(spawn_x, spawn_y);
        text.text = "";
        Goal.SetActive(true);
    }
    void SelfMove()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-0.0355f, 0, 0 * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(0.0355f, 0, 0 * Time.deltaTime);
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
            transform.position = new Vector2(spawn_x, spawn_y);
            text.text = "Fail";
            StartCoroutine("Failturm");
        }
        if (collision.gameObject.tag == "Goal")
        {
            Goal.SetActive(false);
            text.text = "Player 1 WIN";
            Player.SetActive(false);
            load.text = "";
            Stage.GetComponent<Stage>().EndPage();
        }
    }

    IEnumerator Failturm()
    {
        yield return new WaitForSeconds(1f);
        text.text = "";
    }
}
