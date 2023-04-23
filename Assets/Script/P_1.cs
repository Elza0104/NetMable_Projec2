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
    [SerializeField] GameObject player;
    [SerializeField] GameObject stage;
    [SerializeField] GameObject goal;
    [SerializeField] TextMeshProUGUI load;
    [SerializeField] TextMeshProUGUI text;
    
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        Move();
        jump();
    }
    public void ReSpawn()
    {
        transform.position = new Vector2(spawn_x, spawn_y);
        text.text = "";
        goal.SetActive(true);
    }
    void Move()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-0.1555f, 0, 0 * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(0.1555f, 0, 0 * Time.deltaTime);
        }
    }
    private void jump()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && isTERRA || Input.GetKeyDown(KeyCode.Space) && isTERRA)
        {
            rig.AddForce(Vector2.up * 700f, ForceMode2D.Force);
            isTERRA = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    { 
        if (collision.gameObject.tag == "TERRA")
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
            goal.SetActive(false);
            player.SetActive(false);
            text.text = "Player 1 WIN";
            load.text = "";
            stage.GetComponent<Stage>().EndPage();
        }
    }
    IEnumerator Failturm()
    {
        yield return new WaitForSeconds(1f);
        text.text = "";
    }
}
