using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapC : MonoBehaviour
{
    
    public static TrapC Instance;
    public static bool istrap = true;
    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1) && istrap)
        {
            transform.Translate(2, 0, 0);
            StartCoroutine("_trap");
            StartCoroutine("down_trap");
            StartCoroutine("ISTRAP");
        }
    }
    IEnumerator ISTRAP()
    {
        yield return new WaitForSeconds(0.01f);
        istrap = false;
    }
    IEnumerator _trap()
    {
        yield return new WaitForSeconds(3f);
        istrap = true;
    }
    IEnumerator down_trap()
    {
        yield return new WaitForSeconds(0.5f);
        transform.Translate(-2, 0, 0);
    }
    public static void trapOff()
    {
        istrap = false;
    }
}
