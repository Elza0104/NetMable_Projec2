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
    [SerializeField] TextMeshProUGUI Load_text;
    [SerializeField] TextMeshProUGUI Mid_text;
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        Move();
        jump();
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
        if (Input.GetKeyDown(KeyCode.UpArrow) && isTERRA || 
            Input.GetKeyDown(KeyCode.Space) && isTERRA)
        {
            rig.AddForce(Vector2.up * 700f);
            isTERRA = false;
        }
    }
    public void ReSpawn()
    {
        transform.position = new Vector2(spawn_x, spawn_y);
        Mid_text.text = "";
        goal.SetActive(true);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    { 
        if (collision.gameObject.tag == "TERRA")
        {
            isTERRA = true;
        }
        if (collision.gameObject.tag == "Arrow" || 
            collision.gameObject.tag == "Narak")
        {
            transform.position = new Vector2(spawn_x, spawn_y);
            Mid_text.text = "Fail";
            StartCoroutine("Failturm");
        }
        if (collision.gameObject.tag == "Goal")
        {
            goal.SetActive(false);
            player.SetActive(false);
            Mid_text.text = "Clear";
            Load_text.text = "";
            stage.GetComponent<Stage>().EndPage();
        }
    }
    IEnumerator Failturm()
    {
        yield return new WaitForSeconds(1f);
        Mid_text.text = "";
    }
}
