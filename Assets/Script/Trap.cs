using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    [SerializeField] GameObject trap_a;
    [SerializeField] Transform trap_Pos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D col)
    {
        Debug.Log(col.gameObject);
        if (col.gameObject.tag == "M_Pos")
        {
            Debug.Log("wwww");
        }
        if (col.gameObject.tag == "M_Pos" && Input.GetMouseButtonDown(0))
        {
            Debug.Log("qwdd");
            GameObject _trap = Instantiate(trap_a, trap_Pos);
            StartCoroutine("istrap");
            Destroy(_trap);
        }
    }
    IEnumerator istrap()
    {
        yield return new WaitForSeconds(1f);
    }
}
