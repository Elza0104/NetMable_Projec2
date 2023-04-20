using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Trap : MonoBehaviour
{
    void Start()
    {
        StartCoroutine("Start_trap");
    }
    void Update()
    {
        
    }
    IEnumerator Start_trap()
    {
        yield return new WaitForSeconds(4);
        GetComponent<Transform>().Translate(2, 0, 0);
        StartCoroutine("down_trap");
        StartCoroutine("Start_trap");
    }
    IEnumerator down_trap()
    {
        yield return new WaitForSeconds(0.5f);
        transform.Translate(-2, 0, 0);
    }
    public static void trapOff()
    {
        
    }
}
